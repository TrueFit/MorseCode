using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using SimpleLogging.Core;
using SimpleLogging.NLog;
using MorseCode.Lib;

namespace MorseCode
{
    class Program
    {

        static ILoggingService Logger; 

        static void Main(string[] args)
        {
            // Configure Unity
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ILoggingService, NLogLoggingService>(new InjectionConstructor("MorseCode"));
            container.RegisterType<ITranslator, MorseCodeTranslator>();
            
            // Configure logging and exception handling        
            Logger = container.Resolve<ILoggingService>();
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Logger.Info("Starting Morse Code translator...");
            
            // check for a filename passed into the command line
            if (args.Length != 1)
            {
                Logger.Info("Usage: MorseCode.exe <filename>");
                Logger.Info("Hit any key to exit.");
                Console.ReadKey();
                Environment.Exit(1);
            }
            
            ITranslator translator = container.Resolve<ITranslator>();
            var output = translator.TranslateFile(args[0]);
            Logger.Info("Morse Code Translator Output");
            Logger.Info(output);

            Logger.Info("Exiting Morse Code translator...");
            Logger.Info("Hit any key to exit.");
            Console.ReadKey();
        }


        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Error((Exception)e.ExceptionObject);
            Environment.Exit(1);
        }

        //private Dictionary<string, string> Alphabet = new Dictionary<string, string>
        //{
        //    {"a", ".-"},
        //    {"b", "-..."},
        //    {"c", "-.-."},
        //    {"d", "-.."},
        //    {"e", "."},
        //    {"f", "..-."},
        //    {"g", "--."},
        //    {"h", "...."},
        //    {"i", ".."},
        //    {"j", ".---"},
        //    {"k", "-.-"},
        //    {"l", ".-.."},
        //    {"m", "--"},
        //    {"n", "-."},
        //    {"o", "---"},
        //    {"p", ".--."},
        //    {"q", "--.-"},
        //    {"r", ".-."},
        //    {"s", "..."},
        //    {"t", "-"},
        //    {"u", "..-"},
        //    {"v", "...-"},
        //    {"w", ".--"},
        //    {"x", "-..-"},
        //    {"y", "-.--"},
        //    {"z", "--.."}
        //};

      
    }
}
