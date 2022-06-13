using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Lab8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BCM bcm = new BCM();
            if(args.Length == 2 && args[0] == "-h")
            {
                try
                {
                    string ext  = Path.GetExtension(args[1]);
                    byte[] data;
                    if(ext != ".jpeg" && ext != ".png")
                    {
                        throw new Exception("Not allowed type of image! Must be a JPEG/JPG image!");
                    }
                    Console.WriteLine("Input type of message, File or keyboard ? F/K");
                    string choice = Console.ReadLine();
                    if (choice.ToUpper() == "F")
                    {
                        Console.WriteLine("Input path to file:");
                        string path = Console.ReadLine();
                        data = File.ReadAllBytes(path);
                    }else if(choice.ToUpper() == "K")
                    {
                        Console.WriteLine("Input message:");
                        string message = Console.ReadLine();
                        data = Encoding.ASCII.GetBytes(message);
                    }
                    else
                    {
                        throw new Exception("choice not supported!");
                    }
                    bcm.hide(args[1], data);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (args.Length == 3 && args[0] == "-x")
            {
                if(Path.GetExtension(args[2]) == ".png" || Path.GetExtension(args[2]) == ".jpeg")
                {
                    bcm.extractUsingOriginal(args[1], args[2]);
                }
                else
                {
                    bcm.extractUsingKey(args[1], args[2]);
                }                
            }
            else
            {
                usage();
            }
        }
        static void usage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("Hide data in image file:\t[-h] [Path to image]");
            Console.WriteLine("Extract data in image:  \t[-x] [Path to image] [Path to key file or Original image]");
        }
    }
}
