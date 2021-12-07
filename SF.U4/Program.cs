using System;
using System.Text;
class MainClass
{
	public static void Main(string[] args)
	{
        /* string color = "hello";

        while (color != "stop")
        {
            Console.WriteLine("Напишите свой любимый цвет на английском с маленькой буквы");

            color = Console.ReadLine();

            switch (color)
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is red!");
                    break;

                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is green!");
                    break;

                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is cyan!");
                    break;
                default:
                    continue;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("цикл дошел до конца");
        }
        
        Console.Write("Введите имя: ");
    string name = Console.ReadLine();
    Char [] backname = new char [name.Length];
    int i = 0;
    foreach (var ch in name)
    {    backname[name.Length - 1 - i] = name[i];
        i++;
    }
    Console.Write(backname); 

    int[,] array = { { 1, 2, 3 }, { 5, 6, 7 } };
    Console.WriteLine(array[0, 0]);
    foreach (int i in array)
        Console.WriteLine(i); 

    int[,] array = { { 1, 2, 3 }, { 5, 6, 7 }, { 8, 9, 10 }, { 11, 12, 13 } };

    for (int i = 0; i < array.GetUpperBound(1) + 1; i++)
    {
        for (int k = 0; k < array.GetUpperBound(0) + 1; k++)
            Console.Write(array[k, i] + " ");

        Console.WriteLine();
    }

        var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 , 0, -5};
    int temp;
    for (var k = 0; k < arr.Length; k++)
    {
        for (var i = k + 1; i < arr.Length; i++)
        {
            if (arr[k] > arr[i])
            {
                temp = arr[i];
                arr[i] = arr[k];
                arr[k] = temp;
            }
        }
        Console.Write(arr[k]+" ");
    }
    int sum = 0;
    foreach (var i in arr)
        sum += i;
    Console.WriteLine("\n Сумма массива {0}",sum);  */


        StringBuilder sb = new StringBuilder("Привет мир");
        sb.Append("!");
        sb.Insert(7, "компьютерный ");
        Console.WriteLine(sb);

        // заменяем слово
        sb.Replace("мир", "world");
        Console.WriteLine(sb);

        // удаляем 13 символов, начиная с 7-го
        sb.Remove(7, 13);
        Console.WriteLine(sb);

        // получаем строку из объекта StringBuilder
        string s = sb.ToString();
        Console.WriteLine(s);

        Console.ReadKey(); 
        }
    }