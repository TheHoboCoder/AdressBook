﻿using AdressBook.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        enum Mode
        {
            ADD_BUILDING,
            ADD_MARKER,
            SELECT
        }

        Mode mode = Mode.SELECT;
        Building curBuilding;
        Marker curMarker,highlight;
        List<Point> curPoints;

        UserView userView;

        bool isMarkerVisible = true;

        public MainForm()
        {
            InitializeComponent();
            if (!Database.Connect())
            {
                MessageBox.Show("Ошибка подключения к базе данных");
                this.Close();
            }
            Database.getUsers();
            table.DataSource = Database.UserTable;
            //Database.getDepData();
            Database.loadBuildingData();
            ShowAll.Enabled = false;
            AddDep.Enabled = AddBuilding.Enabled = false;
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
                    //AddUserBtn.Visible = true;
                    AddDep.Enabled = AddBuilding.Enabled = true;
                    isAdmin = true;
                    button2.Text = "Выход";
                }
            }
            else
            {
                button2.Text = "Вход администратором";
                isAdmin = false;
                AddDep.Enabled = AddBuilding.Enabled = false;
                //AddUserBtn.Visible = false;
            }
            
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.ADD_BUILDING:
                    Point last = curPoints.Last();
                    last.X = e.X;
                    last.Y = e.Y;
                    curPoints[curPoints.Count - 1] = last;
                    break;
                
                case Mode.SELECT:
                    hitTest(e.Location);
                    break;
                case Mode.ADD_MARKER:
                    hitTest(e.Location);
                    if (curBuilding != null)
                    {
                        if(curMarker == null)
                        {
                            isMarkerVisible = true;
                            point.X = e.Location.X;
                            point.Y = e.Location.Y;
                        }
                        else
                        {
                            isMarkerVisible = false;
                        }
                    }
                    else
                    {
                        isMarkerVisible = false;
                    }
                    
                    break;
            }
            pictureBox1.Refresh();

        }


        private void hitTest(Point p)
        {
            if (curBuilding != null)
            {
                if (!curBuilding.hitTest(p))
                {
                    curBuilding = null;
                    curMarker = null;
                    CloseInfo();
                }
                else
                {
                    if (curMarker != null)
                    {
                        if (!curMarker.hitTest(p))
                        {
                            curMarker = null;
                            CloseInfo();
                        }
                    }
                    else
                    {
                        curMarker = curBuilding.HitTestMarkers(p);
                        if (curMarker != null) ShowInfo(curMarker.Id,curMarker.Location);
                    }
                }
            }
            else
            {
                curMarker = null;
                CloseInfo();
                foreach (Building build in Database.buildingsInfo)
                {

                    if (build.hitTest(p))
                    {
                        curBuilding = build;
                    }
                }
            }
        }

        public void CloseInfo()
        {
            if (userView != null)
            {
                //splitContainer2.Panel2.Controls.Remove(userView);
                this.Controls.Remove(userView);
            }

        }

        public void ShowInfo(long id,Point location)
        {
            
            //Database.FilterByDepId(id);
            //userView = new UserView(isAdmin);
            //Point screen = pictureBox1.PointToScreen(location);
            //Point actual = splitContainer2.Panel2.PointToClient(screen);
            //userView.Location = actual;
            //userView.Visible = true;
            //userView.depId = id;
            //splitContainer2.Panel2.Controls.Add(userView);
            //userView.BringToFront();

            Database.FilterByDepId(id);
            userView = new UserView(isAdmin);
            Point screen = pictureBox1.PointToScreen(location);
            Point actual = this.PointToClient(screen);
            userView.Location = actual;
            userView.Visible = true;
            userView.depId = id;
            this.Controls.Add(userView);
            userView.BringToFront();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case Mode.ADD_BUILDING:
                    if (curPoints.Count >= 4)
                    {
                        if (Math.Pow(e.X - curPoints[0].X, 2) + Math.Pow(e.Y - curPoints[0].Y, 2) <= 10)
                        {
                           
                            mode = Mode.SELECT;
                            BuildAdd add = new BuildAdd();
                            add.points = curPoints;
                            add.ShowDialog();
                            pictureBox1.Refresh();
                            curPoints.Clear();
                            curPoints = null;
                            return;
                        }
                    }
                    curPoints.Add(new Point(e.X, e.Y));
                    break;
                case Mode.ADD_MARKER:
                    if (isMarkerVisible)
                    {
                        DepEdit form = new DepEdit();
                        form.b = curBuilding;
                        form.point = point;
                        form.ShowDialog();
                        mode = Mode.SELECT;

                    }
                    break;
            }
            //DepEdit ed = new DepEdit();
            //ed.point = point;
            //ed.ShowDialog();
            //if(ed.DialogResult == DialogResult.OK)
            //{
            //    addingMode = false;
            //}
        }

        private void AddDep_Click(object sender, EventArgs e)
        {
            mode = Mode.ADD_MARKER;

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color c = Color.FromKnownColor(KnownColor.LightBlue);
            SolidBrush s = new SolidBrush(Color.LightBlue);
            Pen p = new Pen(s, 5F);
            foreach (Building build in Database.buildingsInfo)
            {
                if (build.Equals(curBuilding))
                {
                    s.Color = Color.FromArgb(100,Color.Blue);
                }
                else
                {
                    s.Color = Color.FromArgb(200, Color.LightBlue);
                }
                g.FillPath(s, build.Path);
                foreach(Marker m in build.Markers)
                {
                    if (m.Equals(curMarker))
                    {
                        s.Color = Color.FromArgb(200, Color.SeaGreen);
                    }
                    else if (m.Equals(highlight))
                    {
                        s.Color = Color.FromArgb(200, Color.OrangeRed);
                    }
                    else
                    {
                        s.Color = Color.FromArgb(200,Color.LightSeaGreen);
                    }
                    g.FillEllipse(s, m.getRect());
                }
            }
            switch (mode)
            {
                case Mode.ADD_BUILDING:
                    s.Color = Color.FromArgb(60, Color.LightBlue);
                    if (curPoints.Count >= 2)
                    {
                        g.DrawLines(p, curPoints.ToArray());
                    }
                    foreach(PointF curPoint in curPoints)
                    {
                        s.Color = Color.FromArgb(120, Color.Blue);
                        g.FillRectangle(s,curPoint.X - 5, curPoint.Y - 5, 5 * 2, 5 * 2);
                    }
                    break;
                case Mode.ADD_MARKER:
                    if (isMarkerVisible)
                    {
                        e.Graphics.FillEllipse(s, point.X - 10, point.Y - 10, 10 * 2, 10 * 2);
                    }
                    break;
            }
            s.Dispose();
            p.Dispose();
        }

        private void AddBuilding_Click(object sender, EventArgs e)
        {
            mode = Mode.ADD_BUILDING;
            point = new Point(0, 0);
            curPoints = new List<Point>();
            curPoints.Add(point);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (searchTxt.Text != "")
            {
                Database.searchByFam(searchTxt.Text.Trim());
                ShowAll.Enabled = true;
                //table.DataSource =Database.fil
            }
        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            Database.getUsers();
            ShowAll.Enabled = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = table.Rows[e.RowIndex];
                long id = Convert.ToInt64(row.Cells["id_dep"].Value);
                highlight = Database.getMarkerById(id);
                pictureBox1.Refresh();
            }
            
        }
    }
}
