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
    public partial class AddProjectFrm : Form
    {
        public string ProjName = "";

        public AddProjectFrm()
        {
            InitializeComponent();
        }

        private void AddProject_Load(object sender, EventArgs e)
        {

        }

        private void Cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Ok(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("please give a name");
                return;
            }
            if (ItemDB.Coll.ContainsKey(textBox1.Text))
            {
                MessageBox.Show("Already exists");
                return;
            }

            ProjName = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
