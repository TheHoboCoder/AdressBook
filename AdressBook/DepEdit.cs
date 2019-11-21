using AdressBook.Data;
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
        public long BuilId { get; set; }

        public Building b { get; set; }

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
                if(b.AddMarker(nameTxt.Text.Trim(), point))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении");
                }
                //bool res = Database.addDep(nameTxt.Text.Trim(),point);
                //Database.getDeps();
                //if (res)
                //{
                //    DialogResult = DialogResult.OK;
                //    this.Close();
                //}
                //else
                //{

                //}
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
