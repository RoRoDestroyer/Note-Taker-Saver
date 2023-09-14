using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        private static string note = ""; // Declare note at the class level.

        static void Main(string[] args)
        {
            Console.Write("Write note: ");
            note = GetSecureInput(); // Assign the value to the class-level note variable.

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
                    // Append the character to the input.
                    Console.Write("*");
                    input += key.KeyChar;
                }
            } while (true);

            return input;
        }

        static void SaveToFile(string content)
        {
            string filePath = @"C:\Users\rags2\Downloads\notes.txt"; // Put path to txt document

            File.WriteAllText(filePath, content);

            Console.WriteLine("String saved to file successfully!");

            Console.Write("Do you want to open the file? (Y/N): ");
            string openChoice = Console.ReadLine();

            if (openChoice != null && openChoice.ToUpper() == "Y")
            {
                // Open the saved file with the default associated program (e.g., Notepad).
                Process.Start(filePath);
            }

            Console.ReadLine();
        }
    }
}
