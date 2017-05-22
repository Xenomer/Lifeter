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
    public partial class PresentationForm : Form
    {
        public PresentationForm()
        {
            InitializeComponent();
            listView1.Columns[1].Width = 610;
        }

        private void PresentationForm_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
        public void UpdateList()
        {
            listView1.Items.Clear();
            foreach(ListViewItem li in MainFrm.items)
            {
                listView1.Items.Add((ListViewItem)li.Clone());
            }
        }

        private void FrmClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
