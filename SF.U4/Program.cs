using System;

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

        *//*  var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 , 0, -5};
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
      Console.WriteLine("\n Сумма массива {0}",sum);  

          (string Name, String [] Dishes) User;
          User.Dishes = new string[5];

          Console.Write("Введите имя: ");
          User.Name = Console.ReadLine();


          for (int i = 0; i < User.Dishes.Length; ++i)
          {
              Console.WriteLine("Введите любимое блюдо {0}: ", i + 1);
              User.Dishes[i] = Console.ReadLine();
          }
        
        int[,] arr = new int[,] { { -5, 6, 9, 1, 2, -3 }, { -8, 8, 1, 1, 2, -3 } };
        Console.WriteLine(arr.GetUpperBound(0));
        Console.WriteLine(arr.GetUpperBound(1));
        int min = 0;
        for (int i = 0; i <= arr.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= arr.GetUpperBound(1); j++)
            {
                for (int k = j + 1; k <= arr.GetUpperBound(1); k++)
                    if (arr[i, j] > arr[i, k])
                    {
                        min = arr[i, k];
                        arr[i, k] = arr[i, j];
                        arr[i, j] = min;
                    }
                Console.Write(arr[i,j] + " ");                
            }
            Console.WriteLine();
        }  
        int[][] numbers = new int[3][];
        numbers[0] = new int[] { 1, 2 };
        numbers[1] = new int[] { 1, 2, 3 };
        numbers[2] = new int[] { 1, 2, 3, 4, 5 };
        foreach (int[] row in numbers)
        {
            foreach (int number in row)
            {
                Console.Write($"{number} \t");
            }
            Console.WriteLine();
        }

        // перебор с помощью цикла for
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers[i].Length; j++)
            {
                Console.Write($"{numbers[i][j]} \t");
            }
            Console.WriteLine();
        }  */
        
        (string name, int age) anketa;

        Console.Write("Введите имя: ");
        anketa.name = Console.ReadLine();
        Console.Write("Введите возраст с цифрами: ");
        anketa.age = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ваше имя: {0}", anketa.name);
        Console.WriteLine("Ваш возраст: {0}", anketa.age);
        ShowColor(anketa.name);

        void ShowColor(string username)
            {
            string? color = null;
            while (color != "stop")
            {
                Console.WriteLine("{0}, напишите свой любимый цвет на английском с маленькой буквы", username);

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
        }

            Console.ReadKey(); 
        }
    }