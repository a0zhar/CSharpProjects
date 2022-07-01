using System;
using System.IO;
namespace ConsoleApp4 {
    internal class Program {
        private static void Main(string[] args) {
            Console.Title = "Simple C# Console (File to Byte Array) Converter - made by AzharCQ";

            Console.Write("Drag and Drop file here :-");
            string path2File = Console.ReadLine();
            byte[] bytes = File.ReadAllBytes(path2File);

            Console.Write("Include '0x' before bytes? > (Y/N) :");
            string include0x = Console.ReadLine();

            Console.Clear();
            int i = 0;

            foreach (byte o in bytes) {
                Console.Write($"{(include0x == "Y" ? "0x" : "")}{o}{(++i < bytes.Length ? ", " : "")}");
            }

            Console.ReadKey();

        }
    }
}
