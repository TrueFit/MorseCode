using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode.Lib
{
    public class TokenList : List<Token>
    {
        public override string ToString()
        {
            var outputString = new StringBuilder();
            foreach (Token t in this)
            {
                outputString.Append(t.Output);
            }
            return outputString.ToString();
        }
    }
}
