using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Remove_Borderlands_3_Intro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool fileSelected = false;
        string fileName;
        string[] filesToDel = { "2KLOGO.MP4", "AMDLOGO.MP4", "GBXLOGO.MP4" };
        string pathToFiles = "OakGame\\Content\\Movies\\";

        OpenFileDialog ofd = new OpenFileDialog();

        private void Button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Borderlands 3 (Borderlands3.exe)|Borderlands3.exe";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                fileDirectory.Text = ofd.FileName;
                fileName = ofd.FileName;
                fileSelected = true;
                activityLog.AppendText("Selected file " + ofd.FileName + ".");
                activityLog.AppendText(Environment.NewLine);
                activityLog.AppendText(Environment.NewLine);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            bool failed = false;
            if (fileSelected)
            {
                string[] splitDir = fileName.Split('\\');
                string fileDir = "";
                for(int i = 0; i < splitDir.Length - 1; i++)
                {
                    fileDir += splitDir[i] + '\\';
                }
                foreach (string badFile in filesToDel)
                {
                    if (File.Exists(fileDir + pathToFiles + badFile))
                    {
                        File.Move(fileDir + pathToFiles + badFile, fileDir + pathToFiles + badFile + ".bak"); //Add ".bak" to file name
                        activityLog.AppendText("Renamed " + fileDir + pathToFiles + badFile + " to " + fileDir + pathToFiles + badFile + ".bak");
                        activityLog.AppendText(Environment.NewLine);
                        activityLog.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        failed = true;
                        activityLog.AppendText("Failed to rename file " + fileDir + pathToFiles + badFile + ".");
                        activityLog.AppendText(Environment.NewLine);
                        activityLog.AppendText(Environment.NewLine);
                        MessageBox.Show("Could not find file " + fileDir + pathToFiles + badFile + "! Are you sure you have not already removed it?", "Error removing intro", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                failed = true;
                MessageBox.Show("No file selected.", "No File Selected", MessageBoxButtons.OK);
            }
            if(!failed)
            {
                activityLog.AppendText("Done renaming files.");
                activityLog.AppendText(Environment.NewLine);
                activityLog.AppendText(Environment.NewLine);
                MessageBox.Show("All intro movies have been removed!", "Intro Removed Successfully", MessageBoxButtons.OK);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            bool failed = false;
            if (fileSelected)
            {
                string[] splitDir = fileName.Split('\\');
                string fileDir = "";
                for (int i = 0; i < splitDir.Length - 1; i++)
                {
                    fileDir += splitDir[i] + '\\';
                }
                foreach (string badFile in filesToDel)
                {
                    if (File.Exists(fileDir + pathToFiles + badFile + ".bak"))
                    {
                        System.Console.WriteLine("Renaming " + fileDir + pathToFiles + badFile + ".bak" + " to " + fileDir + pathToFiles + badFile + "...");
                        File.Move(fileDir + pathToFiles + badFile + ".bak", fileDir + pathToFiles + badFile); //Remove ".bak" from file name
                        activityLog.AppendText("Renamed " + fileDir + pathToFiles + badFile + ".bak" + " to " + fileDir + pathToFiles + badFile + ".");
                        activityLog.AppendText(Environment.NewLine);
                        activityLog.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        failed = true;
                        activityLog.AppendText("Failed to rename file " + fileDir + pathToFiles + badFile + ".bak" + ".");
                        activityLog.AppendText(Environment.NewLine);
                        activityLog.AppendText(Environment.NewLine);
                        MessageBox.Show("Could not find file " + fileDir + pathToFiles + badFile + ".bak! Are you sure you have deleted it?", "Error restoring intro", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                failed = true;
                MessageBox.Show("No file selected.", "No File Selected", MessageBoxButtons.OK);
            }
            if(!failed)
            {
                activityLog.AppendText("Done renaming files.");
                activityLog.AppendText(Environment.NewLine);
                activityLog.AppendText(Environment.NewLine);
                MessageBox.Show("All intro movies have been restored!", "Intro Restored Successfully", MessageBoxButtons.OK);
            }
        }
    }
}
