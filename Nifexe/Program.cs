using Niflib;
using System;
using System.IO;

namespace Nifexe
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                using var br = new BinaryReader(File.OpenRead(args[0]));
                new NiFile(br).PrintNifTree();

                Console.Write("nd of nif file. Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
