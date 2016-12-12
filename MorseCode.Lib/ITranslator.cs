using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode.Lib
{
    public interface ITranslator
    {
        string Translate(string inputString);
        string TranslateFile(string filename);
    }
}
