﻿using System;
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
        public UserView()
        {
            InitializeComponent();
            table.DataSource = Database.filterUser;

        }
    }
}
