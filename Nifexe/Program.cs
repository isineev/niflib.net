using Niflib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Nifexe
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                try
                {
                    var fileStream = File.OpenRead(args[0]);
                    using var binaryReader = new BinaryReader(fileStream);
                    new NiFile(binaryReader).Save(args[1]);

                    var hash0 = SHA1.Create().ComputeHash(File.ReadAllBytes(args[0])).Select(b => $"{b:x2}").Aggregate("", (r, i) => r + i);
                    var hash1 = SHA1.Create().ComputeHash(File.ReadAllBytes(args[1])).Select(b => $"{b:x2}").Aggregate("", (r, i) => r + i);

                    Console.WriteLine($"Source file: {args[0]}");
                    Console.WriteLine($"SHA1={hash0}");
                    Console.WriteLine($"Target file: {args[1]}");
                    Console.WriteLine($"SHA1={hash1}");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Usage: nifexe <file-to-read> <file-to-save>");
            }
        }
    }
}