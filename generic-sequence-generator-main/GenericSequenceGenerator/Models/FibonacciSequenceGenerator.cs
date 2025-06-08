namespace GenericSequenceGenerator.Models
{
    public class FibonacciSequenceGenerator : SequenceGenerator<int>
    {
        public FibonacciSequenceGenerator(int previous, int current, int count = 20)
            : base(previous, current)
        {
            this.Count = count;
        }

        /// <summary>
        /// Метод вычисчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент последовательности.</returns>
        public override int GetNext()
        {
            int next = this.Previous + this.Current;
            this.Previous = this.Current;
            this.Current = next;
            return next;
        }
    }
}
