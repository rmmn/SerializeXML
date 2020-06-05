using System;
using System.Collections.Generic;
using System.Text;

namespace SerializerTest
{
    // Класс и его члены для сериализации должен быть объявлены как public. Если в классе есть поля или свойства с модификатором private, то при сериализации они будут игнорироваться.

    // Для сериализации необходимо указать тип
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Для сериализации необходим стандартный конструктор без параметров
        public Person()
        { }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
