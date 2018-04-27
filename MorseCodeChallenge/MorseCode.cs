using System;
using System.IO;
using System.Linq;

namespace MorseCodeChallenge
{
    public class MorseCode
    {
        private readonly MorseTree _morseTree;
        private string[] _morseCode;

        public MorseCode()
        {
            _morseTree = new MorseTree();
            _morseCode = new string[0];
        }

        public void ReadFile(string pathToFile)
        {
            try
            {
                _morseCode = File.ReadAllLines(pathToFile);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }

        // converts the entire file to English line by line
        public string ConvertToEnglish()
        {
            var converted = "";
            for (var i = 0; i < _morseCode.Length; i++)
            {
                converted += ConvertNextLine(i) + "\n";
            }

            return converted;
        }

        // splits the line at break points and builds the converted string
        public string ConvertNextLine(int index)
        {
            // takes the next line and splits out each break
            var morseLetters = _morseCode[index].Split(new string[] {"||"}, StringSplitOptions.None);

            // build output string
            return morseLetters.Aggregate("", (current, letter) => current + ConvertLetter(letter, _morseTree.Root));
        }

        // uses recursion and a binary tree to find the correct letter
        public char ConvertLetter(string morseLetter, MorseTreeNode node)
        {
            if (string.IsNullOrEmpty(morseLetter))
                return node.Value;
            else
                return ConvertLetter(morseLetter.Length >= 1 ? morseLetter.Substring(1) : "",
                    morseLetter.ElementAt(0) == '-' ? node.Dash : node.Dot);
        }
    }
}
