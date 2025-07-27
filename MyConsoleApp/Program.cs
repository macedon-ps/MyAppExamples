using System.Text;
using TableOfRecords;
using TableOfRecords.Tests;

/* ОСНОВНОЕ ТУТ */

/* Test  WriteTable_With_ProfileBasic_And_Console() 

var originalOut = Console.Out;

// в строку
using var stringWriter = new StringWriter();
Console.SetOut(stringWriter);

TableOfRecordsCreator.WriteTable(TestCasesDataSource.ProfileBasicCollection, stringWriter);
var resultStringWriter = stringWriter.ToString();

// из файла данных
var exampleString = TestCasesDataSource.ProfileBasicTable;

Console.SetOut(originalOut);

Console.WriteLine(resultStringWriter);
Console.WriteLine(exampleString);

bool isCollectionsEquel = resultStringWriter.Equals(exampleString);
Console.WriteLine($"isCollectionsEquel: {isCollectionsEquel}");
*/

/* Test WriteTable_With_ProfileBasic_Class(): TRUE 

string Path = "Table.txt";
TextWriter originalConsoleOut = Console.Out;

// в строку
using var stringWriter = new StringWriter();
Console.SetOut(stringWriter);

TableOfRecordsCreator.WriteTable(TestCasesDataSource.ProfileBasic, stringWriter);
var resultStringWriter = stringWriter.ToString();

// в файл
using var streamWriter = new StreamWriter(Path);
TableOfRecordsCreator.WriteTable(TestCasesDataSource.ProfileBasic, streamWriter);
streamWriter.Close();

// из файла
using var streamReader = new StreamReader(Path);
var resultStreamReader = streamReader.ReadToEnd();
streamReader.Close();

Console.SetOut(originalConsoleOut);

Console.WriteLine(resultStringWriter);
Console.WriteLine(resultStreamReader);

bool isCollectionsEquel = resultStringWriter.Equals(resultStreamReader);
Console.WriteLine($"isCollectionsEquel: {isCollectionsEquel}");

File.Delete(Path);
*/

/* Test WriteTable_With_ProfileExtended_Class() TRUE 

string Path = "Table.txt";
TextWriter originalConsoleOut = Console.Out;

// в строку
using var stringWriter = new StringWriter();
Console.SetOut(stringWriter);

TableOfRecordsCreator.WriteTable(TestCasesDataSource.ProfileExtended, stringWriter);
var resultStringWriter = stringWriter.ToString();

// в файл
var streamWriter = new StreamWriter(Path);
TableOfRecordsCreator.WriteTable(TestCasesDataSource.ProfileExtended, streamWriter);
streamWriter.Close();

// из файла
var streamReader = new StreamReader(Path);
var resultStreamReader = streamReader.ReadToEnd();
streamReader.Close();

Console.SetOut(originalConsoleOut);

Console.WriteLine(resultStringWriter);
Console.WriteLine(resultStreamReader);

bool isCollectionsEquel = resultStringWriter.Equals(resultStreamReader);
Console.WriteLine($"isCollectionsEquel: {isCollectionsEquel}");

File.Delete(Path);
*/


/* 1.0. Запись универсальной коллекции используя TextWriter 

 var path = @"E:\collectionToFile.txt";

var collection = new List<string>()
{
    "У этого термина существуют и другие значения. ", "Ранее город был известен как Фивы. ", "Это один из древнейших городов Египта, бывшая резиденция фараонов и столица всего древнего Египта. ", "В Луксоре и вокруг города находятся некоторые из важнейших археологических мест Египта. ", "Древний Египет - одно из первых государств мира. "
};

var collection2 = new List<string>()
{
    "О проблемах не сообщается, если StringBuilder: ", "Доступ через sb.CopyTo(), sb.GetChunks(), sb.Length, или sb[index]. ", "Передан как аргумент метода на том основании, что к нему, скорее всего, будет осуществлен доступ посредством ToString()вызова. ", "Передается как параметр текущему методу на том основании, что вызываемый метод материализует строку. ", "Получено с помощью пользовательской функции ( var sb = GetStringBuilder();). ", "Возвращается методом. "
};


//TextWriter writer = new StringWriter();

//TableOfRecordsCreator.WriteTable(collection, writer);
//TableOfRecordsCreator.WriteTable(collection2, writer2);

//var Path = "Table.txt";
//TextWriter writer2 = new StreamWriter(Path);
*/

