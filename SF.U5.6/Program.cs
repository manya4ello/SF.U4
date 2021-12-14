// Задание 5.6 

using System;

class MainClass
{
    public static void Main()
    {
        (string name, string surname, int age, string[] pets, string[] favcolors) User;

        User = EnterUser();

        PrintUser(User);
 

         static (string name, string surname, int age, string[] pets, string[] favcolors) EnterUser()
        {
            (string name, string surname, int age, string[] pets, string[] favcolors) User;

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

        //Проверка ввода Имени/Фамилии. Проверяет, что не цифра и не ""
        static string GetName ()
        {
            string inputstr = "";
            bool check;
            int check2;
            (int x, int y) = Console.GetCursorPosition();
            do
            {
               Console.SetCursorPosition(x, y); 
                inputstr = Console.ReadLine ();
                check = int.TryParse(inputstr, out check2) | (inputstr == "");
                
            }
            while (check);
            
            return inputstr;
        }

        //Проверка ввода возраста. Проверяет, что цифра в диапазоне 1-100
        static int GetAge()
        {
            string inputstr = "";
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

        //Ввод животных
        static string[] GetPet()
        {
            string[] pets;
            Console.Write("У Вас есть домашние питомцы? (д/н): ");
            string inputstr = "";
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

        //Ввод цветов
        static string[] Getcolors()
        {
            string[] favcolors;
            Console.Write("У Вас есть любимые цвета? (д/н): ");
            string inputstr = "";
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
       
        // Печать данных пользователя
        static void PrintUser ((string name, string surname, int age, string[] pets, string[] favcolors) User)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_________________________\nАНКЕТА ПОЛЬЗОВАТЕЛЯ \n-------------------------\nФИО: {0} {1} \nВозраст: {2}", User.surname, User.name, User.age);
            Console.WriteLine("Домашние животные:");
            foreach (string i in User.pets)
                Console.WriteLine(i);
            Console.WriteLine("Любимые цвета: ");
            foreach (string i in User.favcolors)
                Console.WriteLine(i);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}