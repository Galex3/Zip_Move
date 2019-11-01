using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Zip_Move
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxInput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            textBoxInput.Text = folderBrowserDialog.SelectedPath;
            checkEmptyBox();
        }

        private void textBoxOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            textBoxOutput.Text = folderBrowserDialog.SelectedPath;
            checkEmptyBox();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string pathFileName = textBoxInput.Text + ".zip";
            ZipFile.CreateFromDirectory(textBoxInput.Text, pathFileName, CompressionLevel.Optimal, false);
            File.Move(pathFileName, textBoxOutput.Text + pathFileName.Substring(textBoxInput.Text.LastIndexOf("\\")));
        }

        private void checkEmptyBox()
        {
            if (textBoxInput.Text != "Click here to select file/folder" && textBoxOutput.Text != "Click here to select folder") {
                buttonStart.Enabled = true;
            }
        }
    }
}
