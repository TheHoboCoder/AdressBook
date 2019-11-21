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
        bool addingMode = false;
        Point point = new Point();

        public MainForm()
        {
            InitializeComponent();
            if (!Database.Connect())
            {
                MessageBox.Show("Ошибка подключения к базе данных");
                this.Close();
            }
            Database.getUsers();
            Database.getDepData();
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

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            point.X = e.Location.X;
            point.Y = e.Location.Y;
            pictureBox1.Refresh();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            DepEdit ed = new DepEdit();
            ed.point = point;
            ed.ShowDialog();
            if(ed.DialogResult == DialogResult.OK)
            {
                addingMode = false;
            }
        }

        private void AddDep_Click(object sender, EventArgs e)
        {
            addingMode = !addingMode;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (addingMode)
            {
                using (SolidBrush br = new SolidBrush(Color.Yellow))
                {
                    e.Graphics.FillEllipse(br, point.X - 15, point.Y - 15, 15 * 2, 15 * 2);
                    
                }
            }
        }
            
    }
}
