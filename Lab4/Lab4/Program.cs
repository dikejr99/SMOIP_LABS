using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: [operation: -c or -d] [Input file path] [Destination path]");
            }
            else
            {
                if (args[0] == "-c")
                {
                    //compression
                    Console.WriteLine("compression of " + args[1] + " to: " + args[2] + " ....");
                    compression(args[1], args[2]);
                }
                else if (args[0] == "-d")
                {
                    //decompression
                    Console.WriteLine("decompression of " + args[1] + " to: " + args[2]);
                    decompression(args[1], args[2]);
                }
                else
                {
                    Console.WriteLine(args[0] + " Operation not recognized!");
                }
            }

        }

        static void compression(string inputPath, string destination)
        {
            byte[] contents = File.ReadAllBytes(inputPath);
            
            Tree tree = new(contents);
            Node root = tree.root;
            string encodedData = tree.encode();
            //Console.WriteLine(encodedData);
            string encodedDataHex = BinaryStringToHexString(encodedData);
            string filename = Path.GetFileNameWithoutExtension(inputPath);
            string destinationFile = destination + "\\" + filename + ".bin";

            Stream ms = File.OpenWrite(destinationFile);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(ms, root);
            formatter.Serialize(ms, encodedDataHex);
            formatter.Serialize(ms, encodedData.Length);
            ms.Flush();
            ms.Close();
            ms.Dispose();
            Console.WriteLine("Compressed successfuly!");
        }

        static void decompression(string inputPath, string destination)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Open(inputPath, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            Node root = (Node)obj;
            object obj2 = formatter.Deserialize(fs);
            string encoded = (string)obj2;
            object obj3 = formatter.Deserialize(fs);
            int length = (int)obj3;

            fs.Flush();
            fs.Close();
            fs.Dispose();
            byte[] decodedData = Tree.decode(root, encoded, length);
            File.WriteAllBytes(destination, decodedData);
            Console.WriteLine("Decompressed successfuly!");
        }

        public static string BinaryStringToHexString(string binary)
        {
            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadRight(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }
    }
}
