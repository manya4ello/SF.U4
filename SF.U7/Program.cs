/* Задание 7.7 - итоговое
 
Базовый уровень:
Использование наследования;
Использование абстрактных классов или членов класса;
Использование принципов инкапсуляции;
Использование переопределений методов/свойств;
Использование минимум 4 собственных классов;
Использование конструкторов классов с параметрами;
Использование обобщений;
Использование свойств;
Использование композиции классов.

Продвинутый уровень:
Использование статических элементов или классов;
Использование обобщенных методов;
Корректное использование абстрактных классов (использовать их там, где это обусловлено параметрами системы);
Корректное использование модификаторов элементов класса (чтобы важные поля не были доступны для полного контроля извне, использование protected);
Использование свойств с логикой в get и/или set блоках.

Усложненный уровень:
Использование методов расширения;
Использование наследования обобщений;
Использование агрегации классов;
Использование индексаторов;
Использование перегруженных операторов. */

using System;
abstract class Delivery
{
	public abstract string Address { get; set;}
	public float Price;
	public abstract void DeliveryMethod();
	
}

class HomeDelivery : Delivery
{
	public override string Address { get; set; }
	public override void DeliveryMethod()
	{
	Console.WriteLine("Доставка на дом");
	}
}

class PickPointDelivery : Delivery
{
	private static string PPAddr = String.Empty;
	public override string Address 
	{ get { return PPAddr; }
		set {
			if (int.TryParse(value, out int choice) && (choice > 0 & choice < 3))
			{
				switch (choice)
				{
					case 1:
						PPAddr = "PickPoint №1: ул. Измайловский Вал, д.2, Москва, Россия, 105318";
						break;
					case 2:
						PPAddr = "PickPoint №2: Комсомольская площадь, д.3, Москва, Россия, 107140";
						break;									}
			}
			else Console.WriteLine("Некорректный ввод данных. На данный момент PickPoint не выбран");
				
		} 
	}
	public override void DeliveryMethod()
	{
		Console.WriteLine("Доставка до точки сбора");
	}
}

class ShopDelivery : Delivery
{
	private static string ShopAddr = "Большая Семёновская ул.,д.26, Москва, Россия, 107023";
	public override string Address 
	{ get { return ShopAddr; }
	set { Console.WriteLine("Адрес магазина нельзя изменить"); }
	}
	public override void DeliveryMethod()
	{
		Console.WriteLine("Самовывоз");
	}
}

class Order<TDelivery,TStruct> where TDelivery : Delivery
{
	public TDelivery Delivery;

	public int Number;

	public string Description;

	public void DisplayAddress()
	{
		Console.WriteLine(Delivery.Address);
	}

	// ... Другие поля
}

abstract class Product
{
	public int ID;
	public int Quantity;
	public decimal Price { get; set; }
		
	public enum Origin : byte
	{
		Неизвестно = 0,
		Россия = 1,
		США,
		Китай
	}
	public virtual void Description()
	{ 
		Console.WriteLine($"Это продукт"); 
	}
}

abstract class Clothes: Product
{
	public string Material;
	public string Color; 
	public string Size;
	public enum Sex: byte
    {
		Unisex =0,
		Men,
		Women
    }
}
class Tshort: Clothes
{
	public override void Description()
	{
		Console.WriteLine("Футболка");
	}
}
class Short : Clothes
{
	
}
abstract class Shoes: Product
{
	public string Material;
	public string Color;
	public float Size;
	public enum Sex : byte
	{
		Unisex = 0,
		Men,
		Women
	}
}


public static class Getinfo
{
	///Проверка ввода числа. Проверяет, что число положительное
	public static int GetNumber()
	{
		string? inputstr = String.Empty;
		int number = 0;
		bool check;
		(int x, int y) = Console.GetCursorPosition();
		do
		{
			Console.SetCursorPosition(x, y);
			inputstr = Console.ReadLine();
			check = !int.TryParse(inputstr, out number) | (inputstr == "");
			if (!check && (number < 1))
			{
				Console.Write("Видимо вы ошиблись, попробуйте еще раз: ");
				(x, y) = Console.GetCursorPosition();
			}

		}
		while (check | (number < 1));

		return number;
	}

	///Проверка ввода Имени Собственного. Проверяет, что не цифра и не ""
	public static string GetName()
	{
		string? inputstr = String.Empty;
		bool check;
		int check2;
		(int x, int y) = Console.GetCursorPosition();
		do
		{
			Console.SetCursorPosition(x, y);
			inputstr = Console.ReadLine();
			check = int.TryParse(inputstr, out check2) | (string.IsNullOrWhiteSpace(inputstr));

		}
		while (check);
		
		inputstr = string.Format("{0}{1}", char.ToUpper(inputstr[0]), inputstr.Remove(0, 1));
		return inputstr;
	}

	///Получение адреса в виде строки
	public static string GetAddress()
	{

		Console.Write("Улица: ");
		string Street = Getinfo.GetName(); ;

		Console.Write("Дом: ");
		int house = Getinfo.GetNumber();

		Console.Write("Квартира: ");
		int Appartment = Getinfo.GetNumber();

		Console.Write("Город: ");
		string City = Getinfo.GetName();

		Console.Write("Страна: ");
		string Country = Getinfo.GetName();

		Console.Write("Почтовый индекс: ");
		string PostalCode = Console.ReadLine().Substring(0,6);

		string address = $"Улица {Street}, д.{house}, кв.{Appartment}, {City}, {Country}, {PostalCode}";
		return address;
	}

}

public class Stock<T>
{
	public T Pposition;
}

class Program
{
	static void Main()
	{
		List <Product> inStock = new List <Product>();
		inStock.Add(new Tshort { ID = 1 });

		Console.WriteLine(inStock[0].GetType);
		Console.WriteLine(inStock[0].Description);
		
		/*
		Ввод товаров
		На хер склад - у каждого товара кол-во
		 
		Ввод данных покупателя
		формирование заказа
		выбор способа доставки
		*/

		//string str = Getinfo.GetAddress(); 

		//Console.WriteLine(str);

		PickPointDelivery delivery = new PickPointDelivery();
		delivery.Address="1";

		Console.WriteLine(delivery.Address);


		Console.ReadKey();
	}
}