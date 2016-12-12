using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleLogging.Core;

namespace MorseCode.Lib
{
    public class MorseCodeTranslator : ITranslator
    {
        #region Private Variables
        private const char DOT = '.';
        private const char DASH = '-';
        private const char BREAK = '|';
        private const char NEWLINE = '\n';
        private const char EOF = '\0';

        private Dictionary<string, string> morseCodeLookup = new Dictionary<string, string> 
        {
            {".-", "a"},
            {"-...", "b"},
            {"-.-.", "c"},
            {"-..", "d"},
            {".", "e"},
            {"..-.", "f"},
            {"--.", "g"},
            {"....", "h"},
            {"..", "i"},
            {".---", "j"},
            {"-.-", "k"},
            {".-..", "l"},
            {"--", "m"},
            {"-.", "n"},
            {"---", "o"},
            {".--.", "p"},
            {"--.-", "q"},
            {".-.", "r"},
            {"...", "s"},
            {"-", "t"},
            {"..-", "u"},
            {"...-", "v"},
            {".--", "w"},
            {"-..-", "x"},
            {"-.--", "y"},
            {"--..", "z"},
            {".----", "1"},
            {"..---", "2"},
            {"...--", "3"},
            {"....-", "4"},
            {".....", "5"},
            {"-....", "6"},
            {"--...", "7"},
            {"---..", "8"},
            {"----.", "9"},
            {"-----", "0"}
        };
        #endregion
        
        protected ILoggingService Logger { get; set; }

        /// <summary>
        /// Constructor for the Morse code translator class with DI
        /// </summary>
        /// <param name="logger"></param>
        public MorseCodeTranslator(ILoggingService logger)
        {
            Logger = logger;
        }

        /// <summary>
        /// TranslateFile method to take a filename containing the Morse code to translate, and return it as a string
        /// </summary>
        /// <param name="filename">Name of text file containing Morse code for translation</param>
        /// <returns>string</returns>
        public string TranslateFile(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new ArgumentNullException("filename");
            if (!File.Exists(filename))
                throw new ApplicationException(string.Format("File does not exist. {0}", filename));

            // open the file and pass the string to the overloaded method
            // Let .Net take care of the figuring out the file encoding and creating our string
            var inputStream = File.ReadAllText(filename);

            return Translate(inputStream);
        }

        /// <summary>
        /// Overloaded Translate method which takes a stream to allow the calling application to take care of its own file I/O
        /// </summary>
        /// <param name="inputStream">String containing Morse code for translation</param>
        /// <returns>string</returns>
        public string Translate(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                throw new ArgumentNullException("inputString");

            Logger.Info("Morse Code Translator Input");
            Logger.Info(inputString);

            TokenList tokens = Tokenize(inputString);
           
            // Evaluate the tokens to produce the output value
            foreach (Token t in tokens)
            {
                switch (t.Kind)
                {
                    case KindEnum.Break :
                        t.Output = string.Empty;
                        break;
                    case KindEnum.Space :
                        t.Output = " ";
                        break;
                    case KindEnum.Letter :
                        string lookupResult;
                        if (morseCodeLookup.TryGetValue(t.Value, out lookupResult))
                        {
                            t.Output = lookupResult;
                        }
                        else
                        {
                            // Handle case where the letter isn't valid Morse code
                            Logger.Warning("Token was not found to valid Morse code: {0}", t.Value);
                        }
                        break;
                    case KindEnum.Newline:
                        t.Output = "\n";
                        break;
                }
            }
            
            // Finally, iterate through the list of tokens and output our final string
            // This could have just as easily been accomplished in the previous loop and if performance is an issue,
            // I would consider consolidating but for the purposes of this exercise I wanted distinct steps to make debugging
            // a little easier and also to have a fully filled out list of tokens in case we want to process it differently.
            return tokens.ToString();
        }

        /// <summary>
        /// Tokenizing function
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>List of tokens
        /// Can return ApplicationException
        /// </returns>
        protected TokenList Tokenize(string inputString)
        {
            // Make the tolkenizing a tad easier by replacing \r\n with \n
            inputString = inputString.Replace("\r\n", "\n");

            // Initialize variables used in tokenizer
            var tokens = new TokenList();
            var inputBuffer = new Buffer(inputString);
            var token = new Token();
            char curChar = inputBuffer.NextChar();

            // Simple tokenizer
            // Parse the input into tokens using | and newline as separators
            while (curChar != EOF)
            {
                switch (curChar)
                {
                    case DOT:
                    case DASH:
                        string tokenBuffer = string.Empty;
                        while (curChar == DOT || curChar == DASH)
                        {
                            tokenBuffer += curChar;
                            curChar = inputBuffer.NextChar();
                        }
                        token = new Token
                        {
                            Kind = KindEnum.Letter,
                            CharacterPosition = inputBuffer.Position,
                            Value = tokenBuffer
                        };
                        break;
                    case '|':
                        if (inputBuffer.Peek() == '|')
                        {
                            // this is a double break (space)
                            token = new Token
                            {
                                Kind = KindEnum.Space,
                                CharacterPosition = inputBuffer.Position,
                                Value = "||"
                            };
                            // consume the current char since it is part of the double break
                            curChar = inputBuffer.NextChar();
                        }
                        else
                        {
                            // this is a single break
                            // we could just as easily ignore single breaks and just use them as a delimeter but
                            // we will preserve them as a token in case we need them later
                            token = new Token
                            {
                                Kind = KindEnum.Break,
                                CharacterPosition = inputBuffer.Position,
                                Value = curChar.ToString()
                            };
                        }
                        curChar = inputBuffer.NextChar();
                        break;
                    case '\n':
                        token = new Token
                        {
                            Kind = KindEnum.Newline,
                            CharacterPosition = inputBuffer.Position,
                            Value = curChar.ToString()
                        };
                        curChar = inputBuffer.NextChar();
                        break;
                    default:
                        // if we hit an unexpected character, abort the process and log an error
                        throw new ApplicationException(string.Format("Unexpected character at position {0}", inputBuffer.Position));
                }
                tokens.Add(token);
            }
            return tokens;
        }
    }
}
