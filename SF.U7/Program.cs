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
	public abstract double Price { get; set; }
	public abstract void DeliveryMethod();
	
}

class HomeDelivery : Delivery
{
	private double _price;
	public override double Price
	{
		get { return _price; }
		set { _price = value; }
	}
	public override string Address { get; set; }
	public override void DeliveryMethod()
	{
	Console.WriteLine("Доставка на дом");
	}
}

class PickPointDelivery : Delivery
{
	private double _price = 100.5;
	public override double Price
	{
		get { return _price; }
		set { Console.WriteLine("Доставка до точки сбора стоит {0} руб.",_price); }
	}
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
	public override double Price { 
		get { return 0; } 
		set { Console.WriteLine("Самовывоз осуществляется бесплатно");} 
	}
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

class Order<TDelivery> where TDelivery : Delivery
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
	public double Price { get; set; }
		
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

public class User
{
	public Address Address;
	private long _phone;
	public string Name { get; set; }
	public string Phone { get => String.Format("{0:+# (###) ###-##-##}", _phone);
		set
		{ if (long.TryParse(value, out long phone))
				_phone = phone;
			else _phone = 0;
		}
			}
	public User()
    {
		Address = new Address();
		_phone =default(int);
		Name = default(string);
    }
	public User(string name): base() 
	{
		Name = name;
	}
	public User(string name, string phone) 
	{
		Address = new Address();
		Phone = phone;
		Name = name;
		
	}
}

public class Address
{
	private string _Street;
	private int _house;
	private int _Appartment;
	private string _City;
	private string _Country;
	private string _PostalCode;

	public string Street 
	{ get { return _Street; }
		set { _Street = value; } 
	}
	public int House { get => _house;  set => _house = value; }
	public int Appartment { get => _Appartment; set { _Appartment = value; } }
	public string City	{get => _City; set => _City = value; }
	public string Country
	{
		get { return _Country; }
		set { _Country = value; }
	}
	public string PostalCode
	{
		get { return _PostalCode; }
		set { _PostalCode = value;
			if (_PostalCode.Length > 6)
				_PostalCode = _PostalCode.Substring(0, 6);
		}
	}
	/// Установить адрес поэлементно
	public void SetAdr ()
		{
		Console.Write("Улица: ");
		_Street = Getinfo.GetName();

		Console.Write("Дом: ");
		_house = Getinfo.GetNumber();

		Console.Write("Квартира: ");
		_Appartment = Getinfo.GetNumber();

		Console.Write("Город: ");
		_City = Getinfo.GetName();

		Console.Write("Страна: ");
		_Country = Getinfo.GetName();

		Console.Write("Почтовый индекс: ");
		_PostalCode = Console.ReadLine();
		if (_PostalCode.Length > 6)
			_PostalCode = _PostalCode.Substring(0, 6);
	}
	///Получение адреса в виде строки
	public string Show()
    {
		string address = $"Улица {_Street}, д.{_house}, кв.{_Appartment}, {_City}, {_Country}, {_PostalCode}";
		return address;
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

	

}

//public class Stock<T>
//{
//	public T Pposition;
//}

class Program
{
	static void Main()
	{
		List <Product> inStock = new List <Product>();
		inStock.Add(new Tshort { ID = 1 });

        /*Console.WriteLine(inStock[0].GetType);
		Console.WriteLine(inStock[0].Description);
		
		
		Ввод товаров
		На хер склад - у каждого товара кол-во
		 
		Ввод данных покупателя
		формирование заказа
		выбор способа доставки
		*/

        //string str = getinfo.getaddress();

        //console.writeline(str);

        //shopdelivery shopdelivery1 = new shopdelivery();

        //PickPointDelivery delivery = new PickPointDelivery();
        //delivery.Address = "1";

        //Console.WriteLine(delivery.Address);

        //Order<PickPointDelivery> order1 = new  Order<PickPointDelivery> {Delivery = delivery, Number=1, Description="Пробный" }; 

        //order1.DisplayAddress();

        User a = new User("Петр Иванов", "79153981765");
        //a.Address.SetAdr();
        a.Phone = "79153981765";
        a.Address.City = "Москва";

        Console.WriteLine($"{a.Name},\nТел.: \t{a.Phone} \n{a.Address.Show()}");
       

       

        Console.ReadKey();
	}
}