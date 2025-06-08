using GenericSequenceGenerator.Models;

/* Пример 1. Проверка создания последовательности чисел Фибоначчи */

var count = 7;
var fibonacci = new FibonacciSequenceGenerator(3, 12);
var fibonacciSequence = fibonacci.FibonacciSequance;
Console.WriteLine($"prev = {fibonacci.Previous} curr = {fibonacci.Current} next = {fibonacci.Next} count = {fibonacci.Count}");
var fibonacci2 = new FibonacciSequenceGenerator(2, 5, count);
var fibonacciSequence2 = fibonacci2.FibonacciSequance;
Console.WriteLine($"prev = {fibonacci2.Previous} curr = {fibonacci2.Current} next = {fibonacci2.Next} count = {fibonacci2.Count}");
var i = 1;
foreach (var item in fibonacciSequence)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (var item in fibonacciSequence2)
{
    Console.WriteLine($"{i++}: {item}");
}


/* Пример 2. Проверка создания последовательности целых чисел 

var count = 13;
var integers = new IntegerSequenceGenerator(1, 2).IntegerSequance;

var integers2 = new IntegerSequenceGenerator(3, 7, count).IntegerSequance;

var i = 1;
foreach(int item in integers)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach(int item in integers2)
{
    Console.WriteLine($"{i++}: {item}");
}
*/

/* Пример 3. Проверка создания последовательности целых чисел 

var count = 16;
var doubles = new DoubleSequenceGenerator(1.1, 4.3).DoubleSequance;

var doubles2 = new DoubleSequenceGenerator(3, 7, count).DoubleSequance;

var i = 1;
foreach (double item in doubles)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (double item in doubles2)
{
    Console.WriteLine($"{i++}: {item}");
}
*/

/* Пример 4. Проверка создания последовательности символов 

var count = 7;
var chars = new CharSequenceGenerator('A', 'B').CharSequance;

var chars2 = new CharSequenceGenerator('d', 'l', count).CharSequance;

var i = 1;
foreach (char item in chars)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (char item in chars2)
{
    Console.WriteLine($"{i++}: {item}");
}
*/

/* Пример 5. Проверка создания универсальной последовательности 

var sequenceFibos = new DelegateSequenceGenerator<int>(2, 5, fibonacciNext).DelegateSequance;
var sequenceFibos2 = new DelegateSequenceGenerator<int>(4, 8, fibonacciNext, 8).DelegateSequance;
var sequenceIntegers = new DelegateSequenceGenerator<int>(3, 7, integerNext).DelegateSequance;
var sequenceIntegers2 = new DelegateSequenceGenerator<int>(45, 67, integerNext, 17).DelegateSequance;
var sequenceDoubles = new DelegateSequenceGenerator<double>(4.1, 6.4, doubleNext).DelegateSequance;
var sequenceDoubles2 = new DelegateSequenceGenerator<double>(3.7, 16.9, doubleNext, 6).DelegateSequance;

var i = 1;
foreach (int item in sequenceFibos)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (var item in sequenceFibos2)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (int item in sequenceIntegers)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (int item in sequenceIntegers2)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (double item in sequenceDoubles)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

i = 1;
foreach (double item in sequenceDoubles2)
{
    Console.WriteLine($"{i++}: {item}");
}

int fibonacciNext(int prev, int curr) => prev + curr;

int integerNext(int prev, int curr) => 6 * curr - 8 * prev;

double doubleNext(double prev, double curr) => curr + prev / curr;
*/
