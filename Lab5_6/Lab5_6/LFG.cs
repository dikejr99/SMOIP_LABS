using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6
{
    internal class LFG
    {
        private byte[] key;
        public LFG(string key, int length)
        {
            if (!isKeyValid(key))
            {
                Console.WriteLine("Key is not valid! Try again.");
                return;
            }
            this.key = keyGenerator(key, length);
            
            //Console.WriteLine("Key length: " + this.key.Length);
        }

        public byte[] encrypt(byte[] content)
        {
            byte[] result = new byte[content.Length];
            for(int i = 0; i < content.Length; i++)
            {
                result[i] = (byte)(content[i] ^ key[i]);
            }
            return result;
        }

        bool isKeyValid(string key)
        {
            if(key.Length > 1 && key.Length <=64)
            {
                return true;
            }
            return false;
        }

        private byte[] keyGenerator(string k, int length)
        {
            //string key = "";
            List<byte> key = new List<byte>();
            string tmp = k;
            for(int i = 0; i < length; i++)
            {
                byte c = (byte)(tmp[i] ^ tmp[i+1]);
                key.Add(c);
                tmp += (char)c;
            }
            return key.ToArray();
        }
    }
}
