using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Lab8
{
    internal class BCM
    {
        public void hide(string path, byte[] data)
        {
            Image image = Image.FromFile(path);
            Bitmap img = new Bitmap(image);
            string message = string.Join("", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
            
            /*      Calculate needed blocks number for this message     */
            int blocks = message.Length / 4;

            /*      Check if message can fit in image     */
            int max_blocks = (img.Width * img.Height) / 4;  //2x2 blocks
            if (blocks > max_blocks)
            {
                Console.WriteLine("Message can not fit in this image.");                
                return;
            }
            printData(message, blocks, max_blocks);

            List<int> key = new List<int>();
            Random random = new Random();
            int k = 0;

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height && k < message.Length; j += 4)
                {
                    int max_index = (j + 3 >= img.Height) ? (img.Height - 1) : (j + 3);
                    int index = random.Next(j, max_index);
                    Color pixel = img.GetPixel(i, index);
                    key.Add(i);
                    key.Add(index);

                    /* R byte */
                    byte r = pixel.R;
                    string r_bin = Convert.ToString(r, 2).PadLeft(8, '0');
                    r_bin = r_bin.Substring(0, r_bin.Length - 2) + message[k] + message[k + 1];
                    r = Convert.ToByte(r_bin, 2);

                    /* B byte */
                    byte b = pixel.B;
                    string b_bin = Convert.ToString(b, 2).PadLeft(8, '0');
                    b_bin = b_bin.Substring(0, b_bin.Length - 2) + message[k + 2] + message[k + 3];
                    b = Convert.ToByte(b_bin, 2);

                    k += 4;
                    /*  Following steps helps with extraction with original file    */
                    byte g = pixel.G;
                    if (pixel.R == r && pixel.B == b)
                    {
                        g = (byte)((g + 1) % 255);
                    }

                    Color newPixel = Color.FromArgb(r, g, b);
                    img.SetPixel(i, index, newPixel);
                }
            }
            image.Dispose();

            Console.WriteLine("Write path destination to save new image and key:");
            string destination = Console.ReadLine();
            string image_destination = destination + "\\" + Path.GetFileNameWithoutExtension(path) + "_mod.png";// + Path.GetExtension(path);
            img.Save(image_destination, ImageFormat.Png); // path
            File.WriteAllText(destination + "\\Key.bin", string.Join("-", key));
            successMsg("Data concealed successfully in image!");
        }

        public void extractUsingKey(string path, string KeyPath)
        {
            string[] key = File.ReadAllText(KeyPath).Split('-');
            //int[] key = Array.ConvertAll(s_key, s => int.Parse(s));
            Image image = Image.FromFile(path);
            Bitmap img = new Bitmap(image);
            string d_message = "";
           
            for (int i = 0; i < key.Length; i += 2)
            {
                int x = int.Parse(key[i]);
                int y = int.Parse(key[i + 1]);
                Color pixel = img.GetPixel(x, y);
                // R byte 
                d_message += getBits(pixel.R, 2);

                // B byte
                d_message += getBits(pixel.B, 2);
                Console.Write("\rExtracting... \t{0}%", ((i * 100) / key.Length));
            }
            Console.Write("\rExtracting... \t{0}%", 100);
            image.Dispose();
            Console.WriteLine("\nWrite path to save results (with file name):");
            string resPath = Console.ReadLine();

            int numOfBytes = d_message.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(d_message.Substring(8 * i, 8), 2);
            }            
            File.WriteAllBytes(resPath, bytes);
            successMsg("Data extracted successfully!");
        }

        public void extractUsingOriginal(string path, string original)
        {
            Bitmap img = new Bitmap(path);
            Bitmap org = new Bitmap(original);
            if((img.Width != org.Width) || (img.Height != org.Height))
            {
                Console.WriteLine("This is not original image!");
                return;
            }
            string message = "";
            for(int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color pixel = img.GetPixel(i, j);
                    Color originalPixel = org.GetPixel(i, j);
                    if(pixel != originalPixel)
                    {
                        message += getBits(pixel.R, 2);
                        message += getBits(pixel.B, 2);
                    }
                    
                }
                Console.Write("\rExtracting... \t{0}%", ((i * 100) / img.Width ));
            }
            Console.Write("\rExtracting... \t{0}%", 100);
            Console.WriteLine("\nWrite path to save results (with file name):");
            string resPath = Console.ReadLine();

            int numOfBytes = message.Length / 8;
            byte[] bytes = new byte[numOfBytes];
            for (int i = 0; i < numOfBytes; ++i)
            {
                bytes[i] = Convert.ToByte(message.Substring(8 * i, 8), 2);
            }           

            File.WriteAllBytes(resPath, bytes);
            successMsg("Data extracted successfully!");
        }

        private string getBits(byte b, int bitsNumber)
        {
            byte bits = (byte)(b & ((1 << bitsNumber) - 1));
            return Convert.ToString(bits, 2).PadLeft(bitsNumber, '0');
            
            /*string bin = Convert.ToString(b, 2).PadLeft(8, '0');
            return bin.Substring(bin.Length - bitsNumber);*/
        }
        private void printLine(int a)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("\n");
            for (int i = 0; i < a; i++)
            {
                Console.Write("#");
            }
            Console.Write("\n\n");
        }

        private void printData(string message, int blocks, int max_blocks)
        {
            printLine(40);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Message to conceal size: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine((message.Length / 8) + " byte(s)");
            printLine(40);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Number of blocks needed: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(blocks);
            printLine(40);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Maximum image blocks: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(max_blocks);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Maximum size of message: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(((max_blocks * 4) / 8) + " byte(s)");
            printLine(40);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void successMsg(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
