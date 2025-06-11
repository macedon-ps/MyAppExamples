namespace GenericSequenceGenerator.Models
{
    public class DoubleSequenceGenerator : SequenceGenerator<double>
    {
        public DoubleSequenceGenerator(double previous, double current)
            : base(previous, current)
        {
            this.SetCount(10);
        }

        /// <summary>
        /// Метод исчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент колекции.</returns>
        /// <exception cref="Exception">DivideByZeroException.</exception>
        internal override double GetNext()
        {
            if (this.Current != 0.0)
            {
                double next = this.Current + (this.Previous / this.Current);
                this.SetNext(next);
                this.SetPrevous(this.Current);
                this.SetCurrent(next);
                return next;
            }
            else
            {
                throw new DivideByZeroException("На 0 делить нельзя");
            }
        }
    }
}
