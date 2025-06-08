namespace GenericSequenceGenerator.Models
{
    public class DelegateSequenceGenerator<T> : SequenceGenerator<T>
    {
        /// <summary>
        /// Делегат, указывающий на метод расчета следующего элемента последовательности.
        /// </summary>
        public Func<T, T, T> MyFunc { get; set; }

        /// <summary>
        /// Обобщенная последовательность элементов.
        /// </summary>
        public new T Next
        {
            get => this.GetNext(this.MyFunc);
            set;
        }

        /// <summary>
        /// последовательность элементов обобщенного типа Т.
        /// </summary>
        public List<T> DelegateSequance { get; set; }

        /// <summary>
        /// Конструктор DelegateSequenceGenerator с параметрами.
        /// </summary>
        /// <param name="previous">Предыдущий элемент последовательности.</param>
        /// <param name="current">Данный элемент последовательности.</param>
        /// <param name="myFunc">Делегат, указывающий на метод расчета следующего элемента последовательности.</param>
        /// <param name="count">Количество элементов последавтельности.</param>
        public DelegateSequenceGenerator(T previous, T current, Func<T, T, T> myFunc, int count = 10)
            : base(previous, current)
        {
            this.DelegateSequance = new List<T>(count) { previous, current };
            this.Count = count;
            this.MyFunc = myFunc;

            for (int i = 1; i <= this.Count - 2; i++)
            {
                this.DelegateSequance.Add(this.Next);
            }
        }

        /// <summary>
        /// Метод исчисления следующего элемента последовательности обобщенного типа Т - GetNext(Func<T, T, T> myFunc).
        /// </summary>
        /// <param name="myFunc">Делегат, указывающий на метод расчета следующего элемента последовательности</param>
        /// <returns>Следующий элемент последовательности</returns>
        public T GetNext(Func<T, T, T> myFunc)
        {
            var next = myFunc(this.Previous, this.Current);
            this.Previous = this.Current;
            this.Current = next;
            return next;
        }

        /// <summary>
        /// Метод расчета следующего элемента последовательности для чисел Фибоначчи.
        /// </summary>
        /// <param name="prev">Предыдущий элемент последоавтельности.</param>
        /// <param name="curr">Данный элемент последоавтельности.</param>
        /// <returns>Следующий элемент последовательности.</returns>
        public int FibonacciNext(int prev, int curr) => prev + curr;

        /// <summary>
        /// Метод расчета следующего элемента последовательности для целых чисел.
        /// </summary>
        /// <param name="prev">Предыдущий элемент последоавтельности.</param>
        /// <param name="curr">Данный элемент последоавтельности.</param>
        /// <returns>Следующий элемент последовательности.</returns>
        public int IntegerNext(int prev, int curr) => (6 * curr) - (8 * prev);

        /// <summary>
        /// Метод расчета следующего элемента последовательности для вещественных чисел.
        /// </summary>
        /// <param name="prev">Предыдущий элемент последоавтельности.</param>
        /// <param name="curr">Данный элемент последоавтельности.</param>
        /// <returns>Следующий элемент последовательности.</returns>
        public double DoubleNext(double prev, double curr) => curr + (prev / curr);

        public override T GetNext()
        {
            throw new NotImplementedException();
        }
    }
}
