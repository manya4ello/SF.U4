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
	public string Address;
	public abstract void DeliveryMethod();
	
}

class HomeDelivery : Delivery
{
	public override void DeliveryMethod()
	{
	Console.WriteLine("Доставка на дом");
	}
}

class PickPointDelivery : Delivery
{
	public override void DeliveryMethod()
	{
		Console.WriteLine("Доставка до точки сбора");
	}
}

class ShopDelivery : Delivery
{
	private static string ShopAddr = "Большая Семёновская ул., 26, Москва, Россия, 107023";
	public string Address 
	{ get { return ShopAddr; }
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
class MainClass
{
	public static void Main()
	{
		

		Console.ReadKey();
	}
}