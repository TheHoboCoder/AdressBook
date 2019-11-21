using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressBook
{
    public partial class UserView : UserControl
    {
        public long depId {get;set;}
        public UserView(bool isAdmin)
        {
            InitializeComponent();
            table.DataSource = Database.filterUser;
            AddButton.Enabled = isAdmin;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm(depId);
            f.ShowDialog();
            
        }
    }
}
