using System;
using SerializeXML;

namespace SerializerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сздаём обьект класса для сериализации
            Person person = new Person
            {
                Name = "Joe",
                Age = 23
            };

            // Или
            // Person person = new Person("Joe", 23);

            // Создаём объект обобщенного класса принимающего параметры: имя для файла, объект для сериализации
            Serializer<Person> serializeXML = new Serializer<Person>("person", person);

            // Если нужно указать иной путь для соранения xml-файла
            // Serializer<Person> serializeXML = new Serializer<Person>("path_to_serialized_xml", "person", person);

            // Сериализация
            serializeXML.Serialize();
            Console.WriteLine("Объект сериализован");

            Console.WriteLine("\n\n\n");


            // Десериализация
            Person deserializedPerson = serializeXML.Deserialize();
            Console.WriteLine("Объект десериализован");
            Console.WriteLine($"Имя: {deserializedPerson.Name} \nВозраст: {deserializedPerson.Age}");

            Console.ReadKey();
        }
    }
}
