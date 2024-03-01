using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Linq;
public class Book
{
    public string nameOfBook;
    public int date;
    public string author;

    public Book(string nob, string afb, int db)
    {
        nameOfBook = nob;
        date = db;
        author = afb;
    }
    public Book(string nob, int db)
    {
        nameOfBook = nob;
        date = db;
    }
    public Book(string nob)
    {
        nameOfBook = nob;
    }
    public Book(string nob, string afb)
    {
        nameOfBook = nob;
        author = afb;
    }

    public void Year(int age)
    {
        Console.WriteLine($"На данный момент книге {2024 - age} лет");
    }

    public void Compare(string nameFirst, int ageFirst,string nameSecond, int ageSecond)
    {
        if (ageFirst > ageSecond) 
        {
            Console.WriteLine($"книга '{nameFirst}' была написана позже на {ageFirst - ageSecond}");
        }
        else if (ageSecond > ageFirst)
        {
            Console.WriteLine($"книга '{nameSecond}' была написана позже на {ageSecond - ageFirst }");
        }
        else
        {
            Console.WriteLine("обе книги были написаны в один год");
        }
    }


}









class Player
{
    public string Login { get; private set; }
    public int Level { get; private set; }

    public Player(string login, int level)
    {
        Login = login;
        Level = level;
    }
}
class Program
{
    static void Main(string[] args)
    {
        // task 8
        
        List<Player> players = new List<Player>
        {
            new Player("sultana", 150),
            new Player("Sultan", 200),
            new Player("Natlus", 164),
            new Player("Sula", 175),
            new Player("Sul", 284),
            new Player("tan", 134)
        };

        List<Player> newPlayers = new List<Player>
        {
            new Player("abc", 155),
            new Player("cba", 185),
            new Player("dfa", 173),
            new Player("fds", 157)
        };

        var filtredPlayers = players.Where(player => player.Level >= 150).OrderByDescending(player => player.Level);

        foreach (var player in filtredPlayers)
        {
            Console.WriteLine(player.Login);
        }

        var groupPlayers = players.Union(newPlayers);
        groupPlayers = groupPlayers.OrderBy(player => player.Level);

        Console.WriteLine("_____________________");

        foreach (var gPlayer in groupPlayers)
        {
            Console.WriteLine(gPlayer.Login);
        }
        
        //7) Многопоточность: Напишите программу, использующую многопоточность для выполнения некоторых операций параллельно. Например, вы можете создать несколько потоков для одновременной обработки данных.
        Console.ReadKey();
        Thread myThread = new Thread(test);
        myThread.Start();
        void test()
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"второй поток: {sum = sum + i}");
                Thread.Sleep(400);
            }
        }
        
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(500);      // задержка выполнения на 500 миллисекунд
            Console.WriteLine($"первый поток: {i}");
        }



        //6) ООП: Создание классов: Определите класс для представления книги с полями, такими как название, автор, год выпуска и т. д.Создайте несколько экземпляров этого класса и выполните с ними различные операции.
        Console.ReadKey();
        var julesVerne = new Book("The mysterious island", "Jules Verne", 1875);
        var khaledHosseini = new Book("The Kite Runner", "Khaled Hosseini", 2003);

        julesVerne.Year(julesVerne.date);
        khaledHosseini.Year(khaledHosseini.date);
        julesVerne.Compare(julesVerne.nameOfBook,julesVerne.date,khaledHosseini.nameOfBook,khaledHosseini.date);


        //5) Работа с файлами: Напишите программу, которая читает содержимое текстового файла, выполняет какие - то манипуляции(например, подсчет слов или замена определенных символов) и записывает результат в новый файл. 


        
        string path = @"C:\Users\skurm\content.txt"; //путь нужно поменять
        string pathEdit = @"C:\Users\skurm\contentEdit.txt";
        string text = "Sultan, hello";
        int lenSymbol;
        using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
        {
            byte[] buffer = Encoding.Default.GetBytes(text);
            fstream.Write(buffer, 0, buffer.Length);
            Console.WriteLine("Текст записан в файл");
        }


        using (FileStream fstream = File.OpenRead(path))
        {
            byte[] buffer = new byte[fstream.Length];
            fstream.Read(buffer, 0, buffer.Length);
            string textFromFile = Encoding.Default.GetString(buffer);
            Console.WriteLine($"Текст из файла: {textFromFile}");
            lenSymbol = textFromFile.Length;
            Console.WriteLine($"Количество символов {lenSymbol}");
        }


        using (FileStream fstreamEdit = new FileStream(pathEdit, FileMode.OpenOrCreate))
        {
            byte[] buffer = Encoding.Default.GetBytes(Convert.ToString(lenSymbol));
            fstreamEdit.Write(buffer, 0, buffer.Length);
            Console.WriteLine("Текст записан в файл");
        }


        //4) Работа со строками:Создайте программу, которая принимает строку от пользователя и выполняет различные операции с ней: подсчет количества символов, замена подстроки, разделение строки на слова и т.д.
        string replace(string userText)
        {
            Console.WriteLine("какой символ заменить? ");
            string replace = Console.ReadLine();
            Console.WriteLine("На какой символ заменить? ");
            string replaceTo = Console.ReadLine();
            string userTextEdit = "";
            userText = userText.ToLower();
            for (int i = 0; i < userText.Length; i++)
            {
                if (userText[i] == replace[0])
                {
                    userTextEdit = userTextEdit + replaceTo[0];
                    continue;
                }
                userTextEdit = userTextEdit + userText[i];
            }
            Console.WriteLine($"сделано с помощью цикла {userTextEdit}");
            string textEdit = userTextEdit.Replace(replace, replaceTo);
            Console.WriteLine($"сделано с помощью метода replace {textEdit}");

            return textEdit;
        }

        string deleteSymbol(string userText)
        {
            Console.Write("какой символ удалить?: ");
            string deleteSymbol = Console.ReadLine();
            string deleteTextEdit = "";
            userText = userText.ToLower();
            for (int i = 0; i < userText.Length; i++)
            {
                if (userText[i] == deleteSymbol[0])
                {
                    continue;
                }
                deleteTextEdit = deleteTextEdit + userText[i];
            }
            Console.WriteLine(deleteTextEdit);

            return deleteTextEdit;
        }

        string backward(string userText)
        {
            string userTextEdit = "";
            for (int i = (userText.Length - 1); i >= 0; i--)
            {
                userTextEdit = userTextEdit + userText[i];
            }
            Console.WriteLine(userTextEdit);
            return userTextEdit;
        }

        Console.Write("Введите строку: ");
        string userInput = Console.ReadLine();

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Выбери действие (цифрами): ");
            Console.ResetColor();
            int choice = Convert.ToInt32(Console.ReadLine()) ;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("конкатенация");
                    Console.Write("сколько конкатенаций сделать?: ");
                    int userNumCon = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < userNumCon; i++)
                    {
                        Console.Write($"{userInput}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------");
                    break;
                case 2:
                    Console.WriteLine("повтор строки в столбик");
                    Console.Write("сколько раз вывести строку?: ");
                    int userNumRepeat = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < userNumRepeat; i++)
                    {
                        Console.WriteLine($"{i + 1}) {userInput}");
                    }
                    
                    Console.WriteLine("-------------------------------------------");
                    break;
                case 3:
                    userInput = deleteSymbol(userInput);
                    Console.WriteLine("удаление символа");
                    Console.WriteLine("-------------------------------------------");
                    break;
                case 4:
                    Console.WriteLine("замена символа");
                    userInput = replace(userInput);
                    
                    Console.WriteLine("-------------------------------------------");
                    break;
                case 5:
                    Console.WriteLine("данные о строке");
                    int strLen = userInput.Length;
                    Console.WriteLine("lower: " + userInput.ToLower());
                    Console.WriteLine("ToUpper: " + userInput.ToUpper());
                    Console.WriteLine($"Количество символов: {strLen}");
                    Console.WriteLine("-------------------------------------------");
                    break;
                case 6:
                    Console.WriteLine("задом наперед строка");
                    backward(userInput);
                    Console.WriteLine("-------------------------------------------");
                    break;
                default:
                    break;
            }
        }


        

        //3) Конвертер температуры: Напишите программу, которая конвертирует температуру из градусов
