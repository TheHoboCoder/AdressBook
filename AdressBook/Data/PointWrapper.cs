using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook.Data
{
    [DataContract]
    class PointWrapper
    {

        private Point point;

        public int X
        {
            get { return point.X; }
            set { point.X = value; }
        }

        public int Y
        {
            get { return point.Y; }
            set { point.Y = value; }

        }

        public PointWrapper(Point p)
        {
            point = p;
        }

    }
}
