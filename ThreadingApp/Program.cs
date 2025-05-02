/* Пример 1. Информация о потоке 
// получаем текущий поток
Thread currentThread = Thread.CurrentThread;

//получаем имя потока
Console.WriteLine($"Имя потока: {currentThread.Name}");
currentThread.Name = "Метод Main";
Console.WriteLine($"Имя потока: {currentThread.Name}");

Console.WriteLine($"Запущен ли поток: {currentThread.IsAlive}");
Console.WriteLine($"Id потока: {currentThread.ManagedThreadId}");
Console.WriteLine($"Приоритет потока: {currentThread.Priority}");
Console.WriteLine($"Статус потока: {currentThread.ThreadState}");

Console.WriteLine($"Домен потока: {Thread.GetDomain()}");
Console.WriteLine($"Id домена потока: {Thread.GetDomainID()}");
Console.WriteLine($"Thread.CurrentThread: {Thread.CurrentThread}");
Console.WriteLine($"Thread.CurrentPrincipal: {Thread.CurrentPrincipal}");
*/

/* Пример 2. Метод Sleep() для задердки выполнения потока 
for (int i = 0; i < 10; i++)
{
    Thread.Sleep(500);      // задержка выполнения на 500 миллисекунд
    Console.WriteLine(i);
}
*/

/* Пример 3. Три потока. Использование делегата ThreadStart 
// создаем новый поток
Thread myThread1 = new Thread(Print);
var name = "Andrey";
Thread myThread2 = new Thread(new ThreadStart(PrintName));
Thread myThread3 = new Thread(() => Console.WriteLine("Hello Threads, my friend"));

myThread1.Start();  // запускаем поток myThread1
myThread2.Start();  // запускаем поток myThread2
myThread3.Start();  // запускаем поток myThread3

void Print() => Console.WriteLine("Hello Threads");
void PrintName() => Console.WriteLine($"Hello Threads {name}");
*/

/* Пример 4. Несколько потоков 
// создаем новый поток
Thread myThread = new Thread(Print);
// запускаем поток myThread
myThread.Start();

// действия, выполняемые в главном потоке
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Главный поток: {i}");
    Thread.Sleep(300);
}

// действия, выполняемые во втором потокке
void Print()
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine($"Второй поток: {i}");
        Thread.Sleep(400);
    }
}
*/

/* Пример 5. Использование делегата ParameterizedThreadStart 
// создаем новые потоки
Thread myThread1 = new Thread(new ParameterizedThreadStart(Print));
Thread myThread2 = new Thread(Print);
Thread myThread3 = new Thread(message => Console.WriteLine(message));

// запускаем потоки
myThread1.Start("Hello");
myThread2.Start("Привет");
myThread3.Start("Salut");
void Print(object? message) => Console.WriteLine(message);
*/

/* Пример 6. Свои типы как параметр для ParameterizedThreadStart 
Company comp = new Company(1, "Motorolla");
Person tom = new Person("Tom", "Soyer", 37, comp);

// создаем новый поток
Thread myThread = new Thread(Print);
myThread.Start(tom);

void Print(object? obj)
{
    // здесь мы ожидаем получить объект Person
    if (obj is Person person)
    {
        Console.WriteLine($"Name = {person.Name}");
        Console.WriteLine($"Surname = {person.Surname}");
        Console.WriteLine($"Age = {person.Age}");
        Console.WriteLine($"CompanyId = {person.conpany.CompanyId}");
        Console.WriteLine($"CompanyName = {person.conpany.CompanyName}");
    }
    else Console.WriteLine("Ошибка в данных входного параметра");
}
record class Person(string Name, string Surname, int Age, Company conpany);

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }

    public Company(int id, string name)
    {
        CompanyId = id;
        CompanyName = name;
    }
}
*/

/* Пример 7. Несколько потоков 2 
int x = 0;

// запускаем пять потоков
for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";   // устанавливаем имя для каждого потока
    myThread.Start();
}

void Print()
{
    x = 1;
    for (int i = 1; i < 6; i++)
    {
        if (i == 1) Console.WriteLine($"{Thread.CurrentThread.Name} стартовал");
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        x++;
        Thread.Sleep(100);
        if(i==5) Console.WriteLine($"{Thread.CurrentThread.Name} завершился");
    }
}
*/

