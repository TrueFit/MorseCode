using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MorseCode
{
    public partial class Form1 : Form
    {
        private string _pathToFile;
        private List<string> _fileData;
        private string _testFilePath = "..\\..\\TestFile\\MorseCodeTest.txt";
        private FileReader reader = new FileReader();
        private StringBuilder output = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            _pathToFile = reader.GetFileToOpen();
            _fileData = reader.OpenReadFile(_pathToFile);
        }

        private void btnUseTestFile_Click(object sender, EventArgs e)
        {
            _fileData = reader.OpenReadFile(_testFilePath);           
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            MorseCodeConverter codeConverter = new MorseCodeConverter();
            OutputWindow.Text = codeConverter.ConvertFileDataToText(_fileData);
        }
    }
}
