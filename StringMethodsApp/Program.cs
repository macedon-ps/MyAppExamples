/* Строки. Пример 1. Вывод текста, в т.ч. с интерполяцией, с форматированием 
Print();
PrintFormatted();
PrintValue("Hello, my friend!");

void Print()
{
    string text = """
              <element attr="content">
                <body>
                </body>
              </element>
              """;
    Console.WriteLine(text);
}

void PrintFormatted()
{
    string text = @"
              <element attr=""content"">
                <body>
                </body>
              </element>
              ";
    Console.WriteLine(text);
}

void PrintValue(string val)
{
    string text = $"""
              <element attr="content">
                <body>
                {val}
                </body>
              </element>
              """;
    //// или так 
    //string text =  $$"""
    //          <element attr="content">
    //            <body>
    //            {{val}}
    //            </body>
    //          </element>
    //          """;
    Console.WriteLine(text);
}
*/

/* Строки. Пример 2. Метод StartWith() / EndsWith() 

var files = new string[]
{
    "myapp.exe",
    "forest.jpg",
    "main.exe",
    "book.pdf",
    "river.png",
    "pen.jpg",
    "moove.exe"
};

for (int i = 0; i < files.Length; i++)
{
    if (files[i].EndsWith(".exe"))
        Console.WriteLine(files[i]);
}
*/

/* Строки.Пример 3.Метод Split()

string text = "И поэтому все так произошло";
string[] words = text.Split(new char[] { ' ' });

foreach (string s in words)
{
    Console.WriteLine(s);
}
*/
