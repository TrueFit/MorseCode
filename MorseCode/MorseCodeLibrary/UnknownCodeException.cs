using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoderLibrary
{
    /// <summary>
    /// UnknownCodeException    Used when the code found is not legal in the code. I.E. does not map to a alphanumeric value.
    /// </summary>
    public class UnknownCodeException : Exception
    {
        public UnknownCodeException()
        {
        }

        public UnknownCodeException(string message)
            : base(message)
        {
        }

        public UnknownCodeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// UnknownCode Should be set to the code from the encoded string that does not map.
        /// </summary>
        public String UnknownCode { set; get; }

    }
}