/* 1.1. Запись текста в файл с созданием файла 

string stringText = "Класс StreamReader позволяет нам легко считывать весь текст или отдельные строки из текстового файла.\nНекоторые из конструкторов класса StreamReader:\nStreamReader(string path): через параметр path передается путь к считываемому файлу\nStreamReader(string path, System.Text.Encoding encoding): параметр encoding задает кодировку для чтения файла";

var path = @"E:\stringToFile.txt";

TableOfRecordsCreator.WriteToFile(stringText, path);
*/

/* 1.2. Запись коллекции строк в файл 

var path = @"E:\collectionToFile.txt";

var collection = new List<string>()
{
    "У этого термина существуют и другие значения. ", "Ранее город был известен как Фивы. ", "Это один из древнейших городов Египта, бывшая резиденция фараонов и столица всего древнего Египта. ", "В Луксоре и вокруг города находятся некоторые из важнейших археологических мест Египта. ", "Древний Египет - одно из первых государств мира. "
};
TableOfRecordsCreator.WriteCollectionToFile(collection, path);
*/

/* 1.3. Запись текста в строку в памяти */

/* 2.1. Чтение из файла 

var path = @"E:\text.txt";

var textFromFile = TableOfRecordsCreator.ReadFromFile(path);

Console.WriteLine(textFromFile);

Console.WriteLine();
*/

/* 2.2. Чтение из строки 

string stringText = "В приведенном примере StreamReader используется для чтения строк из файла, а StringReader - для чтения из строки.\nstring используется для представления и обработки текстовых данных, а StringBuilder - для эффективного изменения строк, особенно в циклах или при работе с большими объемами данных. ";

var textFromString = TableOfRecordsCreator.ReadFromString(stringText);

Console.WriteLine(textFromString);
*/


/* ПРОБУЮ РАЗНОЕ */

/* 1.1. Перенаправление потока в файл и возвращение стандартного вывода в консоль 

// Сохраняем текущий вывод консоли
TextWriter originalConsoleOut = Console.Out;

// Создаём StreamWriter для файла
using (StreamWriter writer = new StreamWriter("output.txt", true))
{
    // Перенаправляем вывод консоли в файл
    Console.SetOut(writer);

    // Все следующие Console.WriteLine будут записаны в файл
    Console.WriteLine("Привет, привет!");
    Console.WriteLine("И снова текст попадёт в output.txt");
}

// Возвращаем вывод обратно в консоль
Console.SetOut(originalConsoleOut);

// Возврат к стандартному выводу (2-ой вариант) - НЕ работает
// Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));

Console.WriteLine("А этот текст снова выводится в консоль.");
*/

/* 1.2. Перенаправление потока в строку и возвращение стандартного вывода в консоль 

TextWriter originalConsoleOut = Console.Out;

StringWriter stringWriter = new StringWriter();
Console.SetOut(stringWriter);

// ... вывод
Console.WriteLine("Привет, привет. ");
Console.WriteLine("Опять весна. ");
Console.WriteLine("Опять хочу сказать тебе. ");
Console.WriteLine("Какая радость к нам пришля. ");
Console.Write("Опять любовь. ");
Console.WriteLine("Весна в душе. ");

// Получаем итоговую строку
string captured = stringWriter.ToString();

Console.SetOut(originalConsoleOut);
Console.WriteLine(captured);
*/

