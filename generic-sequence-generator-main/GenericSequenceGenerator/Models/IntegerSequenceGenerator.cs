namespace GenericSequenceGenerator.Models
{
    public class IntegerSequenceGenerator : SequenceGenerator<int>
    {
        /// <summary>
        /// последовательность элементов с целыми числами.
        /// </summary>
        public List<int> IntegerSequance { get; set; }

        public IntegerSequenceGenerator(int previous, int current, int count = 10)
            : base(previous, current)
        {
            this.IntegerSequance = new List<int>(count) { previous, current};
            this.Count = count;

            for (int i = 1; i <= this.Count - 2; i++)
            {
                this.IntegerSequance.Add(this.Next);
            }
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
