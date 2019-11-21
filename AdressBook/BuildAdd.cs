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
    public partial class BuildAdd : Form
    {
        public List<Point> points;

        public BuildAdd()
        {

            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "")
            {
                Building b = new Building();
                b.Name = nameTxt.Text.Trim();
                b.setPathPoints(points);
                if (Database.AddBuilding(b))
                {
                    this.Close();
                }
            }
        }
    }
}
