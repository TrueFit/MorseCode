using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseCode
{
    public class FileReader
    {
        public FileReader() { }

        public string GetFileToOpen()
        {
            string pathToFile = "";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Text File";
            dialog.Filter = "TXT files|*.txt";
            dialog.InitialDirectory  = @"C:\";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(dialog.FileName.ToString());
                pathToFile = dialog.FileName;
            }

            return pathToFile;
        }

        public List<string> OpenReadFile(string pathToFile)
        {
            List<string> fileData = new List<string>();

            if (File.Exists(pathToFile))
            {
                foreach (var line in File.ReadAllLines(pathToFile))
                {
                    fileData.Add(line);
                }

            }
            return fileData;
        }
    }
}
