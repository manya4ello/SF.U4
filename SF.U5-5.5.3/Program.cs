// Задание 5.5.3

using System;

class MainClass
{
    public static void Main(string[] args)
     {
         Console.Write("Скажите что-нибудь: ");
         string saidword = Console.ReadLine();

         Console.Write("Глубина эхо: ");
         int deep;
         try
         {
             deep = int.Parse(Console.ReadLine());
          }
         catch
         {
             Console.WriteLine("Ок. Сами разберемся");
             deep = saidword.Length /2;
         }
         Console.WriteLine("Поехали! \n{0}", saidword);
         Echo(saidword, deep);

         static void Echo (string word, int deep)
         {
             string modified = word;
             if (modified.Length > 2)
                 modified = modified.Remove(0, 2);
             else modified = "";

             int color = deep;
             while (color > 15)
                 color -=15;
             Console.BackgroundColor = (ConsoleColor)color;
             Console.WriteLine("..." + modified);
             Console.BackgroundColor = ConsoleColor.Black;
             if (deep > 1)
                 Echo(modified, deep - 1);
         }

     } 
}