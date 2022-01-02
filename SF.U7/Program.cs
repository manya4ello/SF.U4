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
	public abstract Address Address { get; set;}
	public abstract double Price { get; set; }
	public abstract void DeliveryMethod();
	
}

class HomeDelivery : Delivery
{
	protected double _price;
	public override double Price
	{
		get { return _price; }
		set { _price = value; }
	}
	public override Address Address { get; set; }
	public override void DeliveryMethod()
	{
	Console.WriteLine("Доставка на дом");
	}
}

class Pickpoint
{
	public Address[] addresses;
	
	public Pickpoint(Address[] pickpoints) => addresses = pickpoints;
	/// <summary>
	/// Индексация адресов Пикпоинтов
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public Address this [int index]
		 {
        get => addresses[index];
        set => addresses[index] = value;
    }
}
class PickPointDelivery : Delivery
{
	protected double _price = 100.5;
	public override double Price
	{
		get { return _price; }
		set { Console.WriteLine("Доставка до точки сбора стоит {0} руб.",_price); }
	}
	protected static Address _PPAddr = new Address();
	public override Address Address { get => _PPAddr; set => _PPAddr = value; }
	
	public override void DeliveryMethod()
	{
		Console.WriteLine("Доставка до точки сбора");
	}
}

class ShopDelivery : Delivery
{
	public override double Price {
		get { return 0; }
		set { Console.WriteLine("Самовывоз осуществляется бесплатно"); }
	}
	protected static Address ShopAddr = new Address{ Street = "Большая Семёновская", House = 26, City = "Москва", Country = "Россия", PostalCode = "107023" };
	public override Address Address 
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

	List<Product> Cart = new List<Product>();

	public void DisplayAddress()
	{
		Console.WriteLine(Delivery.Address);
	}

	// ... Другие поля
}

class Product
{
	public int ID;
	public int Quantity;
	protected double _Price;
	public double Price 
	{ get => _Price; 
		set { if (value > 0)
				_Price = value;		} 
	}
		
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
	protected long _phone;
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
	protected string _Street;
	protected int _house;
	protected int _Appartment;
	protected string _City;
	protected string _Country;
	protected string _PostalCode;
	public string? Description { get; set; }
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
		_Street = _Street.GetName();

		Console.Write("Дом: ");
		_house = _house.GetNumber();

		Console.Write("Квартира: ");
		_Appartment = _Appartment.GetNumber();

		Console.Write("Город: ");
		_City = _City.GetName();

		Console.Write("Страна: ");
		_Country = _Country.GetName();

		Console.Write("Почтовый индекс: ");
		_PostalCode = Console.ReadLine();
		if (_PostalCode.Length > 6)
			_PostalCode = _PostalCode.Substring(0, 6);
	}
	///Получение адреса в виде строки
	public string Show()
    {
		string address = $"{ Description}Улица {_Street}, д.{_house}, кв.{_Appartment}, {_City}, {_Country}, {_PostalCode}";
		return address;
	}
	
	
	}

/// <summary>
/// Метод расширения типа int
/// </summary>
public static class IntExtansion
{
	///Проверка ввода числа. Проверяет, что число и оно положительное
	public static int GetNumber(this int number)
	{
		string? inputstr = String.Empty;
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
}

/// <summary>
/// Метод расширения типа string
/// </summary>
public static class StringExtansion
{
	///Проверка ввода Имени Собственного. Проверяет, что не цифра и не ""
	public static string GetName(this string inputstr)
	{
		inputstr = String.Empty;
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
		
		inputstr = inputstr.FLetterUp();
		return inputstr;
	}

	public static string FLetterUp (this string inputstr)
    {
		if (String.IsNullOrEmpty(inputstr))
			return string.Empty;
		else
			return string.Format("{0}{1}", char.ToUpper(inputstr[0]), inputstr.Remove(0, 1));
		}

}


class Program
{
	static void Main()
	{
		///создаем точки доставки
		Pickpoint Mypickpoints = new Pickpoint(new[]
		{ new Address  { Description ="PickPoint №1: ", Street = "Измайловский Вал", House = 2, City = "Москва", Country = "Россия", PostalCode = "105318"},
		new Address { Description ="PickPoint №2: ", Street = "Комсомольская площадь", House = 3, City = "Москва", Country = "Россия", PostalCode = "107140"}});

		Console.WriteLine(Mypickpoints[1].Show());



		/* List <Product> inStock = new List <Product>();
		inStock.Add(new Tshort { ID = 1 });

		Console.WriteLine(inStock[0].GetType);
		Console.WriteLine(inStock[0].Description);
		
		
		Ввод товаров
		у каждого товара кол-во
		 
		Ввод данных покупателя
		формирование заказа
		выбор способа доставки


		 */

		///создаем Покупателя
		User buyer = new User("Петр Иванов", "79153981765");
		buyer.Address.Description = "Домашний адресс: ";
		buyer.Address.Street = "Измайловский Вал";
		buyer.Address.House = 2;
		buyer.Address.City = "Москва";
		buyer.Address.Country = "Россия";
		buyer.Address.PostalCode = "105318";
		buyer.Address.Appartment = 1;
		
		Console.WriteLine($"{buyer.Name},\nТел.: \t{buyer.Phone} \n{buyer.Address.Show()}");
       

       

        Console.ReadKey();
	}
}