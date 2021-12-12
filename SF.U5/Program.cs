using System;

class MainClass
{
    public static void Main(string[] args)
    {
       /* int rows = 0;
        int collumns = 0;
        Console.WriteLine("Введите колличество строк в массиве:");
        rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите колличество столбцов в массиве:");
        collumns = int.Parse(Console.ReadLine());

        int[,] Array = new int[rows, collumns];

       Array = GetArray(rows, collumns); */
       int [,] Array = { { 1, 2, 3, 4,}, { 7,6,5,2} };

        Console.WriteLine("Оригинальный массив:\n");
        PrintArray(Array);


        WantSort(Array);
        WantSort(Array);

        Console.WriteLine("Оригинальный массив:\n");
        PrintArray(Array);


        //Спрашивает отсортировать и если да, то как
        static void WantSort(in int[,] unsortedarray)
        {
            Console.Write("Хотите отсортировать? \n1-по убыванию \n2-по возрастанию \nиначе-не сортировать \n");

            var key = Console.ReadLine();

            int[,] sortedarray = unsortedarray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (key)
            {
                case "1":
                    Console.WriteLine("Массив отсортирован по убыванию");
                    SortArray(unsortedarray, out sortedarray, true);
                    PrintArray(sortedarray);
                    break;
                case "2":
                    Console.WriteLine("Массив отсортирован по возрастанию");
                    SortArray(unsortedarray, out sortedarray, false);
                    PrintArray(sortedarray);
                    break;
                default:
                    Console.WriteLine("Массив не отсортирован");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
           
        }

        //Организует ввод двухмерного массива
        static int[,] GetArray(int Rows, int Collumns)
        {
            int[,] array = new int[Rows, Collumns];
            bool key = true;
            int value;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите значения");
            Console.ForegroundColor = ConsoleColor.White;

            (int cursorx, int cursory) = Console.GetCursorPosition();
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Collumns; ++j)
                {
                    try
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("R{0}/C{1} ", i + 1, j + 1);
                        Console.SetCursorPosition(cursorx, cursory + 1);
                        key = int.TryParse(Console.ReadLine(), out value);
                        if (key)
                        {
                            array[i, j] = value;
                            cursorx += 10;
                        }
                        else
                            j--;

                    }
                    catch
                    {
                        cursory += 3;
                        cursorx = 0;
                        j--;
                    }
                }
                cursory += 3;
                cursorx = 0;
            }
            Console.WriteLine();    
            return array;
        }

        //Сортирует
        static void SortArray(in int[,] unsortedarray, out int[,] SortedArray, bool compmeth = true)
        {
            Console.WriteLine("Получил");
            PrintArray(unsortedarray);

            int rows = unsortedarray.GetUpperBound(0) + 1;
            int cols = unsortedarray.GetUpperBound(1) + 1;
            int temp;
            SortedArray = unsortedarray;
            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    for (int k = j; k < cols; ++k)
                    {
                        if ((compmeth && SortedArray[i, j] < SortedArray[i, k]) | (!compmeth && SortedArray[i, j] > SortedArray[i, k]))
                        {
                            temp = unsortedarray[i, j];
                            SortedArray[i, j] = SortedArray[i, k];
                            SortedArray[i, k] = temp;
                        }

                    }
        }
        
        //Печатает массив
        static void PrintArray(in int[,] array)
        { 
            (int cursorx, int cursory) = Console.GetCursorPosition();
            Console.WriteLine();
            for (int i = 0; i < array.GetUpperBound(0) + 1; ++i)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("R{0}:", i);
                Console.ForegroundColor = ConsoleColor.White;
                for (int j = 0; j < array.GetUpperBound(1) + 1; ++j)
                {
                    if (i == 0)
                    {
                        (cursorx, cursory) = Console.GetCursorPosition();
                        Console.SetCursorPosition(cursorx, cursory - 1);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\tC{0}", j);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(cursorx, cursory);
                    }
                    Console.Write("\t{0}", array[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}