/*1.3. Отображение ошибок при перенаправлении потоков 

TextWriter originalConsoleOut = Console.Out;

try
{
    using (StreamWriter writer = new StreamWriter("output.txt"))
    {
        Console.SetOut(writer);
        Console.WriteLine("Запись в файл...");

        // Симулируем потенциальную ошибку
        // throw new IOException("Тестовая ошибка записи.");
    }

    Console.SetOut(originalConsoleOut);
    Console.WriteLine("Файл записан успешно.");
}
catch (IOException ex)
{
    Console.SetOut(originalConsoleOut); // Восстановим вывод
    Console.WriteLine($"Ошибка ввода/вывода: {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.SetOut(originalConsoleOut);
    Console.WriteLine($"Нет доступа к файлу: {ex.Message}");
}

// не желательно обрабатывать общие исключения
//catch (Exception ex)
//{
//    Console.SetOut(originalConsoleOut);
//    Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
//}
*/

/* 1.4. Надежная обработка ошибок 

// Устанавливаем глобальный обработчик исключений для всех потоков
AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;

TextWriter originalConsoleOut = Console.Out;

// Для WinForms/WPF можно также использовать:
// Application.ThreadException += UIThreadExceptionHandler;

try
{
    // Основная логика
    Console.WriteLine("Запуск приложения...");
    throw new InvalidOperationException("Тестовое исключение."); // симуляция ошибки
}
catch (UnauthorizedAccessException ex)
{
    Console.SetOut(originalConsoleOut);
    Console.WriteLine($"Нет доступа к файлу: {ex.Message}");
}
// не желательно обрабатывать общие исключения
//catch (Exception ex)
//{
//    LogException("Обработано в Main", ex);
//}

// Обработка исключений, не пойманных обычным try-catch
static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
{
    Exception ex = e.ExceptionObject as Exception;
    LogException("Непойманное исключение", ex);

    // Важно: при критических ошибках желательно завершить приложение
    Environment.Exit(1);
}

static void LogException(string source, Exception ex)
{
    Console.Error.WriteLine($"[{source}] {ex.GetType().Name}: {ex.Message}");
    File.AppendAllText("error.log",
        $"[{DateTime.Now}] {source} {ex.GetType().Name}: {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}");
}
*/

/* 1.5. Пример на форматирование строки с помощью string.Format 

StringBuilder sb = new StringBuilder();

// Пример данных
string[] column1 = { "Item1", "Item2", "Item3" };
string[] column2 = { "Description1", "Description2", "Description3" };
string[] column3 = { "10.00", "20.50", "15.75" };

// Ширина колонок
int col1Width = 10;
int col2Width = 15;
int col3Width = 8;

// Заголовок таблицы
sb.AppendLine(string.Format("{0,-" + col1Width + "}{1,-" + col2Width + "}{2,-" + col3Width + "}", "Column 1", "Column 2", "Column 3"));
sb.AppendLine(new string('-', col1Width + col2Width + col3Width + 2)); // Разделитель

// Данные
for (int i = 0; i < column1.Length; i++)
{
    sb.AppendLine(string.Format("{0,-" + col1Width + "}{1,-" + col2Width + "}{2,-" + col3Width + "}", column1[i], column2[i], column3[i]));
}

Console.WriteLine(sb.ToString());
*/

var originalOut = Console.Out;

// в строку
using var stringWriter = new StringWriter();
Console.SetOut(stringWriter);

TableOfRecordsCreator.WriteTable(TestCasesDataSource.ProfileBasicCollection, stringWriter);
var resultStringWriter = stringWriter.ToString();

// из файла данных
var exampleString = TestCasesDataSource.ProfileBasicTable;

Console.SetOut(originalOut);

Console.WriteLine(resultStringWriter);
Console.WriteLine(exampleString);

bool isCollectionsEquel = resultStringWriter.Equals(exampleString);
Console.WriteLine($"isCollectionsEquel: {isCollectionsEquel}");