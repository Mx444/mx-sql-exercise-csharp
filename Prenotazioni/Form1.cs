using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using MetroFramework;

namespace Prenotazioni
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DB File

            string file1 = @"Database1.mdf";
            string file2 = @"Database1_log.ldf";
            string Dir = "";
            string NewDir = @"C:\SQLDB";
            string DestDir1 = System.IO.Path.Combine(NewDir, file1);
            string DestDir2 = System.IO.Path.Combine(NewDir, file2);
            string sourceFile1 = System.IO.Path.Combine(Dir, file1);
            string sourceFile2 = System.IO.Path.Combine(Dir, file2);
            if (!System.IO.Directory.Exists(NewDir))
            {
                System.IO.Directory.CreateDirectory(NewDir);
            }
            if (!System.IO.File.Exists(file1))
            {
                System.IO.File.Copy(sourceFile1, DestDir1, true);
            }
            if (!System.IO.File.Exists(file2))
            {
                System.IO.File.Copy(sourceFile2, DestDir2, true);
            }
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            Form2 Sezione1 = new Form2();
            Sezione1.Show();
            this.Hide();
        }
    }
}