/* Пример 8. Несколько потоков 2, с блокированием одного потока методом lock(object obj)
int x = 0;
object obj = new();

// запускаем пять потоков
for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";   // устанавливаем имя для каждого потока
    myThread.Start();
}

void Print()
{
    lock (obj)                // блокировка работы других потоков, пока не отработает данный поток
    {
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            if (i == 1) Console.WriteLine($"{Thread.CurrentThread.Name} стартовал");
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
            if (i == 5) Console.WriteLine($"{Thread.CurrentThread.Name} завершился");
        }
        Console.WriteLine("----------------------------------------");
    }
}
*/

/* Пример 9. Аналог примера 8. Метод монитора Enter (object obj, bool acquiredLock) 
int x = 0;
object obj = new();

// запускаем пять потоков
for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";   // устанавливаем имя для каждого потока
    myThread.Start();
}

void Print()
{
    bool acquiredLock = false;
    Monitor.Enter(obj, ref acquiredLock);  // блокировка работы других потоков, пока не отработает данный поток
    {
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            if (i == 1) Console.WriteLine($"{Thread.CurrentThread.Name} стартовал");
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
            if (i == 5) Console.WriteLine($"{Thread.CurrentThread.Name} завершился");
        }
        Console.WriteLine("----------------------------------------");
    }
    Monitor.Exit(obj);
}
*/

/* Пример 9.1. Аналог примера 8. Метод Enter() объекта Lock() с конструкцией try/finally 
int x = 0;
Lock obj = new();                   // объект типа Lock()

for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";   
    myThread.Start();
}

void Print()
{
    bool acquiredLock = false;
    obj.Enter();
    
    try{
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            if (i == 1) Console.WriteLine($"{Thread.CurrentThread.Name} стартовал");
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
            if (i == 5) Console.WriteLine($"{Thread.CurrentThread.Name} завершился");
        }
        Console.WriteLine("----------------------------------------");
    }
    finally
    {
        obj.Exit();
    }
}
*/

/* Пример 9.2. Аналог примера 8. Метод EnterScope() объекта Lock() с конструкцией using 
int x = 0;
Lock obj = new();                   // объект типа Lock()

for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start();
}

void Print()
{
    using(obj.EnterScope())
    {
        x = 1;
        for (int i = 1; i < 6; i++)
        {
            if (i == 1) Console.WriteLine($"{Thread.CurrentThread.Name} стартовал");
            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
            x++;
            Thread.Sleep(100);
            if (i == 5) Console.WriteLine($"{Thread.CurrentThread.Name} завершился");
        }
        Console.WriteLine("----------------------------------------");
    }
}
*/

/* Пример 9.3. Аналог примера 8. Используем мьютексы 
int x = 0;
Mutex mutex = new();                   // объект типа Lock()

for (int i = 1; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток {i}";
    myThread.Start();
}

void Print()
{
    mutex.WaitOne();
    x = 1;
    for (int i = 1; i < 6; i++)
    {
        if (i == 1) Console.WriteLine($"{Thread.CurrentThread.Name} стартовал");
        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
        x++;
        Thread.Sleep(100);
        if (i == 5) Console.WriteLine($"{Thread.CurrentThread.Name} завершился");
    }
    Console.WriteLine("----------------------------------------");
    mutex.ReleaseMutex();
}
*/

/* Пример 10. Использование семафоров 
// запускаем пять потоков
for (int i = 1; i < 6; i++)
{
    Reader reader = new Reader(i);
}
class Reader
{
    // создаем семафор
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;// счетчик чтения

    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Читатель {i}";
        myThread.Start();
    }

    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();  // ожидаем, когда освободиться место

            Console.WriteLine($"{Thread.CurrentThread.Name} входит в библиотеку");

            Console.WriteLine($"{Thread.CurrentThread.Name} читает");
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} покидает библиотеку");

            sem.Release();  // освобождаем место

            count--;
            Thread.Sleep(1000);
        }
    }
}
*/
