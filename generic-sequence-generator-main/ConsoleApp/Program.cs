using System.Reflection;
using ConsoleApp;
using GenericSequenceGenerator.Interfaces;
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
var fibonacciesGenerator2 = new FibonacciSequenceGenerator(3, 7);
var initFibonacciSequence2 = new List<int>(fibonacciesGenerator2.Count) { fibonacciesGenerator2.Previous, fibonacciesGenerator2.Current };

var actualFibonacciSequence2 = Utils<int>.CreateFullSequence(fibonacciesGenerator2, initFibonacciSequence2, count);
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
var integersGenerator2 = new IntegerSequenceGenerator(4, 11);
var initIntegersSequence2 = new List<int>(integersGenerator2.Count) { integersGenerator2.Previous, integersGenerator2.Current };

var actualIntegerSequence2 = Utils<int>.CreateFullSequence(integersGenerator2, initIntegersSequence2, count);
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
var doublesGenerator2 = new DoubleSequenceGenerator(3.3, 6.8);
var initDoubleSequence2 = new List<double>(doublesGenerator2.Count) { doublesGenerator2.Previous, doublesGenerator2.Current };

var actualDoubleSequence2 = Utils<double>.CreateFullSequence(doublesGenerator2, initDoubleSequence2, count);
Utils<double>.ShowSequenceInfo(actualDoubleSequence2, expectedArray2.ToList());
*/

/* Пример 4. Проверка создания последовательности символов 
// 4.1. 
var expectedCharSequence = new List<char> { 'A', 'B', 'B', 'C', 'D', 'F', 'I', 'N', 'V', 'I' };

var charsGenerator = new CharSequenceGenerator('A', 'B');
var initCharSequence = new List<char>(charsGenerator.Count) { charsGenerator.Previous, charsGenerator.Current };

var actualCharSequence = Utils<char>.CreateFullSequence(charsGenerator, initCharSequence);
Utils<char>.ShowSequenceInfo(actualCharSequence, expectedCharSequence);

// 4.2.
var expectedCharSequence2 = new List<char> { 'd', 'l', 'A', 'R', 'R', 'I', 'Z' };

var count = 7;
var charsGenerator2 = new CharSequenceGenerator('d', 'l');
var initCharlSequence2 = new List<char>(charsGenerator2.Count) { charsGenerator2.Previous, charsGenerator2.Current };

var actualCharSequence2 = Utils<char>.CreateFullSequence(charsGenerator2, initCharlSequence2, count);
Utils<char>.ShowSequenceInfo(actualCharSequence2, expectedCharSequence2);
*/

