using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;//Image
using System.IO;//StreamReader、Path
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemForm
{
    public partial class Form_File : Form
    {
        public Form_File()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select File";
            //File.Filter | 分隔線不能有空格(會導致無法呈現)
            openFileDialog.Filter = "photo files (*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.gif;*.tif;*.tiff)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.gif;*.tif;*.tiff|txt files (*.txt)|*.txt|office files (*.docx;*.ppt;*.xlsx)|*.docx;*.ppt;*.xlsx|All files (*.*)|*.*";
            if(openFileDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK && openFileDialog.FileName != null) 
            {
                /*
                 * GetFullPath()    //取得絕對路徑  == openFileDialog.FileName == 絕對路徑(包含檔名)
                 * GetDirectoryName //取得路徑      == 不包含檔名
                 * GetExtension()   //取得副檔名 
                 * GetFileNameWithoutExtension()    //取得檔案名稱，不要副檔名
                 * GetFileName()    //取得檔案名稱
                 */
                label_File.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                FileReader fileReader = new FileReader(openFileDialog.FileName);
                fileReader.ShowDialog();
            }
        }
    }
}