// Цельсия в градусы Фаренгейта и наоборот. Пользователь должен вводить температуру и единицы измерения, программа должна выводить результат.
        while (true)
        {
            float celsius, fahrenheit;
            const float cToF = 5/9f;
            const float fToC = 9 / 5f;
            Console.Write("Градус: ");
            string userInputNum = Console.ReadLine();
            bool checkNum = float.TryParse(userInputNum, out float num);
            Console.WriteLine("в чем измеряется (C-Цельсия, F-Фаренгейты): ");
            string userInputDegree = Console.ReadLine();
            bool checkDegree = char.TryParse(userInputDegree, out char degree);
            if (checkDegree && checkNum)
            {
                if (degree == 'F' || degree == 'f' || degree == 'ф' || degree == 'Ф')
                {
                    celsius = (num - 32) * cToF;
                    Console.WriteLine(celsius);
                    Console.ReadKey();
                }
                else if (degree == 'C' || degree == 'С' || degree == 'c' || degree == 'с')
                {
                    fahrenheit = (num * fToC) + 32;
                    Console.WriteLine(fahrenheit);
                    Console.ReadKey();
                }
            }
            Console.Clear();
        }

        //2) Список задач: Создайте консольное приложение для управления списком задач.Пользователь должен иметь возможность добавлять, удалять и отмечать задачи как выполненные.
        var tasks = new List<string>() { };
        while (true)
        {
            Console.Write("выбери: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("добавить задачу");
                    string userTaskAdd = Console.ReadLine();
                    tasks.Add(userTaskAdd);
                    break;
                case 2:
                    Console.WriteLine("удалить задачу");
                    int i = 1;
                    foreach (string task in tasks)
                    {
                        Console.WriteLine(i + ") " + task);
                        i++;
                    }
                    Console.Write("какую задачу удалить: ");
                    int delete = Convert.ToInt32(Console.ReadLine()) - 1;
                    tasks.RemoveAt(delete);
                    break;
                case 3:
                    Console.WriteLine("отметить выполненой задачу"); //взять задачу в скобки и написать выполнено
                    Console.Write("какая задача выполнена: ");
                    int completed = Convert.ToInt32(Console.ReadLine()) - 1;
                    tasks[completed] = "(" + tasks[completed] + ")" + " выполнено";
                    break;
                case 4:
                    Console.WriteLine("просмотреть задачи");
                    int j = 1;
                    foreach (string task in tasks)
                    {
                        Console.WriteLine(j + ") " + task);
                        j++;
                    }
                    break;
                default:
                    break;
            }
        }


        //1) Калькулятор:
        //Напишите консольное приложение, которое выполняет основные математические операции: сложение, вычитание, умножение и деление.Программа должна запрашивать у пользователя ввод двух чисел и оператора, затем выводить результат.
        while (true)
        {
            float result = 0;
            Console.Write("первое число:");
            string firstNumInput = Console.ReadLine();
            bool firstNumCheck = float.TryParse(firstNumInput, out float firstNum);
            Console.Write("второе число:");
            string secondNumTemp = Console.ReadLine();
            bool secondNumCheck = float.TryParse(secondNumTemp, out float secondNum);
            Console.Write("оператор");
            string a = Console.ReadLine();
            bool checkChar = char.TryParse(a, out char operatorChar);
            if (checkChar && secondNumCheck && firstNumCheck)
            {
                if (operatorChar == '+')
                {
                    result = firstNum + secondNum;
                    Console.WriteLine(result);
                }
                else if (operatorChar == '-')
                {
                    result = firstNum - secondNum;
                    Console.WriteLine(result);
                }
                else if (operatorChar == '*')
                {
                    result = firstNum * secondNum;
                    Console.WriteLine(result);
                }
                else if (operatorChar == '/')
                {
                    result = firstNum / secondNum;
                    Console.WriteLine(result);
                }
                else {
                    Console.WriteLine("оператор введен неверно");
                }
               
            }
            else
            {
                if (!checkChar)
                {
                    Console.WriteLine("оператор введен неверно");
                }
                if (!firstNumCheck)
                {
                    Console.WriteLine("первое число введено неверно");
                }
                if (!secondNumCheck)
                {
                    Console.WriteLine("второе число введено неверно");
                }


            }

        }
    }
}


