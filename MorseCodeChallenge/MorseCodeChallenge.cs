using System;
using System.Diagnostics;

namespace MorseCodeChallenge
{
    public class MorseCodeChallenge
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter full path to file: ");
            var pathToFile = Console.ReadLine();
            var morseCode = new MorseCode();

            // run through binary tree implementation
            morseCode.ReadFile(pathToFile);
            var converted = morseCode.ConvertToEnglish();

            Console.WriteLine(converted);

            Console.WriteLine("Press any key to exit");

            Console.ReadKey();
        }
    }
}
