using System;
using SerializeXML;

namespace SerializerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Joe",
                Age = 23
            };

            Serializer<Person> serializeXML = new Serializer<Person>("person", person);

            serializeXML.Serialize();
            Console.WriteLine("Объект сериализован");

            Console.WriteLine("\n\n\n");

            Person deserializedPerson = serializeXML.Deserialize();
            Console.WriteLine("Объект десериализован");
            Console.WriteLine($"Имя: {deserializedPerson.Name} \nВозраст: {deserializedPerson.Age}");

            Console.ReadKey();
        }
    }
}
