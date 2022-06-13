using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_6
{
    internal class RC2
    {
        ushort[] Key;
        public RC2(string key)
        {
            if (!keyIsValid(key))
            {
                Console.WriteLine("Key is not given or more than maximum length");
                return;
            }
            
            Key = keyExpansion(key);
        }

        public ushort[] keyExpansion(string key)
        {
            byte[] PITABLE = tablePI();
            int T = key.Length;
            byte[] L = new byte[128];
            ushort[] K = new ushort[64];
            int i = 0;
            foreach (char c in key)
            {
                L[i] = Convert.ToByte(c);
                i++;
            }
            int T8 = ASCIIEncoding.Unicode.GetByteCount(key);
            int T1 = (T8 * 8);
            int TM = (int)(255 % Math.Pow(2, 8 + T1 - 8 * T8));
            for(i = T; i < 128; i++)
            {
                L[i] = PITABLE[(255 % (L[i - 1] + L[i - T]))];
            }
            L[128 - T8] = PITABLE[(L[128 - T8] & TM)];
            for(i = 127- T8; i >= 0; i--)
            {
                L[i] = PITABLE[(L[i + 1] ^ L[i + T8])];
            }
            for(i = 0; i < 64; i++)
            {
                K[i] = (ushort)(L[2 * i] + (256 * L[2 * i + 1]));
            }
            return K;
        }

        public string encrypte(byte[] data)
        {
            ushort[] R = this.getData16(data);
            //foreach (ushort r in R)
            //{
            //    Console.Write(r + " | ");
            //}
            //Console.WriteLine();
            int j = 0;
            //5x mixing rounds
            for (int i = 0; i < 5; i++)
            {
                MixingRound(R, ref j);
            }
            //Mashing round
            MashingRound(R);

            //6x mixing rounds
            for (int i = 0; i < 6; i++)
            {
                MixingRound(R, ref j);
            }
            //Mashing round
            MashingRound(R);

            //5x mixing rounds
            for (int i = 0; i < 5; i++)
            {
                MixingRound(R, ref j);
            }
            //ushort to hex
            string encryptedData = "";
            for(int i = 0; i < R.Length; i++)
            {
                string number = R[i].ToString("X");
                int mod4Len = number.Length % 4;
                if (mod4Len != 0)
                {
                    // pad to length multiple of 4
                    number = number.PadLeft(((number.Length / 4) + 1) * 4, '0');
                }
                encryptedData += number;
            }
            
            //Console.WriteLine("Encrypted data: " + encryptedData);
            //foreach (ushort r in R)
            //{
            //    Console.Write(r + " | ");
            //}
            //Console.WriteLine();
            //string[] results = new string[] { encryptedData, j.ToString() };
            return encryptedData;
        }
        void MashingRound(ushort[] R)
        {
           // for (int i = 0; i < R.Length; i++)
           // {
           //     R[i] = (ushort)(R[i] + Key[R[getIndex(i - 1, R.Length)] & 63]);
            //}
        }
        void MixingRound(ushort[] R, ref int j)
        {
            for (int i = 0; i < R.Length; i++, j++)
            {
                if(j == Key.Length) j = 0;

                R[i] = (ushort)(R[i] + Key[j]);// + (R[getIndex(i - 1, R.Length)] & R[getIndex(i - 2, R.Length)]) + ((~R[getIndex(i - 1, R.Length)]) & R[getIndex(i - 3, R.Length)]));
               
                //Rotate left by 1
                //R[i] = (ushort)((R[i] << 1) | (R[i] >> (32 - 1)));
            }
        }

        public byte[] decrypt(string data)
        {
            ushort[] R = this.getData16(data);
            int j = 0;
            //foreach (ushort r in R)
            //{
            //    Console.Write(r + " | ");
            //}
            //Console.WriteLine();
            //5x R-Mixing rounds
            for (int i = 0; i < 5; i++)
            {
                R_MixingRound(R, ref j);
            }
            //R-Mashing round
            R_MachingRound(R);
            //6x R-Mixing rounds
            for (int i = 0; i < 6; i++)
            {
                R_MixingRound(R, ref j);
            }
            //R-Mashing round
            R_MachingRound(R);
            //5x R-mixing rounds
            for (int i = 0; i < 5; i++)
            {
                R_MixingRound(R, ref j);
            }
            //Console.WriteLine("Decrypted data: ");
            // (ushort r in R)
            //{
            //    Console.Write(r + " | ");
            //}
            
            return toDataBytes(R);
        }
        void R_MixingRound(ushort[] R, ref int j)
        {
            for (int i = 0; i < R.Length; i++, j++)
            {
                if (j == Key.Length) j = 0;

                //rotate right by 1
                //R[i] = (ushort)((R[i] >> 1) | (R[i] << (32 - 1)));

                R[i] = (ushort)(R[i] - Key[j]);// - (R[getIndex(i - 1, R.Length)] & R[getIndex(i - 2, R.Length)]) - ((~R[getIndex(i - 1, R.Length)]) & R[getIndex(i - 3, R.Length)]));         
            }
        }

        void R_MachingRound(ushort[] R)
        {
           // for (int i = 0; i < R.Length; i++)
            //{
            //    R[i] = (ushort)(R[i] - Key[R[getIndex(i - 1, R.Length)] & 63]);
           // }
        }
        int getIndex(int i, int length)
        {
            int tmp = i;
            
            while(tmp < 0)
            {
                tmp += length;
            }
            return tmp;
        }

        ushort[] getData16(byte[] data)
        {
            List<ushort> res = new List<ushort>();
            string hex = BitConverter.ToString(data).Replace("-", string.Empty);
            int mod4Len = hex.Length % 4;
            if (mod4Len != 0)
            {
                // pad to length multiple of 4
                hex = hex.PadLeft(((hex.Length / 4) + 1) * 4, '0');
            }
            //Console.WriteLine("Data to encrypt: " + hex);
            for (int i = 0; i < hex.Length; i += 4)
            {
                string number = hex.Substring(i, 4);
                ushort element = Convert.ToUInt16(number, 16);
                res.Add(element);
            }
            return res.ToArray();
        }

        byte[] toDataBytes(ushort[] data)
        {
            string hex = "";
            for (int i = 0; i < data.Length; i++)
            {
                string number = data[i].ToString("X2");
                int mod4Len = number.Length % 4;
                if (mod4Len != 0)
                {
                    // pad to length multiple of 4
                    number = number.PadLeft(((number.Length / 4) + 1) * 4, '0');
                }
                hex += number;
            }
            //Console.WriteLine("\n" + hex);
            if (hex[0] == '0' && hex[1] == '0')
            {
                hex = hex.Substring(2);
            }
            return Enumerable.Range(0, hex.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                     .ToArray();
        }
        ushort[] getData16(string data)
        {
            //Console.WriteLine("Data to decrypt: " + data);
            List<ushort> res = new List<ushort>();
            for (int i = 0; i < data.Length; i += 4)
            {
                string number = data.Substring(i, 4);
                ushort element = Convert.ToUInt16(number, 16);
                res.Add(element);
            }

            return res.ToArray();
        }

        public bool keyIsValid(string key)
        {
            if (key == null || key == "" || key.Length > 128)
            {
                return false;
            }
            return true;
        }

        public byte[] tablePI()
        {

            byte[] tablePI = new byte[256]
            {
                0xd9, 0x78, 0xf9, 0xc4, 0x19, 0xdd, 0xb5, 0xed, 0x28, 0xe9, 0xfd, 0x79, 0x4a, 0xa0, 0xd8, 0x9d,
                0xc6, 0x7e, 0x37, 0x83, 0x2b, 0x76, 0x53, 0x8e, 0x62, 0x4c, 0x64, 0x88, 0x44, 0x8b, 0xfb, 0xa2,
                0x17, 0x9a, 0x59, 0xf5, 0x87, 0xb3, 0x4f, 0x13, 0x61, 0x45, 0x6d, 0x8d, 0x09, 0x81, 0x7d, 0x32,
                0xbd, 0x8f, 0x40, 0xeb, 0x86, 0xb7, 0x7b, 0x0b, 0xf0, 0x95, 0x21, 0x22, 0x5c, 0x6b, 0x4e, 0x82,
                0x54, 0xd6, 0x65, 0x93, 0xce, 0x60, 0xb2, 0x1c, 0x73, 0x56, 0xc0, 0x14, 0xa7, 0x8c, 0xf1, 0xdc,
                0x12, 0x75, 0xca, 0x1f, 0x3b, 0xbe, 0xe4, 0xd1, 0x42, 0x3d, 0xd4, 0x30, 0xa3, 0x3c, 0xb6, 0x26,
                0x6f, 0xbf, 0x0e, 0xda, 0x46, 0x69, 0x07, 0x57, 0x27, 0xf2, 0x1d, 0x9b, 0xbc, 0x94, 0x43, 0x03,
                0xf8, 0x11, 0xc7, 0xf6, 0x90, 0xef, 0x3e, 0xe7, 0x06, 0xc3, 0xd5, 0x2f, 0xc8, 0x66, 0x1e, 0xd7,
                0x08, 0xe8, 0xea, 0xde, 0x80, 0x52, 0xee, 0xf7, 0x84, 0xaa, 0x72, 0xac, 0x35, 0x4d, 0x6a, 0x2a,
                0x96, 0x1a, 0xd2, 0x71, 0x5a, 0x15, 0x49, 0x74, 0x4b, 0x9f, 0xd0, 0x5e, 0x04, 0x18, 0xa4, 0xec,
                0xc2, 0xe0, 0x41, 0x6e, 0x0f, 0x51, 0xcb, 0xcc, 0x24, 0x91, 0xaf, 0x50, 0xa1, 0xf4, 0x70, 0x39,
                0x99, 0x7c, 0x3a, 0x85, 0x23, 0xb8, 0xb4, 0x7a, 0xfc, 0x02, 0x36, 0x5b, 0x25, 0x55, 0x97, 0x31,
                0x2d, 0x5d, 0xfa, 0x98, 0xe3, 0x8a, 0x92, 0xae, 0x05, 0xdf, 0x29, 0x10, 0x67, 0x6c, 0xba, 0xc9,
                0xd3, 0x00, 0xe6, 0xcf, 0xe1, 0x9e, 0xa8, 0x2c, 0x63, 0x16, 0x01, 0x3f, 0x58, 0xe2, 0x89, 0xa9,
                0x0d, 0x38, 0x34, 0x1b, 0xab, 0x33, 0xff, 0xb0, 0xbb, 0x48, 0x0c, 0x5f, 0xb9, 0xb1, 0xcd, 0x2e,
                0xc5, 0xf3, 0xdb, 0x47, 0xe5, 0xa5, 0x9c, 0x77, 0x0a, 0xa6, 0x20, 0x68, 0xfe, 0x7f, 0xc1, 0xad,
            };

            return tablePI;
        }
    }
}
