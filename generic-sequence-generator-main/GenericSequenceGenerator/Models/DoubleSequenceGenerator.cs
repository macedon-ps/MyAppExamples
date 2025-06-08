namespace GenericSequenceGenerator.Models
{
    public class DoubleSequenceGenerator : SequenceGenerator<double>
    {
        /// <summary>
        /// последовательность элементов с числами с плавающей запятой.
        /// </summary>
        public List<double> DoubleSequance { get; set; }

        public DoubleSequenceGenerator(double previous, double current, int count = 10)
            : base(previous, current)
        {
            this.DoubleSequance = new List<double>(count) { previous, current };
            this.Count = count;

            for (int i = 1; i <= this.Count - 2; i++)
            {
                this.DoubleSequance.Add(this.Next);
            }
        }

        /// <summary>
        /// Метод исчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент колекции.</returns>
        /// <exception cref="Exception">DivideByZeroException.</exception>
        public override double GetNext()
        {
            if (this.Current != 0.0)
            {
                double next = this.Current + (this.Previous / this.Current);
                this.Previous = this.Current;
                this.Current = next;
                return next;
            }
            else
            {
                throw new DivideByZeroException("На 0 делить нельзя");
            }
        }
    }
}
