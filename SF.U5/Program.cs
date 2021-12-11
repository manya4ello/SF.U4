

int rows = 0;
int collumns = 0;
Console.WriteLine("Введите колличество строк в массиве:");
rows = int.Parse(Console.ReadLine());
Console.WriteLine("Введите колличество столбцов в массиве:");
collumns = int.Parse(Console.ReadLine());

int[,] Array = new int[rows, collumns];

Array = GetArray(rows, collumns);

PrintArray(Array);

WantSort(Array);
WantSort(Array);
WantSort(Array);

PrintArray(Array);

static void WantSort(int[,] array)
{
    Console.Write("Хотите отсортировать? \n1-по убыванию \n2-по возрастанию \nиначе-не сортировать \n");

    var key = Console.ReadLine();

    switch (key)
    {
        case "1":
            Console.WriteLine("Массив отсортирован по убыванию");
            array = SortArray(array, true);
            break;
        case "2":
            Console.WriteLine("Массив отсортирован по возрастанию");
            array = SortArray(array, false);
            break;
        default:
            Console.WriteLine("Массив не отсортирован");
            break;
    }
    PrintArray(array);
}
//Организует ввод двухмерного массива
static int[,] GetArray(int Rows,int Collumns)
    {
    int[,] array = new int[Rows, Collumns];
    bool key = true;
    int value;
   
    Console.WriteLine("Введите значения строки массива");

    (int cursorx, int cursory) = Console.GetCursorPosition();
    for (int i = 0; i < Rows; ++i)
    {
        for (int j = 0; j < Collumns; ++j)
        {
            try
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.WriteLine("R{0}/C{1} ", i+1,j+1);
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
    return array;
}

//Сортирует
static int[,] SortArray(int[,] array, bool compmeth)
{
    int rows = array.GetUpperBound(0)+1;
    int cols = array.GetUpperBound(1)+1;
    int temp;

    for (int i = 0;i < rows; ++i)
        for (int j = 0;j < cols; ++j)
            for (int k = j;k < cols; ++k)
            {
                if ((compmeth && array[i,j]<array[i,k]) | (!compmeth && array[i, j] > array[i, k]))
                {
                    temp = array[i,j];
                    array[i,j] = array[i,k];
                    array[i,k] = temp;
                }
               
            }
    return array;
}
//Печатает массив
static void PrintArray (int[,] array)
{
    for (int i = 0; i < array.GetUpperBound(0)+1; ++i)
    { Console.Write("R{0}:",i);
        for (int j = 0; j < array.GetUpperBound(1)+1; ++j)
            Console.Write("\t{0}",array[i,j]);
        Console.WriteLine();
            }
}

Console.ReadKey();  