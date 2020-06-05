# SerializeXML

# Использование

```
// Сздаём обьект класса для сериализации
Person person = new Person
{
    Name = "Joe",
    Age = 23
};

// Или
// Person person = new Person("Joe", 23);

// Создаём объект обобщенного класса
Serializer<Person> serializeXML = new Serializer<Person>("person", person);

// Сериализация
serializeXML.Serialize();
Console.WriteLine("Объект сериализован");

Console.WriteLine("\n\n\n");


// Десериализация
Person deserializedPerson = serializeXML.Deserialize();
Console.WriteLine("Объект десериализован");
Console.WriteLine($"Имя: {deserializedPerson.Name} \nВозраст: {deserializedPerson.Age}");
```

# Класс для сериализации

Класс и его члены для сериализации должен быть объявлены как ```public```. Если в классе есть поля или свойства с модификатором ```private```, то при сериализации они будут игнорироваться.

Также для сериализации необходимо указать тип

```
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
```
