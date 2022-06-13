using System;

namespace Lab5_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: [algorithm: -se/-sd or -be/-bd] [Input file path] [Destination path]");
                return;
            }

            if (args[0] == "-be" || args[0] == "-bd")
            {
                //Block
                Console.Write("Enter key: ");
                string ?key = Console.ReadLine();
                RC2 rc2 = new(key);
                if (args[0] == "-be"){
                    // encryption
                    Console.WriteLine("Encryption of " + args[1] + " to: " + args[2] + " ...");
                    string encryptedData = rc2.encrypte(File.ReadAllBytes(args[1]));
                    string filename = Path.GetFileNameWithoutExtension(args[1]);
                    string destinationFile = args[2] + "\\" + filename + ".bin";
                    File.WriteAllText(destinationFile, encryptedData);
                    return;
                }
                if (args[0] == "-bd")
                {
                    // decryption
                    string encFile = File.ReadAllText(args[1]);
                    byte[] data = rc2.decrypt(encFile);
                    File.WriteAllBytes(args[2], data);
                    return;
                }
            }
            else if (args[0] == "-se" || args[0] == "-sd")
            {
                //Stream
                Console.Write("Enter key: ");
                string? key = Console.ReadLine();
                if (args[0] == "-se")
                {
                    //encryption
                    Console.WriteLine("Encryption of " + args[1] + " to: " + args[2] + " ...");
                    byte[] content = File.ReadAllBytes(args[1]);
                    LFG lfg = new(key, content.Length);
                    byte[] encryptedData = lfg.encrypt(content);
                    string filename = Path.GetFileNameWithoutExtension(args[1]);
                    string destinationFile = args[2] + "\\" + filename + ".bin";
                    File.WriteAllBytes(destinationFile, encryptedData);
                    return;
                }
                if (args[0] == "-sd")
                {
                    //decryption
                    byte[] encFile = File.ReadAllBytes(args[1]);
                    LFG lfg = new(key, encFile.Length);
                    byte[] decryptedData = lfg.encrypt(encFile);
                    File.WriteAllBytes(args[2], decryptedData);
                    return;
                }
            }
        }
    }
}