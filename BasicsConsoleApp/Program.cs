// данные
int i = 5;
var f = 77.99;

var person = new Person() { Name = "Sam", Surname = "Surkov", Age = 33 };
var person2 = new Person() { Name = "Frodo", Surname = "Ablomov", Age = 45 };
var person3 = new Person();
var person4 = new Person();
person3 = null;
person4 = null;

var company = new Company() { CompanyName = "IBM", NumberEmployees = 1000, LevelOfProductivityInPercent = 77.89 };
var company2 = new Company() { CompanyName = "Apple", NumberEmployees = 1300, LevelOfProductivityInPercent = 83.46 };

// 1. Проверка методов
//1.1.method ToString()
/* 
 * Console.WriteLine(i.ToString()); // выведет число 5
Console.WriteLine(f.ToString()); // выведет число 3,5

Console.WriteLine(person.ToString());
Console.WriteLine(person.Name.ToString());
Console.WriteLine(person.Surname.ToString());
Console.WriteLine(person.Age);  // метод ToString() вызывается неявно

Console.WriteLine(company.ToString());
Console.WriteLine(company2);    // метод ToString() вызывается неявно
*/

// 1.2. method GetHashCode()
/*
Console.WriteLine($"Хеш-код person1: {person.GetHashCode()}");
Console.WriteLine($"Хеш-код person1 повтор: {person.GetHashCode()}");
Console.WriteLine($"Хеш-код person2: {person2.GetHashCode()}");

Console.WriteLine($"Хеш-код company1: {company.GetHashCode()}");
Console.WriteLine($"Хеш-код company2: {company2.GetHashCode()}");
*/

// 1.3.method GetType()
/*
Console.WriteLine(person.GetType());
Console.WriteLine(person.Surname.GetType());
Console.WriteLine(company.GetType());
Console.WriteLine(company2.LevelOfProductivityInPercent.GetType());

if (person.GetType() == typeof(Person))
    Console.WriteLine("Это реально класс Person");
if (company2.GetType() == typeof(Company))
    Console.WriteLine("А это таки структура Company");
*/

// 1.4. method Equals()
Console.WriteLine("company.Equals(company2) :");
Console.WriteLine(company.Equals(company2));                        // сравнение двух объектов
Console.WriteLine("company.GetType().Equals(company2.GetType()) :");
Console.WriteLine(company.GetType().Equals(company2.GetType()));    // сравнение типов двух объектов
// var isEquals = person3.Equals(person4);                          // NullReferenceException
// Console.WriteLine(isEquals);                                     // ошибка сравнения двух null
Console.WriteLine("Equals(person3,person4), person3=null, person4=null :");
Console.WriteLine(Equals(person3,person4));                         // сравнение двух null
Console.WriteLine("ReferenceEquals(person,person2), person!=person2, person!=null, person2!=null :");
Console.WriteLine(ReferenceEquals(person, person2));                // сравнение двух null
Console.WriteLine("ReferenceEquals(person3,person4), person3=null, person4=null :");
Console.WriteLine(ReferenceEquals(person3,person4));                // сравнение двух null



public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

public struct Company
{
    public int NumberEmployees { get; set; }
    public string CompanyName { get; set; }
    public double LevelOfProductivityInPercent { get; set; }

    public override string ToString()
    {
        return $"В компании {CompanyName} сегодня работают {NumberEmployees} работников. Средння продуктивность труда работников составляет {LevelOfProductivityInPercent} %";
    }
}