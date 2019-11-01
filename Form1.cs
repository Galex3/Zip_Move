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
            string inputPath = textBoxInput.Text + ".zip";
            string outputPath = textBoxOutput.Text + inputPath.Substring(textBoxInput.Text.LastIndexOf("\\"));
            string[] files = Directory.GetFiles(textBoxOutput.Text);
            foreach (string file in files)
            {
                if (file == outputPath)
                {
                    File.Delete(outputPath);
                }
            }
            try
            {
                ZipFile.CreateFromDirectory(textBoxInput.Text, inputPath, CompressionLevel.Optimal, false);
            }
            catch (IOException)
            {
                MessageBox.Show("Input/Output folder no longer exist(s)! Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            File.Move(inputPath, outputPath);
        }

        private void checkEmptyBox()
        {
            if (textBoxInput.Text != "Click here to select file/folder" && textBoxOutput.Text != "Click here to select folder")
            {
                buttonStart.Enabled = true;
            }
        }
    }
}
