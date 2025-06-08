namespace GenericSequenceGenerator.Models
{
    public class DoubleSequenceGenerator : SequenceGenerator<double>
    {
        public DoubleSequenceGenerator(double previous, double current, int count = 10)
            : base(previous, current)
        {
            this.Count = count;
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
