using GenericSequenceGenerator.Interfaces;
using GenericSequenceGenerator.Models;

namespace ConsoleApp
{
    public class Utils<T>
    {
        /// <summary>
        /// Метод создания последовательности элементов обобщенного типа.
        /// </summary>
        /// <typeparam name="T">Обобщенный тип.</typeparam>
        /// <param name="sequenceGenerator">Объект класса, производного от SequenceGenetator<T>, кот. содержит первичные данные для создания последовательности элементов обобщенного типа (два первых элемента, количество элементов последовательности).</param>
        /// <param name="collection">Создаваемая в цикле последовательность элементов обобщенного типа.</param>
        /// <returns>Последовательность элементов обобщенного типа.</returns>
        public static List<T> CreateFullSequence<T>(SequenceGenerator<T> sequenceGenerator, List<T> collection)
        {
            int i;
            for (i = 1; i <= sequenceGenerator.Count - 2; i++)
            {
                collection.Add(sequenceGenerator.Next);
            }

            return collection;
        }

        /// <summary>
        /// Метод вывода последовательности элементов, а также информации о соответствии ее с ожидаемой (тестовой) последовательностью элементов.
        /// </summary>
        /// <typeparam name="T">Обобщенный тип данных.</typeparam>
        /// <param name="actualSequence">Созданная последовательность элементов.</param>
        /// <param name="expectedSequence">Ожидаемая (тестовая) последовательность элементов.</param>
        public static void ShowSequenceInfo<T>(List<T> actualSequence, List<T> expectedSequence)
        {
            int i = 1;

            foreach (T item in actualSequence)
            {
                Console.WriteLine($"{i++}: {item}");
            }
            Console.WriteLine("----------");

            Console.WriteLine($"expectedSequence is equal to actualSequence: {expectedSequence.SequenceEqual(actualSequence)}");
            Console.WriteLine($"actualSequence.Count == expectedSequence.Count: {actualSequence.Count == expectedSequence.Count}");

            Console.WriteLine("----------");
        }
    }
}
