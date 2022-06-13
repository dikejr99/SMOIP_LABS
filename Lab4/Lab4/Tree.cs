using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Tree
    {
        public Node? root { get; set; } = new();
        byte[] data;
        public Tree(byte[] input)
        {
            data = input;
            //Create a node foreach character with frequency (array)
            List<Node> nodes = buildNodes();

            //Arrange list of nodes ascending frequency
            nodes.Sort((p, q) => p.frequency.CompareTo(q.frequency));

            // Buiding the tree - Comnbine first 2 nodes and join them with new parent node
            int step = 1;
            while(nodes.Count > 1)
            {
                Node parent = new();
                Node left = nodes[0];
                Node right = nodes[1];
                parent.right = right;
                parent.left = left;
                parent.frequency = (short)(left.frequency + right.frequency);
                nodes.RemoveAt(0);
                nodes.RemoveAt(0);
                nodes.Add(parent);
                if(nodes.Count > 1)
                {
                    nodes.Sort((p, q) => p.frequency.CompareTo(q.frequency));
                }
            }
            this.root = nodes[0];
        }

        public List<Node> buildNodes()
        {
            List<Node> nodes = new();
            var frequencies = new Dictionary<byte, short>();
            foreach (byte b in data)
            {
                if (frequencies.ContainsKey(b))
                {
                    frequencies[b]++;
                }
                else
                {
                    frequencies.Add(b, 1);
                }
            }
            foreach (KeyValuePair<byte, short> entry in frequencies)
            {
                Node node = new();
                node.value = entry.Key;
                node.frequency = entry.Value;
                nodes.Add(node);
            }
            return nodes;
        }

        public void printNodes(Node? root, string code, Dictionary<byte, string> codes)
        {
            if (root != null)
            {
                printNodes(root.left, code+"1", codes);
                if (root.left == null && root.right == null)
                {
                    codes.Add(root.value, code);
                }
                printNodes(root.right, code + "0", codes);
            }
        }

        public string encode()
        {
            var codes = new Dictionary<byte, string>();
            printNodes(this.root, "", codes);
            //foreach(KeyValuePair<byte, string> entry in codes)
            //{
            //    Console.WriteLine((char)entry.Key + " - " + entry.Value);
            //}
            string encodedData = "";
            List<byte> result = new();
            foreach (byte b in data)
            {
                encodedData += codes[b];
            }
            
            return encodedData;
        }

        public static byte[] decode(Node root, string encoded, int length)
        {
            Node node = root;
            //string decoded = "";
            string binarystring = String.Join(String.Empty,
              encoded.Select(
                c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
              )
            );
            List<byte> result = new();
            int i = 1;
            foreach (char c in binarystring)
            {
                if(i == length + 1)
                {
                    break;
                }
                if (c == '0')
                {
                    node = node.right;
                    if(node.left == null && node.right == null)
                    {
                        //decoded += node.value;
                        result.Add(node.value);
                        node = root;
                    }
                }
                else if (c == '1')
                {
                    node = node.left;
                    if (node.left == null && node.right == null)
                    {
                        //decoded += node.value;
                        result.Add(node.value);
                        node = root;
                    }
                }
                i++;
            }
            //byte[] result = Convert.FromBase64String(decoded);
            return result.ToArray();
        }
        


    }
}
