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
	private double _price;
	public override double Price
	{
		get { return _price; }
		set { _price = value; }
	}
	public override Address Address { get; set; }

	public HomeDelivery(Address address)
	{
		Address = address;
	}
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
	private double _price = 100.5;
	public override double Price
	{
		get { return _price; }
		set { Console.WriteLine("Доставка до точки сбора стоит {0} руб.", _price); }
	}
	private static Address _PPAddr = new Address();
	public override Address Address { get => _PPAddr; set => _PPAddr = value; }

	public PickPointDelivery ()
		{
		_PPAddr = new Address();
	}
	public override void DeliveryMethod()
	{
		Console.WriteLine("Доставка до точки сбора");
		Console.WriteLine(Address.Show());
	}
}

class ShopDelivery : Delivery
{
	public override double Price {
		get { return 0; }
		set { Console.WriteLine("Самовывоз осуществляется бесплатно"); }
	}
	private static Address ShopAddr = new Address{ Street = "Большая Семёновская", House = 26, City = "Москва", Country = "Россия", PostalCode = "107023" };
	public override Address Address 
	{ get { return ShopAddr; }
	set { Console.WriteLine("Адрес магазина нельзя изменить"); }
	}
	public ShopDelivery()
	{
		
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

	private List<Product> _Cart;
	
	public List<Product> Cart 
	{ get => _Cart; }

	public Order(List<Product> ordered)
	{
	_Cart = ordered;
	}
	public void DisplayAddress()
	{
		Console.WriteLine(Delivery.Address);
	}
		
}

class Product
{
	public int ID {get; set; }
	//private int _Quantity;
	private double _Price;
	public double Price 
	{ get => _Price; 
		set { if (value > 0)
				_Price = value;		} 
	}
	//public int Quantity { get => _Quantity;
	//	set { if (value > 0)
	//			_Quantity = value;}
	//	}
	public string Origin;
	public Sex Sextype;
	public Type Ptype;
	public string Size;
	public enum Sex : byte
	{
		Unisex = 0,
		Men,
		Women
	}
	public enum Type: byte
    {
		Футболка,
		Шорты,
		Кроссовки
    }
	public string Description { get; set; }

