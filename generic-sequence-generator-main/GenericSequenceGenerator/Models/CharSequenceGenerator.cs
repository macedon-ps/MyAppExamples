namespace GenericSequenceGenerator.Models
{
    public class CharSequenceGenerator : SequenceGenerator<char>
    {
        public CharSequenceGenerator(char previous, char current)
            : base(previous, current)
        {
            this.SetCount(10);
        }

        /// <summary>
        /// Метод исчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент колекции.</returns>
        internal override char GetNext()
        {
            char next = (char)((this.Current + this.Previous) % 26 + 'A');
            this.SetNext(next);
            this.SetPrevous(this.Current);
            this.SetCurrent(next);
            return next;
        }
    }
}
