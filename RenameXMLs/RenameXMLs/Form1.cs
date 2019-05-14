using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace RenameXMLs
{
    public partial class Form1 : Form
    {
        private static int unwantedlong = 17;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;

            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd2 = new FolderBrowserDialog();
            fbd2.ShowNewFolderButton = true;

            DialogResult result = fbd2.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox2.Text = fbd2.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (Directory.Exists(textBox1.Text) && Directory.Exists(textBox2.Text))
                {
                    try
                    {
                        foreach (var srcPath in Directory.GetFiles(textBox1.Text))
                        {
                            string srcPathTemp = srcPath.Replace(textBox1.Text, textBox2.Text);
                            string trgtPath = srcPathTemp.Substring(0, srcPathTemp.Length - unwantedlong);
                            int lngth = trgtPath.Length;
                            string trgtPathXML = trgtPath.Insert(lngth, ".xml");


                            File.Copy(srcPath, trgtPathXML, true);

                        }
                        MessageBox.Show("Renamed All Files...");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter directory!");
                //MessageBox.Show("Please enter directory!", MessageBoxIcon.Error );
            }
        }
    }
}
