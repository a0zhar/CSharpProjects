using System;
using System.IO;
namespace ConsoleApp4 {
    internal class Program {
        private static void Main(string[] args) {
            Console.Title = "Simple C# Console (File to Hex) Converter - made by AzharCQ";

            Console.Write("Drag and Drop file here :-");
            string path2File = Console.ReadLine();
            byte[] bytes = File.ReadAllBytes(path2File);
            string hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", " ");
            Console.WriteLine(hexString);

            Console.ReadKey();

        }
    }
}
