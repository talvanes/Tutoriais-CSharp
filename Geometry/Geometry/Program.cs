/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/05/2014
 * Hora: 16:56
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Geometry
{
	class Program
	{
		public static void Main(string[] args)
		{
			Dot p1 = new Dot(2,2.5);
			Dot p2 = new Dot();
			Dot p3 = new Dot(p1);
			
			Console.WriteLine("{0:N}", p1);
			Console.WriteLine("{0:N}", p2);
			Console.WriteLine("{0:N}", p3);
			
			Console.WriteLine();
			
			Circle c1 = new Circle(3, 2, 2.5);
			Circle c2 = new Circle();
			Circle c3 = new Circle(6.5, new Dot(10, 12));
			Console.WriteLine("{0}", c1);
			Console.WriteLine("{0}", c2);
			Console.WriteLine("{0}", c3);
			
			Console.WriteLine();
			
			Square s1 = new Square(2.25, 1.0, 0.0);
			Square s2 = new Square();
			Square s3 = new Square(6.0, p1);
			Console.WriteLine("{0}", s1);
			Console.WriteLine("{0}", s2);
			Console.WriteLine("{0}", s3);
			
			Console.WriteLine();
			
			Rectangle r1 = new Rectangle(5.0, 9.5, new Dot(8.1, 5.02));
			Rectangle r2 = new Rectangle(1.5, 3.9, 2, 2.5);
			Rectangle r3 = new Rectangle();
			Console.WriteLine("{0}\n{1}\n{2}", r1, r2, r3);
			
			Console.WriteLine();
			
			Triangle tr1 = new Triangle(8.0, 6.5, 10.0, 15.0, 2.0, 2.5);
			Triangle tr2 = new Triangle();
			Triangle tr3 = new Triangle(12.5, 15.2, p1, p3);
			Console.WriteLine("{0}\n{1}\n{2}", tr1, tr2, tr3);
			
			Console.WriteLine();
			
			Trapezium trap1 = new Trapezium();
			Trapezium trap2 = new Trapezium(10.1, 18.25, 20.4, 10.0, 10.0, 4.0, 4.0);
			Trapezium trap3 = new Trapezium(9.32, 5.2, 6.0, new Dot(15, 12), p1);
			Console.WriteLine("{0}\n{1}\n{2}", trap1, trap2, trap3);
			
			Console.WriteLine();
			
			Console.WriteLine("There are {0} shapes here.", Shape.GetCount());
						
			Console.WriteLine();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}