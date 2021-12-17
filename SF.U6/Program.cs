
class Company
{
	public string str = null;
	public string str2 = null;
	public string name = null;
}


class MainClass
{
	public static void Main(string[] args)
	{
		var test = new Company();
		test.name = "MMM";
		if (test?.str != "Банк" && test?.str2 != "Санкт-Петербург")
		{
			Console.WriteLine("У банка {0} есть отделение в Санкт-Петербурге", test?.name??"Неизвестная компания");
		}

		Triangle triangle = new Triangle();
		triangle.A = 10;
		triangle.B = 10;	
		triangle.C = 10;	
		Console.WriteLine("У треугольника стороны a= {0}, b= {1} и c= {2}",triangle.A,triangle.B,triangle.C );

		Console.ReadKey();	
	}
}

class Triangle
{
	private int a;
	private int b;
	private int c;

	public int A
	{
		get { return a; }
		set
		{
			if (value > 0 && b + c > value)
			{
				a = value;
			}
		}
	}
	public int B
	{
		get { return b; }
		set
		{
			if (value > 0 && a + c > value)
			{
				b = value;
			}
		}
	}
	public int C
	{
		get { return c; }
		set
		{
			if (value > 0 && a + b > value)
			{
				c = value;
			}
		}
	}

	/* public double Square()
	{
	}

	public double Perimeter()
	{
	} */
}