namespace GenericSequenceGenerator.Models
{
    public class FibonacciSequenceGenerator : SequenceGenerator<int>
    {
        public FibonacciSequenceGenerator(int previous, int current)
            : base(previous, current)
        {
            this.SetCount(20);
        }

        /// <summary>
        /// Метод вычисчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент последовательности.</returns>
        internal override int GetNext()
        {
            int next = this.Previous + this.Current;
            this.SetNext(next);
            this.SetPrevous(this.Current);
            this.SetCurrent(next);
            return next;
        }
    }
}
