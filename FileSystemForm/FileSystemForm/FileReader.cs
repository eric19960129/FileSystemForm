using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemForm
{
    public partial class FileReader : Form
    {
        public FileReader(string path)
        {
            InitializeComponent();

            pictureBox1.Visible = false;
            textBox1.Visible = false;

            if ("*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.gif;*.tif;*.tiff".Contains(System.IO.Path.GetExtension(path)))
            {
                this.Width = Image.FromFile(path).Width + 17;
                this.Height = Image.FromFile(path).Height + 40;

                pictureBox1.Width = Image.FromFile(path).Width;
                pictureBox1.Height = Image.FromFile(path).Height;
                pictureBox1.Image = Image.FromFile(path);

                pictureBox1.Visible = true;
            }
            else if ("*.txt".Contains(System.IO.Path.GetExtension(path)))
            {
                string readTxt = "";
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (streamReader.Peek() > 0)
                    {
                        readTxt += streamReader.ReadLine() + Environment.NewLine;
                    }
                }
                textBox1.Text = readTxt;
                textBox1.Visible = true;
            }
        }
    }
}
