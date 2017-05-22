using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lifeter
{
    public partial class SyncOpt : Form
    {
        public SyncOpt()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MainFrm.syncPath = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.CheckFileExists = false;
            sfd.CheckPathExists = true;
            sfd.CreatePrompt = false;
            sfd.OverwritePrompt = false;
            sfd.RestoreDirectory = false;
            sfd.Filter = "Lifeter Sync File (*.lifsnc)|*.lifsnc";
            sfd.Title = "Select sync path";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = sfd.FileName;
                MainFrm.syncPath = textBox1.Text;
            }
        }

        new private void Closing(object sender, FormClosingEventArgs e)
        {
            FileSaver.SaveCurrent();
        }

        private void SyncOpt_Load(object sender, EventArgs e)
        {
            textBox1.Text = MainFrm.syncPath;
        }
    }
}
