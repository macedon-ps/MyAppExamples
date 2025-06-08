/*Вопрос 1          // нет доступа к методу, нельзя неявно преобразовать В в А
A obj = new A();
obj.Foo();          // нет доступа к методу

A obj3 = new B();   // нет доступа к методу
obj3.Foo();

B obj1 = new A();   // нет доступа к методу
obj1.Foo();         // нельзя неявно преобразовать В в А

B obj2 = new B();   // нет доступа к методу
obj2.Foo();

class A
{
    virtual void Foo()
    {
        Console.Write("Class A\n");
    }
}
class B : A
{
    override void Foo()
    {
        Console.Write("Class B\n");
    }
}
*/

/* Вопрос 2          // false false
var s = new S();
using (s)
{
    Console.WriteLine(s.GetDispose());
}
Console.WriteLine(s.GetDispose());

public struct S : IDisposable
{
    private bool dispose;
    public void Dispose()
    {
        dispose = true;
    }
    public bool GetDispose()
    {
        return dispose;
    }
}
*/

/* Вопрос 3          // 10 10 10 10 10 10 10 10 10 10
List<Action> actions = new List<Action>();
for (var count = 0; count < 10; count++)
{
    actions.Add(() => Console.WriteLine(count));
}
foreach (var action in actions)
{
    action(); 
}
*/

/* Вопрос 4          // 2  1 , нельзя неявно преобразовать Int в Short
char i = '3';
var j = 44444.88888;
var sum = (i + j);
Console.WriteLine($"i: {i.GetType()} {(i.)}");
Console.WriteLine($"j: {j.GetType()} {j}");
Console.WriteLine($"i + j: {sum.GetType()} {sum}");

//var obj = i;
//++i;
//Console.WriteLine($"obj: {obj.GetType()} {obj}");
//var newObj = (short)obj;
//Console.WriteLine($"++i + j: {sum.GetType()} {sum}");
//Console.WriteLine($"(short)obj: {newObj.GetType()} {newObj}");

//int a = 4;
//int b = 6;
//byte c = (byte)(a + b);
//Console.WriteLine($"a = {a}");
//Console.WriteLine($"b = {b}");
//Console.WriteLine($"(byte)(a + b) = {c}");
*/

/* Вопрос 5          // true false ? true true
var s1 = string.Format("{0}{1}", "abc", "cba");
var s2 = "abc" + "cba";
var s3 = "abccba";

Console.WriteLine($"s1: {s1.GetType()} {s1}");
Console.WriteLine($"(object)s1: {(object)s1.GetType()} {(object)s1}");
Console.WriteLine($"s2: {s2.GetType()} {s2}");
Console.WriteLine($"(object)s2: {(object)s2.GetType()} {(object)s2}");
Console.WriteLine($"s3: {s3.GetType()} {s3}");
Console.WriteLine($"(object)s3: {(object)s3.GetType()} {(object)s3}");

Console.WriteLine($"s1 == s2: {s1 == s2}");
Console.WriteLine($"(object)s1 == (object)s2: {(object)s1 == (object)s2}");
Console.WriteLine($"s2 == s3: {s2 == s3}");
Console.WriteLine($"(object)s2 == (object)s3: {(object)s2 == (object)s3}");
*/

/* Вопрос 6          // Test
internal class Program
{
    private static Object syncObject = new Object();
    private static void Write()
    {
        lock (syncObject)
        {
            Console.WriteLine("test");
        }
    }
    static void Main(string[] args)
    {
        lock (syncObject)
        {
            Write();
        }
    }
}
*/

/* Вопрос 7          // B A C B C C

A a = new B();
B b = new C();
C c = new C();

a.Print1();
a.Print2(); 
b.Print1();
b.Print2();    
c.Print1();         
c.Print2();         
public class A
{
    public virtual void Print1()
    {
        Console.Write("A");
    }
    public void Print2()
    {
        Console.Write("A");
    }
}
public class B : A
{
    public override void Print1()
    {
        Console.Write("B");
    }
    new public void Print2()
    {
        Console.Write("B");
    }
}
public class C : B
{
    public override void Print1()
    {
        Console.Write("C");
    }
    new public void Print2()
    {
        Console.Write("C");
    }
}
*/

/* Вопрос 8.         // error: Top-level statements must precede namespace and type declarations.

static IEnumerable<int> Square(IEnumerable<int> a)
{
    foreach (var r in a)
    {
        Console.WriteLine(r * r);
        yield return r * r;
    }
}
class Wrap
{
    private static int init = 0;
    public int Value
    {
        get { return ++init; }
    }
}
var w = new Wrap();
var wraps = new Wrap[3];
for (int i = 0; i < wraps.Length; i++)
{
    wraps[i] = w;
}

var values = wraps.Select(x => x.Value);
var results = Square(values);
int sum = 0;
int count = 0;
foreach (var r in results)
{
    count++;
    sum += r;
}
Console.WriteLine("Count {0}", count);
Console.WriteLine("Sum {0}", sum);

Console.WriteLine("Count {0}", results.Count());
Console.WriteLine("Sum {0}", results.Sum());

*/
/* Вопрос 13         // test    

object sync = new object();
var thread = new Thread(() =>
{
    try
    {
        Work();
    }
    finally
    {
        lock (sync)
        {
            Monitor.PulseAll(sync);
        }
    }
});
thread.Start();
lock (sync)
{
    Monitor.Wait(sync);
}
Console.WriteLine("test");

static void Work()
{
    Thread.Sleep(1000);
}
*/

/* Вопрос 14 

try
{
    Calc();
}
catch (MyCustomException e)
{
    Console.WriteLine("Catch MyCustomException");
    throw;
}
catch (DivideByZeroException e)
{
    Console.WriteLine("Catch Exception");
}
Console.ReadLine();


static void Calc()
{
    int result = 0;
    var x = 5;
    int y = 0;
    try
    {
        result = x / y;
    }
    catch (MyCustomException e)
    {
        Console.WriteLine("Catch DivideByZeroException");
        throw;
    }
    catch (Exception e)
    {
        Console.WriteLine("Catch Exception");
    }
    finally
    {
        throw new MyCustomException();
    }
}
class MyCustomException : DivideByZeroException
{
    
}
*/

/* Teoretical tests 
namespace MyNamespace
{
    internal class Class1 { }

    static class Class2 { }

    // private class Class3 { }         // error

    abstract class Class4 { }

    // protected class Class5 { }       // error
}
*/

/* Practical tests */
int a = 1;
int b = 7;
int c = 54;


Console.WriteLine($"a + b = {Operations.Add(a,b)}");
Console.WriteLine($"a - b = {Operations.Sub(a,b)}");
Console.WriteLine($"a * b = {Operations.Mult(a,b)}");
Console.WriteLine($"a + b + c = {Operations.Sum(a,b,c)}");

public class Operations
{
    public static int Add(int a, int b) => a + b;
    public static int Sub(int a, int b) => a - b;
    public static int Mult(int a, int b) => a * b;
    public static int Sum(int a, int b, int c) => a + b + c;
    
}
