using GenericSequenceGenerator.Interfaces;

namespace GenericSequenceGenerator.Models
{
    public abstract class SequenceGenerator<T> : ISequenceGenerator<T>
    {
        private T _prevous;

        private T _current;

        private T _next;

        public SequenceGenerator(T previous, T current)
        {
            this._prevous = previous;
            this._current = current;
        }

        /// <summary>
        /// Предыдущий элемент последовательности.
        /// </summary>
        public T Previous => this._prevous;

        /// <summary>
        /// Данный элемент последовательности.
        /// </summary>
        public T Current => this._current;

        /// <summary>
        /// Следующий элемент последовательности.
        /// </summary>
        public T Next => this._next = this.GetNext();

        /// <summary>
        /// Количество элементов последовательности.
        /// </summary>
        public int Count { get; private set; }

        public T SetPrevous(T value) => this._prevous = value;

        public T SetCurrent(T value) => this._current = value;

        public T SetNext(T value) => this._next = value;

        public int SetCount(int count) => this.Count = count;

        /// <summary>
        /// Метод получения следующего элемента последовательности.
        /// </summary>
        /// <returns></returns>
        internal abstract T GetNext();
    }
}
