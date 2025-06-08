namespace GenericSequenceGenerator.Models
{
    public class FibonacciSequenceGenerator : SequenceGenerator<int>
    {
        /// <summary>
        /// Локальное поле для предыдущего элемента последовательности.
        /// </summary>
        private int tempPrev;

        /// <summary>
        /// Локальное поле для данного элемента последовательности.
        /// </summary>
        private int tempCurr;

        /// <summary>
        /// Локальное поле для следующего элемента последовательности.
        /// </summary>
        private int tempNext;

        public FibonacciSequenceGenerator(int previous, int current, int count = 20)
            : base(previous, current)
        {
            this.Count = count;
            this.tempPrev = previous;
            this.tempCurr = current;
        }

        /// <summary>
        /// Метод вычисчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент последовательности.</returns>
        public override int GetNext()
        {
            this.tempNext = this.tempPrev + this.tempCurr;
            this.tempPrev = this.tempCurr;
            this.tempCurr = this.tempNext;
            return this.tempNext;
        }
    }
}
