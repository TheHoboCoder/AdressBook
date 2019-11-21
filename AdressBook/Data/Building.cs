using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Drawing.Drawing2D;

namespace AdressBook.Data
{
    public class Building
    {
        public long Id { get; set; }
        public string Name { get; set; }
        private GraphicsPath path = new GraphicsPath();
        public List<Point> Points { get; set; }

        public GraphicsPath Path
        {
            get
            {
                return path;
            }
        }

        public List<Marker> Markers { get; set; }

        public Building(long id, string name, byte[] data)
        {
            Id = id;
            Name = name;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Point[]));
            using (MemoryStream stream = new MemoryStream(data))
            {
                Point[] serialized = (Point[])serializer.ReadObject(stream);
                setPathPoints(serialized.ToList());
            }
            Markers = new List<Marker>();

        }
        public Building()
        {
            Markers = new List<Marker>();
        }
        //public Building(string name, List<Marker> markers)
        //{
        //    Id = id;
        //    Name = name;
        //    Markers = (from m in markers select new Marker(m.Id, m.Name, m.Location)).ToList();
        //}

        public bool AddMarker(string name,Point location)
        {
            long id = Database.addDep(name, Id,location);
            if (id!=-1)
            {
                Markers.Add(new Marker(id, name, location));
                return true;
            }
            return false;
        }

        //public void DeleteMarker(long id)
        //{
        //   Marker marker = Markers.FirstOrDefault(m => m.Id == id);
        //    if (marker != null)
        //    {

        //    }

        //}

        public void setPathPoints(List<Point> point)
        {
            Points = point;
            path.Reset();
            path.AddPolygon(point.ToArray());
        }

        public bool hitTest(Point point)
        {
            return path.IsVisible(point);
        }

        public Marker HitTestMarkers(Point point)
        {
            foreach(Marker cur in Markers)
            {
                if (cur.hitTest(point))
                {
                    return cur;
                }
            }
            return  null;
        }

        public  byte[] Serialize()
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Point[]));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, Points.ToArray());
                return stream.ToArray();
            }
        }

    }
}
