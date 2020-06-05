using System.IO;
using System.Xml.Serialization;

namespace SerializeXML
{
    public class Serializer<T> where T : class
    {
        private T model { get; set; }
        private string path { get; set; }
        private string filename { get; set; }

        private XmlSerializer xmlSerializer { get; set; }

        /// <summary>
        /// Конструктор класса с настройками для сериализации
        /// </summary>
        /// <param name="filename">Имя XML файла</param>
        /// <param name="model">Класс для сериализации</param>
        public Serializer(string filename, T model)
        {
            this.path = Directory.GetCurrentDirectory();
            this.filename = filename;
            this.model = model;

            this.xmlSerializer = new XmlSerializer(typeof(T));
        }

        /// <summary>
        /// Конструктор класса с настройками для сериализации
        /// </summary>
        /// <param name="path">Путь сохранения сериализованного файла, по умолчанию - директория расположения данной библиотеки</param>
        /// <param name="filename">Имя XML файла</param>
        /// <param name="model">Класс для сериализации</param>
        public Serializer(string path, string filename, T model)
        {
            this.path = path;
            this.filename = filename;
            this.model = model;

            this.xmlSerializer = new XmlSerializer(typeof(T));
        }

        public void Serialize()
        {
            char sep = Path.DirectorySeparatorChar;
            using (FileStream fs = new FileStream($"{this.path}{sep}{this.filename}.xml", FileMode.OpenOrCreate))
            {
                this.xmlSerializer.Serialize(fs, model);
            }
        }

        /// <summary>
        //// Десериализация объекта
        /// </summary>
        /// <returns>Объект класса ${T}</returns>
        public T Deserialize()
        {
            T result;
            char sep = Path.DirectorySeparatorChar;
            using (FileStream fs = new FileStream($"{this.path}{sep}{this.filename}.xml", FileMode.OpenOrCreate))
            {
                result = (T)this.xmlSerializer.Deserialize(fs);
            }

            return result;
        } 
    }
}
