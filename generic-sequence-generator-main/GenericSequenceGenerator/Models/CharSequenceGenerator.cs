namespace GenericSequenceGenerator.Models
{
    public class CharSequenceGenerator : SequenceGenerator<char>
    {
        /// <summary>
        /// последовательность элементов с символами.
        /// </summary>
        public List<char> CharSequance { get; set; }

        public CharSequenceGenerator(char previous, char current, int count = 10)
            : base(previous, current)
        {
            this.Count = count;
        }

        /// <summary>
        /// Метод исчисления следующего элемента последовательности GetNext().
        /// </summary>
        /// <returns>Следующий элемент колекции.</returns>
        public override char GetNext()
        {
            char next = (char)((this.Current + this.Previous) % 26 + 'A');
            this.Previous = this.Current;
            this.Current = next;
            return next;
        }
    }
}
