using System;
using System.Diagnostics;
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

            Console.Write("Note Taken! Press Enter to view your note or press S to save and open the file after saving: ");
            string key = Console.ReadLine();

            if (key != null && key.ToUpper() == "S")
            {
                SaveToFile(note);
            }
            else
            {
                Console.WriteLine(note + " | Press Enter to exit.");
                Console.ReadLine();
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
                    Console.Write("*");
                    input += key.KeyChar;
                }
            } while (true);

            return input;
        }

        static void SaveToFile(string content)
        {
            string filePath = @"C:\Users\rags2\Downloads\notes.txt"; // Put path to txt document

            File.AppendAllText(filePath, content + "\n\n");

            Console.WriteLine("Note saved to file successfully!");

            Console.Write("Do you want to open the file? (Y/N): ");
            string openChoice = Console.ReadLine();

            if (openChoice != null && openChoice.ToUpper() == "Y")
            {
                Process.Start(filePath);
            }

            Console.ReadLine();
        }
    }
}
