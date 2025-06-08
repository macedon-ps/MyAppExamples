namespace GenericSequenceGenerator.Models
{
    public class IntegerSequenceGenerator : SequenceGenerator<int>
    {
        public IntegerSequenceGenerator(int previous, int current, int count = 10)
            : base(previous, current)
        {
            this.Count = count;
        }

        /// <summary>
        /// Метод исчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент колекции.</returns>
        public override int GetNext()
        {
            int next = (this.Current * 6) - (this.Previous * 8);
            this.Previous = this.Current;
            this.Current = next;
            return next;
        }
    }
}
