using ConsoleApp;
using GenericSequenceGenerator.Models;

/* Пример 1. Проверка создания последовательности чисел Фибоначчи 
// 1.1.
var expectedArray = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181 };

var fibonacciesGenerator = new FibonacciSequenceGenerator(0, 1);
var initFibonacciSequence = new List<int>(fibonacciesGenerator.Count) { fibonacciesGenerator.Previous, fibonacciesGenerator.Current };

var actualFibonacciSequence = Utils<int>.CreateFullSequence(fibonacciesGenerator, initFibonacciSequence);
Utils<int>.ShowSequenceInfo(actualFibonacciSequence, expectedArray.ToList());

// 1.2.
var expectedArray2 = new int[] { 3, 7, 10, 17, 27, 44, 71, 115, 186, 301, 487, 788, 1275 };

var count = 13;

var fibonacciesGenerator2 = new FibonacciSequenceGenerator(3, 7, count);
var initFibonacciSequence2 = new List<int>(fibonacciesGenerator2.Count) { fibonacciesGenerator2.Previous, fibonacciesGenerator2.Current };

var actualFibonacciSequence2 = Utils<int>.CreateFullSequence(fibonacciesGenerator2, initFibonacciSequence2);
Utils<int>.ShowSequenceInfo(actualFibonacciSequence2, expectedArray2.ToList());
*/

/* Пример 2. Проверка создания последовательности целых чисел 
// 2.1.
var expectedArray = new int[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 };

var integersGenerator = new IntegerSequenceGenerator(1, 2);
var initIntegersSequence = new List<int>(integersGenerator.Count) { integersGenerator.Previous, integersGenerator.Current };

var actualIntegerSequence = Utils<int>.CreateFullSequence(integersGenerator, initIntegersSequence);
Utils<int>.ShowSequenceInfo(actualIntegerSequence, expectedArray.ToList());

// 2.2.
var expectedArray2 = new int[] { 4, 11, 34, 116, 424, 1616, 6304, 24896 };

var count = 8;
var integersGenerator2 = new IntegerSequenceGenerator(4, 11, count);
var initIntegersSequence2 = new List<int>(integersGenerator2.Count) { integersGenerator2.Previous, integersGenerator2.Current };

var actualIntegerSequence2 = Utils<int>.CreateFullSequence(integersGenerator2, initIntegersSequence2);
Utils<int>.ShowSequenceInfo(actualIntegerSequence2, expectedArray2.ToList());
*/

/* Пример 3. Проверка создания последовательности целых чисел 
// 3.1.
var expectedArray = new double[] { 1.1, 4.3, 4.5558139534883715, 5.499662855989648, 6.328043444542756, 7.197137170618942, 8.076381694452097, 8.967515551531049, 9.868142001303216, 10.77687594031086 };

var doublesGenerator = new DoubleSequenceGenerator(1.1, 4.3);
var initDoubleSequence = new List<double>(doublesGenerator.Count) { doublesGenerator.Previous, doublesGenerator.Current };

var actualDoubleSequence = Utils<double>.CreateFullSequence(doublesGenerator, initDoubleSequence);
Utils<double>.ShowSequenceInfo(actualDoubleSequence, expectedArray.ToList());

// 3.2.
var expectedArray2 = new double[] { 3.3, 6.8, 7.285294117647059, 8.21868127953644, 9.105112310240429, 10.007757000333156, 10.917562495204516 };

var count = 7;
var doublesGenerator2 = new DoubleSequenceGenerator(3.3, 6.8, count);
var initDoubleSequence2 = new List<double>(doublesGenerator2.Count) { doublesGenerator2.Previous, doublesGenerator2.Current };

var actualDoubleSequence2 = Utils<double>.CreateFullSequence(doublesGenerator2, initDoubleSequence2);
Utils<double>.ShowSequenceInfo(actualDoubleSequence2, expectedArray2.ToList());
*/

/* Пример 4. Проверка создания последовательности символов */

var expectedCharSequence = new List<char> { 'A', 'B', 'B', 'C', 'D', 'F', 'I', 'N', 'V', 'I' };

var charsGenerator = new CharSequenceGenerator('A', 'B');
var initCharSequence = new List<char>(charsGenerator.Count) { charsGenerator.Previous, charsGenerator.Current };

var actualCharSequence = Utils<char>.CreateFullSequence(charsGenerator, initCharSequence);
Utils<char>.ShowSequenceInfo(actualCharSequence, expectedCharSequence);


var expectedCharSequence2 = new List<char> { 'd', 'l', 'A', 'R', 'R', 'I', 'Z' };

var count = 7;
var charsGenerator2 = new CharSequenceGenerator('d', 'l', count);
var initCharlSequence2 = new List<char>(charsGenerator2.Count) { charsGenerator2.Previous, charsGenerator2.Current };

var actualCharSequence2 = Utils<char>.CreateFullSequence(charsGenerator2, initCharlSequence2);
Utils<char>.ShowSequenceInfo(actualCharSequence2, expectedCharSequence2);


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
