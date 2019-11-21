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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            
        }
        long depId = -1;
        public AddForm(long depId)
        {
            InitializeComponent();
            this.depId = depId;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            Database.getDeps();
            
            depCombo.DataSource = Database.DepTable;
            depCombo.DisplayMember = "name";
            depCombo.ValueMember = "id_department";
            if (depId != -1)
            {
                depCombo.SelectedValue = depId;
            }
            Database.getRanks();
            rankCombo.DataSource = Database.RankTable;
            rankCombo.DisplayMember = "rank_name";
            rankCombo.ValueMember = "id_rank";
        }

        private void addDep_Click(object sender, EventArgs e)
        {
            DepEdit f = new DepEdit();
            f.ShowDialog();
        }

        private void addDol_Click(object sender, EventArgs e)
        {
            Rank r = new Rank();
            r.ShowDialog();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(nameTxt.Text!="" && famTxt.Text!="" && octhTxt.Text!="" && emailTxt.Text!="" && maskedTextBox1.Text!="")
            {
                long id = Database.addUser(Convert.ToInt32(depCombo.SelectedValue), Convert.ToInt32(rankCombo.SelectedValue), famTxt.Text, nameTxt.Text, octhTxt.Text, emailTxt.Text, maskedTextBox1.Text);
                if (id == -1)
                {
                    MessageBox.Show("не удалось добавить");
                }
                Database.getUsers();
                this.Close();
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }
    }
}
