using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode.Lib
{
    public class Token
    {
        public KindEnum Kind;
        public int CharacterPosition;
        public string Value;
        public string Output;
    }

    public enum KindEnum
    {
        Letter = 1,
        Break = 2,
        Newline = 3,
        Space = 4
    }
}