	public Product (int id, string description, double price, Type type, string origin, Sex sex, string size)
    {
		ID = id;
		Description = description;
		Price = price;
		Ptype = type;
		Origin = origin;
		Sextype = sex;
		Size = size;

	}
	public string Show()
    {
		return $"#{ID}\t{Description}\tЦена: {Price}\tПроизводство: {Origin}";
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
	public User(string name, string phone, Address address)
	{
		Address = address;
		Phone = phone;
		Name = name;

	}
	public static User Deafault()
	{ 
		return new User("Петр Иванов", "79153981765", new Address ("Домашний адресс: ", "Измайловский Вал", 2, "Москва", "Россия", "105318", 1));
	}
	public static User GetUser()
	{
		User a = new User();
		Console.Write("Введите имя и фамилию: ");
		a.Name = a.Name.GetName();
		Console.Write("Введите телефон (11 цифр): ");
		long p = 0;
		p = p.GetPhone();
		a.Phone = p.ToString();
		a.Address.SetAdr();
		a.Address.Description = "Домашний адрес: ";
		return new User(a.Name, p.ToString(), a.Address);
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
	public Address()
    {

    }
	public Address(string description, string street, int house, string city, string country, string postcode, int appartment)
	{
		Description = description;
		Street = street;
		House = house;
		City = city;
		Country = country;
		PostalCode = postcode;
		Appartment = appartment;
	}
	/// Установить адрес поэлементно
	public void SetAdr ()
		{
		Console.Write("Улица: ");
		_Street = _Street.GetName();

		Console.Write("Дом: ");
		_house = _house.GetNumber(1,500);

		Console.Write("Квартира: ");
		_Appartment = _Appartment.GetNumber(1,500);

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
	///Проверка ввода числа. Проверяет, что число и оно в диапазоне от a до b
	public static int GetNumber(this int number, int a, int b)
	{
		string? inputstr = String.Empty;
		bool check;
		(int x, int y) = Console.GetCursorPosition();
		do
		{
			Console.SetCursorPosition(x, y);
			inputstr = Console.ReadLine();
			check = !int.TryParse(inputstr, out number) | (inputstr == "");
			if (!check && ((number < a)|(number>b)))
			{
				Console.Write("Видимо вы ошиблись, попробуйте еще раз ввести целое число от {0} до {1}: ", a, b);
				(x, y) = Console.GetCursorPosition();
			}

		}
		while (check | ((number < a) | (number > b)));

		return number;
	}

	///Проверка ввода номера телефона. Проверяет, что число, положительное и 11 цифр
	public static long GetPhone(this long number)
	{
		string? inputstr = String.Empty;
		bool check;
		(int x, int y) = Console.GetCursorPosition();
		do
		{
			Console.SetCursorPosition(x, y);
			inputstr = Console.ReadLine();
			check = !long.TryParse(inputstr, out number) | (inputstr == "");
			if (!check && ((number < 10000000000) | (number > 99999999999)))
			{
				Console.Write("Видимо вы ошиблись. Должно быть 11 цифр. Попробуйте еще раз: ");
				(x, y) = Console.GetCursorPosition();
			}

		}
		while (check | (number < 10000000000) | (number > 99999999999));

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

/// <summary>
/// Ассортимент товаров
/// </summary>
class Range
{
	public Product[] products;

	public Range (Product[] list) => products = list;

	/// <summary>
	/// Индексация
	/// </summary>
	/// <param name="index"></param>
	/// <returns></returns>
	public Product this[int index]
	{
		get => products[index];
		set => products[index] = value;
	}
	public void ShowAll()
    {
		foreach (Product product in products)
			Console.WriteLine(product.Show());
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

		//Console.WriteLine(Mypickpoints[1].Show());

		///Создаем товары 
				
		Product P1 = new Product(1,"Футболка с длинным рукавом", 1518.2, Product.Type.Футболка,"Вьетнам",Product.Sex.Men,"XXL");
		Product P2 = new Product(2, "Кроссовки беговые", 5450, Product.Type.Кроссовки, "Китай", Product.Sex.Women, "38");
		Product P3 = new Product(3, "Шорты теннисные", 2030, Product.Type.Шорты, "Тайланд", Product.Sex.Men, "L");
		Product P4 = new Product(4, "Футболка с коротким рукавом", 1318.8, Product.Type.Футболка, "Вьетнам", Product.Sex.Men, "XL");
		Product P5 = new Product(5, "Футболка с коротким рукавом", 1420.8, Product.Type.Футболка, "Вьетнам", Product.Sex.Women, "M");
		
		Range range = new Range(new[] { P1, P2, P3, P4, P5 });

		///Создаем склад
		List <Product> Stock = new List<Product>();
		
		Random rnd = new Random();
		
		///Добавляем случайное кол-во товара на склад 
		for (int i = 0; i < range.products.Length; i++)
			AddToStock(range[i], rnd.Next(1,15));

		

		///Добавляет нужное кол-во товара на склад
		void AddToStock(Product product, int q)
        {
			for (int i = 0; i < q; i++)
				Stock.Add(product);
        }

		


		///показать все элементы списка
		void ShowList(List<Product> list)
        {
			foreach (Product product in list)
				Console.WriteLine(product.Show());
        }

		///подсчет суммы товаров в списке
		double TotalSum (List<Product> list)
		{
			double sum = 0;
			foreach (Product product in list)
				sum += product.Price;
			return sum;
		}

		///подсчет кол-ва товаров в списке
		int Count(List<Product> list)
		{
			int count = 0;
			foreach (Product product in list)
				count ++;
			return count;
		}

		///создаем Покупателя
		User buyer = new User();
		Console.Write("Ввести данные вручную (1) или выбрать пользователя по умолчанию (2): ");

		int choice = 0;
		choice = choice.GetNumber(1,2);
		if (choice == 2)
			buyer = User.Deafault(); //исключительно для удобства (чтобы не вводить по 100 раз во время тестирования)
		else buyer = User.GetUser();

		Console.WriteLine($"Ваши данные: \nИмя: \t{buyer.Name},\nТел.: \t{buyer.Phone} \n{buyer.Address.Show()}");

		

		///Создаем заказ
		List<Product> Ordered = new List<Product>();
		int key = 0;
		do {
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("____________________\nДобавить товар в корзину - 1\nПосмотреть товары в корзине -2\nПосмотреть все товары в ассортименте -3\nПосмотреть товары на складе-4\nПерейти к оформлению заказа -0\n____________________");
			Console.ResetColor();
			key = key.GetNumber(0, 4);
			
			switch (key)
            {
				case 0: continue;
					case 1:
					{
						Console.WriteLine("Для добавления товара в корзину введите # товара:");
						int inpid = 0;
						inpid = inpid.GetNumber(1, 5); //можно заморочиться и определить диапазон ID товаров 
						Product fp = (Stock.Find(x => x.ID == inpid));
						if (fp == null)
						{
							Console.ForegroundColor = ConsoleColor.Red; 
							Console.WriteLine("Товар закончился на складе");
							Console.ResetColor();
						}
						else
						{
							Console.WriteLine("В корзину добавлен товар:");
							Console.WriteLine(fp.Show());
							Stock.Remove(fp);
							Ordered.Add(fp);
						}
						break;
					}
					case 2:
                    {
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.WriteLine("Товары в корзине:");
						ShowList(Ordered);
						Console.BackgroundColor = ConsoleColor.DarkBlue;
						Console.Write("Всего выбрано товаров: {0},  на сумму: {1} руб.", Count(Ordered), TotalSum(Ordered));
						Console.ResetColor();
						Console.WriteLine();
						break;
					}
				case 3:
					{
						Console.WriteLine("Товары в ассортименте:");
						range.ShowAll();
						break;
					}
				case 4:
					{
						Console.WriteLine("Товары на складе:");
						ShowList(Stock);
						break;
					}
			}				
			
		}
		while (key != 0);

		Console.Write("Какой тип доставки предпочитаете:\n1)\tсамовывоз из магазина \n2)\tзабрать из почтомата\n3)\tдоставка до дома\n");
		choice = choice.GetNumber(1,3);
		
		//Почему через if? Потому, что тоже самое через switch не работает! - см ниже
		if (choice == 1)
		{ Order<ShopDelivery> order = new Order<ShopDelivery>(Ordered); }
		else if (choice == 2) 
		{ Order<PickPointDelivery> order = new Order<PickPointDelivery>(Ordered);
			Console.WriteLine("Доступны следующие точки:");
			foreach (Address adr in Mypickpoints.addresses)
				Console.WriteLine(adr.Show());
			Console.WriteLine("Выберете по номеру (от 1 до {0})", Mypickpoints.addresses.Length);
			key = key.GetNumber(1, Mypickpoints.addresses.Length);
			order.Delivery.Address = Mypickpoints[key - 1];

		}
		else 
		{ Order<HomeDelivery> order = new Order<HomeDelivery>(Ordered); }

		//switch (choice)
		//      {
		//	case 1: Order<ShopDelivery> order = new Order<ShopDelivery>();
		//		break;
		//	case 2: Order<PickPointDelivery> order = new Order<PickPointDelivery>();
		//выбор пикпоинта и засылание его адреса в заказ
		//		break;
		//	default: Order<HomeDelivery> order = new Order<HomeDelivery>();
		//		break;
		//      }
		
		      	
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		Console.WriteLine("Ваш заказ: ");
		ShowList(order.Cart);
		Console.BackgroundColor = ConsoleColor.DarkBlue;
		Console.Write("Всего выбрано товаров: {0},  на сумму: {1} руб.", Count(Ordered), TotalSum(Ordered));
		Console.ResetColor();
		Console.WriteLine();

		







		Console.ReadKey();
	}
}