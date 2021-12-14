// Задание 5.6 

using System;

class MainClass
{
    public static void Main()
    {
        (string name, string surname, int age, string[] pets, string[] favcolors) User;

        User = EnterUser();
        static (string name, string surname, int age, string[] pets, string[] favcolors) EnterUser()
        {
            (string name, string surname, int age, string[] pets, string[] favcolors) User;

            Console.Write("Добрый день! \nВведите ваше имя: ");
            User.name = GetName();
            Console.Write("Введите фамилию: ");
            User.surname = GetName();
            Console.Write("Ваш возраст: ");
            User.age = GetAge();
            User.pets = new string[1];
            User.favcolors = new string[1];
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
    }
}