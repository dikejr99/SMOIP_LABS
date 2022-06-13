using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography;

namespace Lab7
{
    internal class Knapsack
    {

        public void generateKeyPairs()
        {
            List<int> publicKey = new List<int>();
            List<int> privateKey = new List<int>();
            Random random = new Random();
            /*  Private  key   */
            int init = random.Next(0, 5), tmp = init, m, n = 0;
            for (int i = 0; i < 8; i++)
            {
                tmp += random.Next(tmp + 1, tmp + 6);
                privateKey.Add(tmp);
            }
            /*  Public  key   */
            m = tmp + random.Next(tmp + 10, tmp + 20);
            for (int i = m / 3; i < m; i++)
            {
                if (haveNoCommonFactor(i, m))
                {
                    n = i;
                    break;
                }
            }
            foreach (int i in privateKey)
            {
                publicKey.Add((i * n) % m);
            }
            privateKey.Add(n);
            privateKey.Add(m);
            /*  Save key pairs in a file  */
            Console.WriteLine("Input path to save key:");
            string path = Console.ReadLine();

            string json = "{\"private_key\": \"" + string.Join("-", publicKey) + "\", \"public_key\": \"" + string.Join("-", privateKey) +"\"}";
            if(File.Exists(path + "\\key.json"))
            {
                Console.WriteLine("A key file already exist in destination path! Replace it? Y/N: ");
                string choise = Console.ReadLine();
                if (choise.ToUpper() == "Y")
                {
                    File.WriteAllText(path + "\\key.json", json);
                    Console.WriteLine("Key pairs created successfully! \nFile saved in: " + path + "\\key.json");
                }
                else
                {
                    return;
                }
            }
            else {
                File.WriteAllText(path + "\\key.json", json);
                Console.WriteLine("Key pairs created successfully! \nFile saved in: " + path + "\\key.json");
            }
        }

        public void sign(string path, string destination)
        {
            string hash = HashFile(path);
            byte[] data = Encoding.ASCII.GetBytes(hash);

            Console.WriteLine("Input private key:");
            string key = Console.ReadLine();
            var p_key = key.Split('-');
            int[] private_key = Array.ConvertAll(p_key, s => int.Parse(s));
            
            string[] bin = data.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).ToArray();

            List<int> encrypted = new List<int>();
            foreach (string b in bin)
            {
                int element = 0;
                for(int i = 0; i < 8; i++)
                {
                    element += (b[i] - 48) * private_key[i];
                }
                encrypted.Add(element);
            }
            //verify if file already exist !!!!!!!!!!!!
            string destination_path = destination + "\\signature.bin";
            if (File.Exists(destination_path))
            {
                Console.WriteLine("A segnature file already exist in destination path! Replace it? Y/N: ");
                string choise = Console.ReadLine();
                if(choise.ToUpper() == "Y")
                {
                    File.WriteAllText(destination_path, string.Join("-", encrypted));
                    Console.WriteLine("Signature saved in: " + destination_path);
                }
                else
                {
                    return;
                }
            }
            else
            {
                File.WriteAllText(destination_path, string.Join("-", encrypted));
                Console.WriteLine("Signature saved in: " + destination_path);
            }
        }

        public bool verify(string signature, string document)
        {
            Console.WriteLine("Input sender public key:");
            string key = Console.ReadLine();
            var p_key = key.Split('-');
            int[] public_key = Array.ConvertAll(p_key, s => int.Parse(s));
            string signatureFile = File.ReadAllText(signature);
            string[] signatureFileArr = signatureFile.Split('-');
            int[] encryptedData = Array.ConvertAll(signatureFileArr, s => int.Parse(s));

            int n = public_key[public_key.Length - 2];
            int m = public_key[public_key.Length - 1];
            int n_inverse = modInverse(n, m);
            List<byte> hash_b = new List<byte>();
            foreach( int d in encryptedData)
            {
                int data = (d * n_inverse) % m;
                hash_b.Add(knapsack_problem(data, public_key));
            }
            string hash = Encoding.Default.GetString(hash_b.ToArray());
            string hashed_document = HashFile(document);
            if(hash == hashed_document)
            {
                Console.WriteLine("Signature is verified!");
                return true;
            }
            Console.WriteLine("Signature is not matching! This is unnverified data!!");
            return false;                      
        }

        public byte knapsack_problem(int n, int[] key)
        {
            string data = "";
            int max_index = 0;
            while(max_index < key.Length - 2)
            {
                if(key[max_index] > n)
                {
                    break;
                }
                max_index++;
            }
            int total = 1 << (max_index + 1);

            for (int i = 0; i < total; i++)
            {
                int sum = 0;
                
                for (int j = 0; j < max_index; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        sum += key[j];
                        data += "1";
                    }
                    else
                    {
                        data += "0";
                    }
                }
                if(sum == n)
                {
                    break;
                }
                else
                {
                    data = "";
                }
            }
            int mod8Len = data.Length % 8;
            if (mod8Len != 0)
            {
                // pad to length multiple of 8
                data = data.PadRight(((data.Length / 8) + 1) * 8, '0');
            } 
            return Convert.ToByte(data, 2);
        }

        public string HashFile(string filePath)
        {
            using (SHA256 SHA256 = SHA256.Create())
            {
                using (FileStream fileStream = File.OpenRead(filePath))
                    return Convert.ToBase64String(SHA256.ComputeHash(fileStream));
            }
        }

        public int modInverse(int a, int m)
        {

            for (int x = 1; x < m; x++)
                if (((a % m) * (x % m)) % m == 1)
                    return x;
            return 1;
        }

        public bool haveNoCommonFactor(int n1, int n2)
        {
            int hcf = 1;
            int j = (n1 < n2) ? n1 : n2;
            for (int i = 1; i <= j; i++)
            {
                if (n1 % i == 0 && n2 % i == 0)
                {
                    hcf = i;
                }
            }
            return (hcf == 1);
        }
    }
}