/* Пример 5. Проверка создания универсальной последовательности 
// 5.1.1. 
var expectedFibonacciArray = new int[] { 2, 5, 7, 12, 19, 31, 50, 81, 131, 212 };

var fibonacciesGenerator = new DelegateSequenceGenerator<int>(2, 5, fibonacciNext);
var initFibonacciSequence = new List<int>(fibonacciesGenerator.Count) { fibonacciesGenerator.Previous, fibonacciesGenerator.Current };

var actualFibonacciSequence = Utils<int>.CreateFullSequence(fibonacciesGenerator, initFibonacciSequence);
Utils<int>.ShowSequenceInfo(actualFibonacciSequence, expectedFibonacciArray.ToList());

// 5.1.2.
var expectedFibonacciArray2 = new int[] { 4, 8, 12, 20, 32, 52, 84, 136 };

var count = 8;
var fibonacciesGenerator2 = new DelegateSequenceGenerator<int>(4, 8, fibonacciNext);
var initFibonacciSequence2 = new List<int>(fibonacciesGenerator2.Count) { fibonacciesGenerator2.Previous, fibonacciesGenerator2.Current };

var actualFibonacciSequence2 = Utils<int>.CreateFullSequence(fibonacciesGenerator2, initFibonacciSequence2, count);
Utils<int>.ShowSequenceInfo(actualFibonacciSequence2, expectedFibonacciArray2.ToList());

//// 5.2.1.
var expectedIntegerArray = new int[] { 3, 7, 18, 52, 168, 592, 2208, 8512, 33408, 132352};

var integersGenerator = new DelegateSequenceGenerator<int>(3, 7, integerNext);
var initIntegerSequence = new List<int>(integersGenerator.Count) { integersGenerator.Previous, integersGenerator.Current };

var actualIntegerSequence = Utils<int>.CreateFullSequence(integersGenerator, initIntegerSequence);
Utils<int>.ShowSequenceInfo(actualIntegerSequence, expectedIntegerArray.ToList());

//// 5.2.2.
var expectedIntegerArray2 = new int[] { 4, 15, 58, 228, 904, 3600 };

count = 6;
var integersGenerator2 = new DelegateSequenceGenerator<int>(4, 15, integerNext);
var initIntegerSequence2 = new List<int>(integersGenerator2.Count) { integersGenerator2.Previous, integersGenerator2.Current };

var actualIntegerSequence2 = Utils<int>.CreateFullSequence(integersGenerator2, initIntegerSequence2, count);
Utils<int>.ShowSequenceInfo(actualIntegerSequence2, expectedIntegerArray2.ToList());

//// 5.3.1.
var expectedDoubleArray = new double[] { 4.1, 6.4, 7.040625, 7.949635208610742, 8.835289055012884, 9.735048548914259, 10.6426237921829, 11.557346396214504, 12.478199975170031, 13.40440298675921 };

var doublesGenerator = new DelegateSequenceGenerator<double>(4.1, 6.4, doubleNext);
var initDoubleSequence = new List<double>(doublesGenerator.Count) { doublesGenerator.Previous, doublesGenerator.Current };

var actualDoubleSequence = Utils<double>.CreateFullSequence(doublesGenerator, initDoubleSequence);
Utils<double>.ShowSequenceInfo(actualDoubleSequence, expectedDoubleArray.ToList());

//// 5.3.2.
var expectedDoubleArray2 = new double[] { 3.7, 16.9, 17.1189349112426, 18.106145861434438, 19.05162233347068, 20.001995248937558 };

count = 6;
var doublesGenerator2 = new DelegateSequenceGenerator<double>(3.7, 16.9, doubleNext);
var initDoubleSequence2 = new List<double>(doublesGenerator2.Count) { doublesGenerator2.Previous, doublesGenerator2.Current };

var actualDoubleSequence2 = Utils<double>.CreateFullSequence(doublesGenerator2, initDoubleSequence2, count);
Utils<double>.ShowSequenceInfo(actualDoubleSequence2, expectedDoubleArray2.ToList());


int fibonacciNext(int prev, int curr) => prev + curr;

int integerNext(int prev, int curr) => (6 * curr) - (8 * prev);

double doubleNext(double prev, double curr) => curr + (prev / curr);
*/

/* Пример 6. Проверка содержимого типов через рефлексию */

var type = typeof(ISequenceGenerator<>);

var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
var requiredProperties = new[] { "Previous", "Current", "Next" };

foreach (var property in requiredProperties)
{
    if(properties.Any(p => p.Name == property))
    {
        Console.WriteLine($"Property '{property}' is existing in ISequenceGenerator.");
    }
    else
    {
        Console.WriteLine($"Property '{property}' is missing in ISequenceGenerator.");
    }
}

foreach (var property in properties)
{
    if(property.CanRead)
    {
        Console.WriteLine($"Property '{property.Name}' can read.");
    }
    else
    {
        Console.WriteLine($"Property '{property.Name}' cannot read.");
    }

    if (property.CanWrite)
    {
        Console.WriteLine($"Property '{property.Name}' can write.");
    }
    else
    {
        Console.WriteLine($"Property '{property.Name}' cannot write.");
    }
}

