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
    public partial class AddItemFrm : Form
    {
        public string itemName = "";
        public Color color = Color.White;

        public AddItemFrm()
        {
            InitializeComponent();
        }

        private void AddItemFrm_Load(object sender, EventArgs e)
        {
            textBox1.Text = itemName;
            button2.BackColor = color;
        }

        private void Ok(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("please give a name");
                return;
            }
            //if (ItemDB.Coll[MainFrm.currProject].Contains(textBox1.Text))
            //{
            //    MessageBox.Show("Already exists");
            //    return;
            //}

            itemName = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void Cancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void GetColor(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
            button2.BackColor = color;
        }
    }
}
