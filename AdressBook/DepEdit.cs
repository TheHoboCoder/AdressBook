using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressBook
{
    public partial class DepEdit : Form
    {
        public Point point { get; set; }

        public DepEdit()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "")
            {
                bool res = Database.addDep(nameTxt.Text.Trim(),point);
                Database.getDeps();
                if (res)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {

                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
