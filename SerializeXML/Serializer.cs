using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Serialization;

namespace SerializeXML
{
    public class Serializer<T> where T : class
    {
        private T model { get; set; }
        private string path { get; set; }

        private string filename { get; set; }

        public Serializer(string filename, T model)
        {
            this.path = Directory.GetCurrentDirectory();
            this.filename = filename;
            this.model = model;
        }

        public Serializer(string path, string filename, T model)
        {
            this.path = path;
            this.filename = filename;
            this.model = model;
        }

        public void Serialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            char sep = Path.DirectorySeparatorChar;
            using (FileStream fs = new FileStream($"{this.path}{sep}{this.filename}.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, model);
            }
        }

        public T Deserialize()
        {
            T result;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            char sep = Path.DirectorySeparatorChar;
            using (FileStream fs = new FileStream($"{this.path}{sep}{this.filename}.xml", FileMode.OpenOrCreate))
            {
                result = (T)xmlSerializer.Deserialize(fs);
            }

            return result;
        } 
    }
}
