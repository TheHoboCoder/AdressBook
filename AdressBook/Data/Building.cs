using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.IO;

namespace AdressBook.Data
{
    [DataContract]
    class Building
    {
        public string Name { get; set; }
        public List<PointF> Points { get; set; }

        //сериализация в Json
        public static byte[] Serialize(Building el)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Building));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, el);
                return stream.ToArray();
            }
        }

        //десериализация из Json
        public static Building Deserialize(byte[] data)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Building));
            using (MemoryStream stream = new MemoryStream(data))
            {
                Building serialized = (Building)serializer.ReadObject(stream);
                return (Building)serialized;
            }
        }
    }
}
