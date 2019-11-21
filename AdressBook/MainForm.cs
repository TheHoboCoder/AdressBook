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
    public partial class MainForm : Form
    {
        bool isAdmin = false;
        public MainForm()
        {
            InitializeComponent();
            if (!Database.Connect())
            {
                MessageBox.Show("Ошибка подключения к базе данных");
                this.Close();
            }
            Database.getUsers();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm();
            form.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isAdmin)
            {
                LogForm form = new LogForm();
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    AddUserBtn.Visible = true;
                    isAdmin = true;
                    button2.Text = "Выход";
                }
            }
            else
            {
                button2.Text = "Вход администратором";
                isAdmin = false;
                AddUserBtn.Visible = false;
            }
            
        }
    }
}
