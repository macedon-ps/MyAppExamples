/* Пример 1. Интерфейсы. Наследование интерфейсов 
var action = new BaseAction();
action.Move();
action.Run();

interface IAction
{
    void Move();
}
interface IRunAction : IAction
{
    void Run();
}
class BaseAction : IRunAction
{
    public void Move()
    {
        Console.WriteLine("Move");
    }
    public void Run()
    {
        Console.WriteLine("Run");
    }
}
*/

/* Пример 2. Реализация интерфейсов по умолчанию. Скрытие методов базового интерфейса 
IAction action1 = new RunAction();
action1.Move(); // I am moving

IRunAction action2 = new RunAction();
action2.Move(); // I am running

interface IAction
{
    void Move() => Console.WriteLine("I am moving");
}
interface IRunAction : IAction
{
    // скрываем реализацию из IAction
    new void Move() => Console.WriteLine("I am running");
}
class RunAction : IRunAction { }
*/

/* Пример 3. Реализация методов интерфейса в классе. Приоритет над реализацией методов в интерфейсах по умолчанию 
IAction action1 = new RunAction();
action1.Move(); // I am tired

IRunAction action2 = new RunAction();
action2.Move(); // I am tired

interface IAction
{
    void Move() => Console.WriteLine("I am moving");
}
interface IRunAction : IAction
{
    new void Move() => Console.WriteLine("I am running");
}
class RunAction : IRunAction
{
    public void Move() => Console.WriteLine("I am tired");
}
*/
/* Пример 4. Интерфейсы с обобщениями как ограничениями классов
// создаем мессенджер
var telegram = new Messenger<IMessageSendable>();

// создаем сообщение
var message = new Message("Hello World!");
var message2 = new WebMessage("Hello WEB World!");
// отправляем сообщение
telegram.Send(message);
telegram.Send(message2);

interface IMessage
{
    string Text { get; } // текст сообщения
}
interface IPrintable
{
    void Print();
}

interface IMessageSendable : IMessage, IPrintable { }
class Message : IMessageSendable
{
    public string Text { get; }
    public Message(string text) => Text = text;

    public void Print() => Console.WriteLine($"// {this.GetType().ToString()}: {Text} //");
}

class WebMessage : IMessageSendable
{
    public string Text { get; }

    public WebMessage(string text)
    {
        Text = text;
    }

    public void Print() => Console.WriteLine($"|| {this.GetType().ToString()}: {Text} ||");
}

class Messenger<T> where T : IMessageSendable
{
    public void Send(T message)
    {
        Console.WriteLine("Отправка сообщения:");
        message.Print();
    }
}
*/

/* Пример 5. Интерфейсы с обобщениями 
IUser<int> user1 = new User<int>(6789);
Console.WriteLine($"{user1.GetType().ToString()}: {user1.Id}");    // 6789

IUser<string> user2 = new User<string>("12345");
Console.WriteLine($"{user2.GetType().ToString()}: {user2.Id}");    // 12345

interface IUser<T>
{
    T Id { get; }
}
class User<T> : IUser<T>
{
    public T Id { get; }
    public User(T id) => Id = id;
}
*/

/* Пример 6. Явная реализация интерфейсов 

BaseAction baseAction1 = new BaseAction();

// baseAction1.Move();  // ! Ошибка - в BaseAction нет метода Move
// необходимо приведение к типу IAction

// небезопасное приведение
//((IAction)baseAction1).Move();

// безопасное приведение 
//if (baseAction1 is IAction action)        // error - всегда true
//{
//    action.Move();
//}

// или так
IAction baseAction2 = new BaseAction();
baseAction2.Move();

interface IAction
{
    void Move();
}
class BaseAction : IAction
{
    // Явная реализация интерфейса - IAction.Move()
    void IAction.Move() => Console.WriteLine("Move in Base Class");
}
*/

Person bob = new Person() { Name = "Bob", Age = 12 }; // ошибка - свойства Name и Age все равно надо установить в инициализаторе
Console.WriteLine($"Name = {bob.Name} Age = {bob.Age}");
public class Person
{
    public Person() {}
    public required string Name { get; set; }
    public required int Age { get; set; }
}

/* Пример 7. Явная реализация интерфейсов 2

BaseAction baseAction1 = new BaseAction();

// baseAction1.Move();  // ! Ошибка - в BaseAction нет метода Move
// необходимо приведение к типу IAction

// небезопасное приведение
//((IAction)baseAction1).Move();

// безопасное приведение 
//if (baseAction1 is IAction action)        // error - всегда true
//{
//    action.Move();
//}

// или так
IAction baseAction2 = new BaseAction();
baseAction2.Move();

interface IAction
{
    void Move();
}
class BaseAction : IAction
{
    // Явная реализация интерфейса - IAction.Move()
    void IAction.Move() => Console.WriteLine("Move in Base Class");
}
*/
