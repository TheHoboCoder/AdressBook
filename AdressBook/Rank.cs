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
    public partial class Rank : Form
    {
        public Rank()
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
                Database.addRank(nameTxt.Text.Trim());
                Database.getRanks();
                this.Close();
            }
        }
    }
}
