using Niflib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;

namespace Nifexe
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                var srcPath = args[0];
                var dstPath = args[1];
                using var br = new BinaryReader(File.OpenRead(srcPath));
                var niFile = new NiFile(br);
                niFile.Save(dstPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}