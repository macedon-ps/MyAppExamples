using GenericSequenceGenerator.Models;

/* Пример 1. Проверка создания последовательности чисел Фибоначчи 
// 1.1.
var expectedArray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181 };
var expectedCount = expectedArray.Length;

var fibonacci = new FibonacciSequenceGenerator(0, 1);
var newFibonacci = new List<int>(fibonacci.Count) { fibonacci.Previous, fibonacci.Current };

int i;
for (i = 1; i <= fibonacci.Count - 2; i++)
{
    newFibonacci.Add(fibonacci.Next);
}

i = 1;
foreach (var item in newFibonacci)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

Console.WriteLine($"expectedArray is equal to newFibonacci: {expectedArray.SequenceEqual(newFibonacci)}");
Console.WriteLine($"fibonacci.Count == expectedCount: {fibonacci.Count == expectedCount}");

Console.WriteLine("----------");

// 1.2.
var expectedArray2 = new int[] { 3, 7, 10, 17, 27, 44, 71, 115, 186, 301, 487, 788, 1275 };
var expectedCount2 = expectedArray2.Length;
var count = 13;

var fibonacci2 = new FibonacciSequenceGenerator(3, 7, count);
var newFibonacci2 = new List<int>(fibonacci2.Count) { fibonacci2.Previous, fibonacci2.Current };

for (i = 1; i <= fibonacci2.Count - 2; i++)
{
    newFibonacci2.Add(fibonacci2.Next);
}

i = 1;
foreach (var item in newFibonacci2)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

Console.WriteLine($"expectedArray2 is equal to newFibonacci2: {expectedArray2.SequenceEqual(newFibonacci2)}");
Console.WriteLine($"fibonacci2.Count == expectedCount2: {fibonacci2.Count == expectedCount2}");
*/

/* Пример 2. Проверка создания последовательности целых чисел 

var expectedArray = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };
var expectedCount = expectedArray.Length;

var integers = new IntegerSequenceGenerator(1, 2);
var newIntegers = new List<int>(integers.Count) { integers.Previous, integers.Current };

int i;
for (i = 1; i <= integers.Count - 2; i++)
{
    newIntegers.Add(integers.Next);
}

i = 1;
foreach (var item in newIntegers)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

Console.WriteLine($"expectedArray is equal to newIntegers: {expectedArray.SequenceEqual(newIntegers)}");
Console.WriteLine($"newIntegers.Count == expectedCount: {newIntegers.Count == expectedCount}");

Console.WriteLine("----------");

var expectedArray2 = new int[] { 4, 11, 34, 116, 424, 1616, 6304, 24896 };
var expectedCount2 = expectedArray2.Length;
var count = 8;

var integers2 = new IntegerSequenceGenerator(4, 11, count);
var newIntegers2 = new List<int>(integers2.Count) { integers2.Previous, integers2.Current };

i = 1;
for (i = 1; i <= integers2.Count - 2; i++)
{
    newIntegers2.Add(integers2.Next);
}

i = 1;
foreach (var item in newIntegers2)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

Console.WriteLine($"expectedArray2 is equal to newIntegers2: {expectedArray2.SequenceEqual(newIntegers2)}");
Console.WriteLine($"newIntegers2.Count == expectedCount2: {newIntegers2.Count == expectedCount2}");

Console.WriteLine("----------");
*/

/* Пример 3. Проверка создания последовательности целых чисел 

var expectedArray = new double[] { 1.1, 4.3, 4.5558139534883715, 5.499662855989648, 6.328043444542756, 7.197137170618942, 8.076381694452097, 8.967515551531049, 9.868142001303216, 10.77687594031086 };
var expectedCount = expectedArray.Length;

var doubles = new DoubleSequenceGenerator(1.1, 4.3);
var newDoubles = new List<double>(doubles.Count) { doubles.Previous, doubles.Current };

int i;
for (i = 1; i <= doubles.Count - 2; i++)
{
    newDoubles.Add(doubles.Next);
}

i = 1;
foreach (double item in newDoubles)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

Console.WriteLine($"expectedArray is equal to newDoubles: {expectedArray.SequenceEqual(newDoubles)}");
Console.WriteLine($"newDoubles.Count == expectedCount: {newDoubles.Count == expectedCount}");

Console.WriteLine("----------");

var expectedArray2 = new double[] { 3.3, 6.8, 7.285294117647059, 8.21868127953644, 9.105112310240429, 10.007757000333156, 10.917562495204516 };
var expectedCount2 = expectedArray2.Length;
var count = 7;

var doubles2 = new DoubleSequenceGenerator(3.3, 6.8, count);
var newDoubles2 = new List<double>(doubles2.Count) { doubles2.Previous, doubles2.Current };

i = 1;
for (i = 1; i <= doubles2.Count - 2; i++)
{
    newDoubles2.Add(doubles2.Next);
}

i = 1;
foreach (double item in newDoubles2)
{
    Console.WriteLine($"{i++}: {item}");
}

Console.WriteLine("----------");

Console.WriteLine($"expectedArray2 is equal to newDoubles2: {expectedArray2.SequenceEqual(newDoubles2)}");
Console.WriteLine($"newDoubles2.Count == expectedCount2: {newDoubles2.Count == expectedCount2}");
*/

/* Пример 4. Проверка создания последовательности символов */

var expectedSequence = new List<char> { 'A', 'B', 'B', 'C', 'D', 'F', 'I', 'N', 'V', 'I' };
var expectedCount = expectedSequence.Count;

var chars = new CharSequenceGenerator('A', 'B');
var actualSequence = new List<char>(chars.Count) { chars.Previous, chars.Current };

int i;
for (i = 1; i <= chars.Count - 2; i++)
{
    actualSequence.Add(chars.Next);
}

i = 1;
foreach (char item in actualSequence)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

Console.WriteLine($"expectedSequence is equal to actualSequence: {expectedSequence.SequenceEqual(actualSequence)}");
Console.WriteLine($"actualSequence.Count == expectedCount: {expectedSequence.Count == expectedCount}");

Console.WriteLine("----------");

var expectedSequence2 = new List<char> { 'd', 'l', 'A', 'R', 'R', 'I', 'Z' };
var expectedCount2 = expectedSequence2.Count;

var count = 7;
var chars2 = new CharSequenceGenerator('d', 'l', count);
var actualSequence2 = new List<char>(chars2.Count) { chars2.Previous, chars2.Current };

i = 1;
for (i = 1; i <= chars2.Count - 2; i++)
{
    actualSequence2.Add(chars2.Next);
}

i = 1;
foreach (char item in actualSequence2)
{
    Console.WriteLine($"{i++}: {item}");
}
Console.WriteLine("----------");

Console.WriteLine($"expectedSequence2 is equal to actualSequence2: {expectedSequence2.SequenceEqual(actualSequence2)}");
Console.WriteLine($"actualSequence2.Count == expectedCount2: {expectedSequence2.Count == expectedCount2}");

Console.WriteLine("----------");


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
