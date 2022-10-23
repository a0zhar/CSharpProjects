using System;
using System.IO;
namespace ConsoleApp4 {
    internal class Program {
        private static void Main(string[] args) {
            Console.Title = "Simple C# Console (File to Byte Array) Converter - made by a0zhar";
            Console.Write("Drag and Drop file here :-");
         
            byte[] bytes = File.ReadAllBytes(Console.ReadLine());
            Console.Clear();

            foreach (byte o in bytes) {
                Console.Write(o + ",");
            }
            Console.ReadKey();

        }
    }
}
