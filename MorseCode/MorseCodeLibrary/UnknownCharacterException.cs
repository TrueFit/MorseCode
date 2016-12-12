using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoderLibrary
{
    /// <summary>
    /// UnknownCharacterException  thrown when a character in the encoding is not legal. 
    /// </summary>
    public class UnknownCharacterException : Exception
    {
        public UnknownCharacterException()
        {
        }

        public UnknownCharacterException(string message)
            : base(message)
        {
        }

        public UnknownCharacterException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// UnknownCharacter  Should be set to the unknown character found in the encoded string. 
        /// </summary>
        public char UnknownCharacter { set; get; }

    }
}
