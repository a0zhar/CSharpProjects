using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;

/*

█▀▀ █▀▀█ █▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █▀▀▄ 　 █▀▀▄ █──█ 　 █▀▀█ █▀▀█ ▀▀█ █──█ █▀▀█ █▀▀█
█── █▄▄▀ █▀▀ █▄▄█ ──█── █▀▀ █──█ 　 █▀▀▄ █▄▄█ 　 █▄▄█ █▄▀█ ▄▀─ █▀▀█ █▄▄█ █▄▄▀
▀▀▀ ▀─▀▀ ▀▀▀ ▀──▀ ──▀── ▀▀▀ ▀▀▀─ 　 ▀▀▀─ ▄▄▄█ 　 ▀──▀ █▄▄█ ▀▀▀ ▀──▀ ▀──▀ ▀─▀▀
Ref: https://www.bleepingcomputer.com/news/security/new-c-ransomware-compiles-itself-at-runtime/
USING: .NET framework 4.8
Mode: Debug, Any CPU
 */

namespace ConsoleApp11 {

    internal class Program {

        #region hidden

        /// <summary>
        /// USED TO COMPILE A PAYLOAD INTO MEMORY WITHOUT CREATING AN EXECUTABLE,
        /// IT CAN EITHER BE A GIVEN BYTE ARRAY, OR RAW STRING
        /// </summary>
        /// <param name="code">The Payload Source u want to compile, can either be given as a byte array or raw string just remember to do Encoding.ASCII.GetString(array here) if u decide to use an array..</param>
        /// <param name="ns">Namespace inside payload</param>
        /// <param name="cl">Class within the namespace</param>
        /// <param name="func">Function inside the payload u want to be executed once compiled</param>

        #endregion hidden

        public static byte[] helloWorld = { 117, 115, 105, 110, 103, 32, 83, 121, 115, 116, 101, 109, 59, 110, 97, 109, 101, 115, 112, 97, 99, 101, 32, 72, 101, 108, 108, 111, 87, 111, 114, 108, 100, 32, 123, 32, 112, 117, 98, 108, 105, 99, 32, 99, 108, 97, 115, 115, 32, 72, 101, 108, 108, 111, 87, 111, 114, 108, 100, 67, 108, 97, 115, 115, 32, 123, 32, 112, 117, 98, 108, 105, 99, 32, 115, 116, 97, 116, 105, 99, 32, 118, 111, 105, 100, 32, 77, 97, 105, 110, 40, 41, 32, 123, 32, 67, 111, 110, 115, 111, 108, 101, 46, 70, 111, 114, 101, 103, 114, 111, 117, 110, 100, 67, 111, 108, 111, 114, 32, 61, 32, 67, 111, 110, 115, 111, 108, 101, 67, 111, 108, 111, 114, 46, 82, 101, 100, 59, 32, 67, 111, 110, 115, 111, 108, 101, 46, 87, 114, 105, 116, 101, 76, 105, 110, 101, 40, 34, 84, 72, 73, 83, 32, 67, 79, 77, 80, 73, 76, 69, 68, 32, 73, 78, 84, 79, 32, 77, 69, 77, 79, 82, 89, 44, 32, 72, 65, 72, 65, 72, 65, 72, 32, 72, 69, 76, 76, 79, 32, 87, 79, 82, 76, 68, 32, 34, 41, 59, 32, 67, 111, 110, 115, 111, 108, 101, 46, 82, 101, 97, 100, 76, 105, 110, 101, 40, 41, 59, 32, 125, 32, 125, 32, 125, 10 };

        public static void MemCompile(string code, string ns, string cl, string func) {
            CompilerResults MemoryResult = new CSharpCodeProvider().CompileAssemblyFromSource(
                new CompilerParameters() {
                    GenerateInMemory = true
                }, code);

            if (MemoryResult.Errors.HasErrors) {
                string text = "Compile error: ";
                foreach (CompilerError compilerError in MemoryResult.Errors)
                    text = $"{text}{compilerError}\n";

                throw new Exception(text);
            }

            Type type = MemoryResult.CompiledAssembly.GetModules()[0].GetType(ns + "." + cl);
            MethodInfo methodInfo = type.GetMethod(func);
            methodInfo.Invoke(null, null);
        }

        private static void Main(string[] args) =>
            MemCompile(
                code: Encoding.ASCII.GetString(helloWorld),
                ns: "HelloWorld",
                cl: "HelloWorldClass",
                func: "Main"
             );
    }
}