/* Пример 1. Базовый и производный классы 
var objP = new Person() { Name="Sam"};
var objE = new Employee() { Name="Tompson"};

Console.WriteLine(objP.Name);
objP.Print();
Console.WriteLine(objE.Name);
objE.Print();
objE.PrintName();
   
public class Person                         // базовый класс
{
    private string _name = "";

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public void Print()
    {
        Console.WriteLine(Name);
    }
}

public class Employee : Person              // производный класс
{
    public void PrintName()
    {
        Console.WriteLine(Name);
    }
}
*/

/* Пример 2. Базовый и производный классы с конструкторами 
Person person = new Person("Bob");
person.Print();     // Bob

Employee employee = new Employee("Tom", "Microsoft");
person = employee;

person.Print();     // Tom
employee.Print();   // Tom

class Person
{
    public string Name { get; set; }

    public Person()
    {
        Name = "LittleBunny";
        Console.WriteLine("Вызов конструктора без параметров");
    }
    public Person(string name)
    {
        Name = name;
    }
    public void Print()
    {
        Console.WriteLine(Name);
    }
}

class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company): base(name)
    {
        Company = company;
    }
}
*/

/* Пример 3. Порядок вызова конструкторов 
Employee tom = new Employee("Tom", 22, "Microsoft");

class Person
{
    string name;
    int age;

    public Person(string name)
    {
        this.name = name;
        Console.WriteLine($"Person(string name), {name}");
    }
    public Person(string name, int age) : this(name)
    {
        this.age = age;
        Console.WriteLine($"Person(string name, int age), {name}, {age}");
    }
}
class Employee : Person
{
    string company;

    public Employee(string name, int age, string company) : base(name, age)
    {
        this.company = company;
        Console.WriteLine($"Employee(string name, int age, string company, {name}, {age}, {company})");
    }
}
*/

/* Данные: 
var person = new Person("Andrey");
var employee = new Employee("Sergey", "Aurora");
var client = new Client("Pavel", "PrivatBank");
*/

/* Пример 4. Базовый и производные классы 
Person person2 = employee;
Person person3 = client;

Console.WriteLine("Type Person");
Console.WriteLine(person.Print()); 
Console.WriteLine(person.PrintPerson());
Console.WriteLine(person2.Print());
Console.WriteLine(person2.PrintPerson());
//Console.WriteLine(person2.PrintEmployee());
Console.WriteLine(person3.Print());
Console.WriteLine(person3.PrintPerson());
//Console.WriteLine(person3.PrintClient());
Console.WriteLine("Type Employee");
Console.WriteLine(employee.Print());
Console.WriteLine(employee.PrintPerson());
Console.WriteLine(employee.PrintEmployee());
Console.WriteLine("Type Client");
Console.WriteLine(client.Print());
Console.WriteLine(client.PrintPerson());
Console.WriteLine(client.PrintClient());
Console.WriteLine("--------------------------------");

Employee employee2 = (Employee)person2;
Client client2 = (Client)person3;

Console.WriteLine(person.Print()); 
//Console.WriteLine(employee.pr());
Console.WriteLine(employee2.ToString());
Console.WriteLine(client.ToString());
Console.WriteLine(client2.ToString());
*/

/* Пример 5. Базовый и производные классы 2 
Person newPerson = employee;
Console.WriteLine(newPerson.Name);
Console.WriteLine(newPerson.Print());
Console.WriteLine(newPerson.PrintPerson());
Console.WriteLine(newPerson.ToString());
Console.WriteLine(newPerson.GetType());
Console.WriteLine("-------------------------");
Employee newEmployee = (Employee)newPerson;
Console.WriteLine(newEmployee.Name);
Console.WriteLine(newEmployee.Company);
Console.WriteLine(newEmployee.Print());
Console.WriteLine(newEmployee.PrintPerson());
Console.WriteLine(newEmployee.PrintEmployee());
Console.WriteLine(newEmployee.ToString());
Console.WriteLine(newEmployee.GetType());
*/

