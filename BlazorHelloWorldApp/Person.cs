namespace BlazorHelloWorldApp
{
    public class Person
    {
        /* Пример 13. Привязка моделей 
        public string Name { get; set; } = "";
        public int Age { get; set; }*/

        /* Пример 14. Привязка моделей 2 */
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public DateTime Day { get; set; } = DateTime.Now;
        public bool IsWorking { get; set; }
        public string Subject { get; set; } = "";
        public string[] Courses { get; set; } = [];
    }
}
