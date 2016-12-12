using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoderLibrary
{
    public interface Interpreter
    {
        String Translate(String stringToInterpret);
    }
}
