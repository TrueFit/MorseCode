using System.Diagnostics.Metrics;
using System.IO.Enumeration;

namespace MorseCodeProject
{
    internal class Program
    {
        //This program uses a dictionary to translate morse code read in from a file into english
        static void Main(string[] args)
        {
            //morseCode dictionary contains the alphabet and numbers 1-9
            Dictionary<string, char> morseCode = new Dictionary<string, char>()
            {               
                {".-", 'A'},
                {"-...", 'B'},
                {"-.-.", 'C'},
                {"-..", 'D'},
                {".", 'E'},
                {"..-.", 'F'},
                {"--.", 'G'},
                {"....", 'H'},
                {"..", 'I'},
                {".---", 'J'},
                {"-.-", 'K'},
                {".-..", 'L'},
                {"--", 'M'},
                {"-.", 'N'},
                {"---", 'O'},
                {".--.", 'P'},
                {"--.-", 'Q'},
                {".-.", 'R'},
                {"...", 'S'},
                {"-", 'T'},
                {"..-", 'U'},
                {"...-", 'V'},
                {".--", 'W'},
                {"-..-", 'X'},
                {"-.--", 'Y'},
                {"--..", 'Z'},
                {"-----", '0'},
                {".----", '1'},
                {"..---", '2'},
                {"...--", '3'},
                {"....-", '4'},
                {".....", '5'},
                {"-....", '6'},
                {"--...", '7'},
                {"---..", '8'},
                {"----.", '9'},
                {"", ' ' }
            };

            //File MorseText is embedded within the program
            string filePath = "../../../MorseText.txt";

            // Read the file line by line
            string line = "";
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                {                    
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Split the line into words
                        string[] words = line.Split("||");

                        // Translate each word into English
                        foreach (string code in words)
                        {
                            Console.Write(morseCode[code]); //print the translated letter
                            Console.Write(" "); //add space in between letters
                        }
                        Console.WriteLine();
                    }
                }
            }           
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            if (reader != null)
            {
                reader.Close(); //close file when file is fully read through
            }

        }   

    }    
}