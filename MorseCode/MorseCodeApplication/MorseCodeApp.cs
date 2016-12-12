using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoderLibrary.MorseCode;
using DecoderLibrary;

namespace MorseCodeApplication
{
    public class MorseCodeApp
    {
      public static int Main() 
      {
          var decoder = new MorseCodeInterpreter();
          var encodedString = "-..|---|--.";

          var decodedString = decoder.Translate(encodedString);
          System.Console.Out.WriteLine("string " + encodedString + "equals " + decodedString);
          return 0;
      }

    }
}
