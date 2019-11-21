using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Data
{
    public class Marker
    {
        private Point LeftPoint = new Point(-10, -10);
        private Size ColSize = new Size(20, 20);

        public long Id { get; set; }
        public long BuildingId { get; set; }
        public string Name { get; set; }
        public Point Location { get; set; }

        public Marker()
        {

        }

        public Rectangle getRect()
        {
            return new Rectangle(Location.X + LeftPoint.X, Location.Y + LeftPoint.Y, ColSize.Width, ColSize.Height);
        }

        public Marker(long id,string name, Point location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public bool hitTest(Point point)
        {
            return getRect().Contains(point);
        }
    }
}