/* Пример 6. Базовый и производные классы 3 

// Employee newEmployee = (Employee)person;        // error
// Employee newEmployee = new Person("Boris");     // error

Employee newEmployee = new Employee("Marina", "IBM");

Console.WriteLine(newEmployee.Name);            
Console.WriteLine(newEmployee.Company);
Console.WriteLine(newEmployee.Print());
Console.WriteLine(newEmployee.PrintPerson());
Console.WriteLine(newEmployee.PrintEmployee());
Console.WriteLine(newEmployee.ToString());
Console.WriteLine(newEmployee.GetType());
*/

/* Классы:
public class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public string Print()
    {
        return $"{Name}";
    }
    public string PrintPerson()
    {
        return $"Person {Name}";
    }
}

public class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company) : base(name)
    {
        Company = company;
    }
    public string PrintEmployee()
    {
        return $"{Name} is an employee and works in {Company}";
    }
}

public class Client : Person
{
    public string Bank { get; set; }
    public Client(string name, string bank) : base(name)
    {
        Bank = bank;
    }

    public string PrintClient()
    {
        return $"{Name} is a client of {Bank}";
    }
}
*/

/* Пример 7. Виртуальные методы и свойства. переопределение методов 

Person bob = new Person("Bob");
bob.Print(); // вызов метода Print из класса Person

Employee tom = new Employee("Tom", "Microsoft");
tom.Print(); // вызов метода Print из класса Person

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public virtual void Print()
    {
        Console.WriteLine(Name);
    }
}
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company) : base(name)
    {
        Company = company;
    }
    public override void Print()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
}
*/

/* Пример 8. Переопределение свойств 

Person bob = new Person("Bob");
Console.WriteLine(bob.Age); // 1

Employee tom = new Employee("Tom", "Microsoft");
Console.WriteLine(tom.Age); // 18
tom.Age = 22;
Console.WriteLine(tom.Age); // 22
tom.Age = 12;
Console.WriteLine(tom.Age); // 22

class Person
{
    int age = 1;
    public virtual int Age
    {
        get => age;
        set { if (value > 0 && value < 110) age = value; }
    }
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public virtual void Print() => Console.WriteLine(Name);
}
class Employee : Person
{
    public override int Age
    {
        get => base.Age;
        set { if (value > 17 && value < 110) base.Age = value; }
    }
    public string Company { get; set; }
    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
        base.Age = 18; // возраст для работников по умолчанию
    }
}
*/

/* Пример 9. Скрытие методов класса 

Person bob = new Person("Bob");
bob.Print();                // Name: Bob

Employee tom = new Employee("Tom", "Microsoft");

tom.Print();                // Name: Tom  Company: Microsoft

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void Print()
    {
        Console.WriteLine($"Name: {Name}");
    }
}
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company)
                : base(name)
    {
        Company = company;
    }
    public new void Print()         // скрытие метода Print() базового класса
    {
        base.Print();               // но тут же вызываем метод base.Print() из базового класса Person
        Console.WriteLine($"Company: {Company}");
    }
}
*/

/* Пример 10. Скрытие свойств класса 
Person bob = new Person("Bob");
Console.WriteLine(bob.Name);    // Bob

Employee tom = new Employee("Tom", "Microsoft");
Console.WriteLine(tom.Name);    // Mr./Ms. Tom

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
}
class Employee : Person
{
    // скрываем свойство Name базового класса
    public new string Name                      // скрытие свойства базового класса - Name
    {
        get => $"Mr./Ms. {base.Name}";          // но тут же вызов свойства базового класса - base.Name
        set => base.Name = value;

    }
    public string Company { get; set; }
    public Employee(string name, string company)
                : base(name)
    {
        Company = company;
    }
}
*/

/* Пример 11. Скрытие переменных и констант класса 

Console.WriteLine(Person.minAge);     // 1
Console.WriteLine(Person.typeName);   // Person

Console.WriteLine(Employee.minAge);     // 18
Console.WriteLine(Employee.typeName);   // Employee

class Person
{
    public readonly static int minAge = 1;
    public const string typeName = "Person";
}
class Employee : Person
{
    // скрываем поля и константы базового класса
    public new readonly static int minAge = 18;
    public new const string typeName = "Employee";
}
*/

