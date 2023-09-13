using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        private static string note = ""; 

        static void Main(string[] args)
        {
            Console.Write("Write note: ");
            note = GetSecureInput(); 

            Console.Clear();

            Console.Write("Note Taken! Press Enter to view your note!");
            Console.ReadLine();

            Console.WriteLine(note + " Press Enter to exit or press S to save to files!");
            string key = Console.ReadLine();
            if (key != null && (key.ToUpper() == "S" || key.ToUpper() == "S"))
            {
                SaveToFile(note);
            }
        }

        static string GetSecureInput()
        {
            string input = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (char.IsLetterOrDigit(key.KeyChar) || char.IsWhiteSpace(key.KeyChar) || char.IsPunctuation(key.KeyChar))
                {
                    // Append the character to the input.
                    Console.Write("*");
                    input += key.KeyChar;
                }
            } while (true);

            return input;
        }

        static void SaveToFile(string content)
        {
            string filePath = @"C:\Users..."; //put path to txt document

            File.WriteAllText(filePath, content);

            Console.WriteLine("Note saved to file successfully");
            Console.ReadLine();
        }
    }
}
