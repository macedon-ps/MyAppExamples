using GenericSequenceGenerator.Interfaces;

namespace GenericSequenceGenerator.Models
{
    public abstract class SequenceGenerator<T> : ISequenceGenerator<T>
    {
        public SequenceGenerator(T previous, T current)
        {
            this.Previous = previous;
            this.Current = current;
        }

        /// <summary>
        /// Предыдущий элемент последовательности.
        /// </summary>
        public T Previous { get; set; }

        /// <summary>
        /// Данный элемент последовательности.
        /// </summary>
        public T Current { get; set; }

        /// <summary>
        /// Следующий элемент последовательности.
        /// </summary>
        public T Next
        {
            get => this.GetNext();
            set;
        }

        /// <summary>
        /// Количество элементов последовательности.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Метод получения следующего элемента последовательности.
        /// </summary>
        /// <returns></returns>
        public abstract T GetNext();
    }
}