/* Пример 12. Скрытие или переопределение методов 

var obj = new Employee("Tom", "Microsoft");
Person tom = obj;
tom.Print();        // Tom работает в Microsoft
tom.Start();
Console.WriteLine(tom.GetType());
obj.Print();
obj.Start();
Console.WriteLine(obj.GetType());

class Person
{
    public string Name { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void Start()
    {
        Console.WriteLine($"Start {Name} as a person!");
    }
    public void Print()
    {
        Console.WriteLine(Name);
    }
}
class Employee : Person
{
    public string Company { get; set; }
    public Employee(string name, string company)
        : base(name)
    {
        Company = company;
    }

    public new void Print()
    {
        Console.WriteLine($"{Name} работает в {Company}");
    }
    public new void Start()
    {
        Console.WriteLine($"Start {Name} as an employee!");
    }
}
*/

/* Пример 13. Абстрактные классы */

using System.Xml.Linq;

Transport car = new Car();
Transport ship = new Ship();
Transport aircraft = new Aircraft();
var horse = new Horse("Horse");

car.Move();
ship.Move();
aircraft.Move();
Console.WriteLine(horse.Name);
horse.Move();
horse.Move("Конь");
Console.WriteLine(horse.Name);


abstract class Transport
{
    public string Name { get; set; }
    public void Move()
    {
        if (Name != null)
        {
            Console.WriteLine($"{Name} движется");
        }
        else
        {
            Console.WriteLine("Транспортное средство движется");
        }
    }
    public void Move(string name)
    {
        Console.WriteLine($"{name} движется-подвижется очччень быстро");
    }

    public Transport() { }
    public Transport(string name) 
    {
        Name = name;
    }
}
// класс корабля
class Ship : Transport { }
// класс самолета
class Aircraft : Transport { }
// класс машины
class Car : Transport { }

class Horse : Transport
{
    public string Name { get; set; }

    public Horse(string name)
    {
        Name = name;
    }
    public void Move()
    {
        if (Name != null)
        {
            Console.WriteLine($"{Name} движется");
        }
        else
        {
            Console.WriteLine("Транспортное средство движется");
        }
    }
}


/* Пример 14. Абстрактные методы 

Transport car = new Car();
Transport ship = new Ship();
Transport aircraft = new Aircraft();

car.Move();         // машина едет
ship.Move();        // корабль плывет
aircraft.Move();    // самолет летит
abstract class Transport
{
    public abstract void Move();
}
// класс корабля
class Ship : Transport
{
    // мы должны реализовать все абстрактные методы и свойства базового класса
    public override void Move()
    {
        Console.WriteLine("Корабль плывет");
    }
}
// класс самолета
class Aircraft : Transport
{
    public override void Move()
    {
        Console.WriteLine("Самолет летит");
    }
}
// класс машины
class Car : Transport
{
    public override void Move()
    {
        Console.WriteLine("Машина едет");
    }
}
*/

/* Пример 15. Пример абстрактного класса Shape 

var rectanle = new Rectangle { Width = 20, Height = 20 };
var circle = new Circle { Radius = 200 };
PrintShape(rectanle); // Perimeter: 80   Area: 400
PrintShape(circle); // Perimeter: 1256  Area: 125600

void PrintShape(Shape shape)
{
    Console.WriteLine($"Perimeter: {shape.GetPerimeter()}  Area: {shape.GetArea()}");
}

// абстрактный класс фигуры
abstract class Shape
{
    // абстрактный метод для получения периметра
    public abstract double GetPerimeter();
    // абстрактный метод для получения площади
    public abstract double GetArea();
}
// производный класс прямоугольника
class Rectangle : Shape
{
    public float Width { get; set; }
    public float Height { get; set; }

    // переопределение получения периметра
    public override double GetPerimeter() => Width * 2 + Height * 2;
    // переопрелеление получения площади
    public override double GetArea() => Width * Height;
}
// производный класс окружности
class Circle : Shape
{
    public double Radius { get; set; }

    // переопределение получения периметра
    public override double GetPerimeter() => Radius * 2 * 3.14;
    // переопрелеление получения площади
    public override double GetArea() => Radius * Radius * 3.14;
}
*/