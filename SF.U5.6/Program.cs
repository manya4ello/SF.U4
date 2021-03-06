/// Задание 5.6 

using System;
class UserType
{
    public string name;
    public string surname;
    public int age;
    public string[] pets;
    public string[] favcolors;
    
    ///Печать данных пользователя
    public void PrintUser()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("_________________________\nАНКЕТА ПОЛЬЗОВАТЕЛЯ \n-------------------------\nФИО: {0} {1} \nВозраст: {2}", surname, name, age);
        Console.WriteLine("Домашние животные:");
        foreach (string i in pets)
            Console.WriteLine(i);
        Console.WriteLine("Любимые цвета: ");
        foreach (string i in favcolors)
            Console.WriteLine(i);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
class MainClass
{
    public static void Main()
    {
      
    UserType User;
       User = EnterUser();

        User.PrintUser();
 

         static UserType EnterUser()
        {
            UserType User = new UserType();

            Console.Write("Добрый день! \nВведите ваше имя: ");
            User.name = GetName();
            Console.Write("Введите фамилию: ");
            User.surname = GetName();
            Console.Write("Ваш возраст: ");
            User.age = GetAge();
            
            User.pets = GetPet();
            User.favcolors = Getcolors();
            return User;
        }

        ///Проверка ввода Имени/Фамилии. Проверяет, что не цифра и не ""
        static string GetName ()
        {
            string? inputstr = String.Empty;
            bool check;
            int check2;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
               Console.SetCursorPosition(x, y); 
                inputstr = Console.ReadLine ();
                check = int.TryParse(inputstr, out check2) | (string.IsNullOrWhiteSpace(inputstr));
                
            }
            while (check);
            
            return inputstr;
        }

        ///Проверка ввода возраста. Проверяет, что цифра в диапазоне 1-100
        static int GetAge()
        {
            string? inputstr = String.Empty;
            int age = 0;
            bool check;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition(x, y);
                inputstr = Console.ReadLine();
                check = !int.TryParse(inputstr, out age) | (inputstr == "");
                if (!check && (age<1 | age>100))
                    {
                    Console.Write("Видимо вы ошиблись, попробуйте еще раз: ");
                    (x, y) = Console.GetCursorPosition();
                }

            }
            while (check | (age<1 | age>100));

            return age;
        }

        ///Ввод животных
        static string[] GetPet()
        {
            string[] pets;
            Console.Write("У Вас есть домашние питомцы? (д/н): ");
            string? inputstr = String.Empty;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition(x, y);
                inputstr = Console.ReadLine();
               
            }
            while (!(inputstr == "д" | inputstr == "н"));
            
            if (inputstr == "н")
                pets = new [] { "Отсутствуют" };
            else
            {
                Console.Write("Сколько их у вас: ");
                int petnum = GetAge(); //можно сделать другую проверку, но число от 1 до 100 вполне подходит
                pets = new string[petnum];
                for (int i = 0; i < petnum; i++)
                {
                    Console.Write("Питомец {0}: ", i + 1);
                    pets[i] = GetName();
                }
            }
                       

            return pets;
        }

        ///Ввод цветов
        static string[] Getcolors()
        {
            string[] favcolors;
            Console.Write("У Вас есть любимые цвета? (д/н): ");
            string? inputstr = String.Empty;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
                Console.SetCursorPosition(x, y);
                inputstr = Console.ReadLine();

            }
            while (!(inputstr == "д" | inputstr == "н"));

            if (inputstr == "н")
                favcolors = new[] { "Отсутствуют" };
            else
            {
                Console.Write("Сколько их у вас: ");
                int petnum = GetAge(); //можно сделать другую проверку, но число от 1 до 100 вполне подходит
                favcolors = new string[petnum];
                for (int i = 0; i < petnum; i++)
                {
                    Console.Write("Цвет {0}: ", i + 1);
                    favcolors[i] = GetName(); //требования те же, что и к имени, поэтому использовал этот метод
                }
            }


            return favcolors;
        }
       
       
    }
}