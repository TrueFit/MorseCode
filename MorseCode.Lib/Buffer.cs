using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode.Lib
{
    public class Buffer
    {
        protected readonly string content;
        private int _position = -1;

        public int Position
        {
            get
            {
                return _position;
            }
        }

        public Buffer(string inputString)
        {
            content = inputString;
        }

        public char NextChar()
        {
            _position++;
            if (_position >= content.Length)
                return '\0';
            else
                return content[_position];
        }

        public char Peek()
        {
            if ((_position+1) >= content.Length)
                return '\0';
            else
                return content[_position+1];
        }

    }
}
