namespace GenericSequenceGenerator.Models
{
    public class IntegerSequenceGenerator : SequenceGenerator<int>
    {
        public IntegerSequenceGenerator(int previous, int current)
            : base(previous, current)
        {
            this.SetCount(10);
        }

        /// <summary>
        /// Метод исчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент колекции.</returns>
        internal override int GetNext()
        {
            int next = (this.Current * 6) - (this.Previous * 8);
            this.SetNext(next);
            this.SetPrevous(this.Current);
            this.SetCurrent(next);
            return next;
        }
    }
}
