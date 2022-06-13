using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Lab7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Knapsack knapsack = new Knapsack();
            /*      Generate keys     */
            if(args.Length == 1 && args[0] == "--generate-keys")
            {
                knapsack.generateKeyPairs();
            }
            /*      Sign data (with private key)  */
            else if (args.Length == 3 && args[0] == "-s")
            {
                knapsack.sign(args[1], args[2]);
            }
            /*      Verify signature (with public key)  */
            else if (args.Length == 3 && args[0] == "-v")
            {
                knapsack.verify(args[1], args[2]);
            }
            /*     Display program usage  */
            else
            {
                DisplayUsage();
            }
            return;
        }

        static void DisplayUsage()
        {
            Console.WriteLine("Usage:"); 
            Console.WriteLine("\tGenerate segnature Key pairs:\t--generate-keys");
            Console.WriteLine("\tSign document:     \t-s [Path to document] [Destination for signature]");
            Console.WriteLine("\tVerify signature:  \t-v [Path to signature] [Path to document]");
        }
    }
}
