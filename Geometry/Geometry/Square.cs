/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 22/05/2014
 * Hora: 15:30
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Geometry
{
	/// <summary>
	/// Description of Square.
	/// </summary>
	public class Square : Shape
	{
		// Sqaure side
		protected double side;
		
		public Square(double side, double x, double y) : base(x, y)
		{
			/// <summary>
			/// The main constructor of the Square class, which represents a square.
			/// </summary>
			/// <returns>Returns the square created.</returns>
			/// 
			this.side = side;
		}
		public Square() : this(1.0, 0.0, 0.0)
		{
			/// <summary>
			/// Square class default constructor.
			/// </summary>
			/// <returns></returns>
			/// 
		}
		public Square(double side, Dot d)
		{
			/// <summary>
			/// Another constructor for a Square.
			/// </summary>
			/// <returns></returns>
			/// 
			this.side = side;
			this.X = d.X;
			this.Y = d.Y;
		}
		
		public sealed override double Area()
		{
			/// <summary>
			/// It returns the area of a square
			/// </summary>
			/// 
			return this.side * this.side;
		}
		
		public sealed override double Perimeter()
		{
			/// <summary>
			/// It returns the perimeter of a square.
			/// </summary>
			/// 
			return 4 * this.side;
		}
		
		public sealed override string ToString()
		{
			return String.Format("{0}, Side={1}\nArea={2}\nPerimeter={3}", 
			                     this.GetCoordinates(),
			                     this.side, 
			                     this.Area(), 
			                     this.Perimeter()
			                    );
		}
		
		public sealed override string GetCoordinates()
		{
			/// <summary>
			/// It gets coordinates from a square. 
			/// </summary>
			/// 
			return String.Format("Square at ({0},{1})", this.X, this.Y);
		}

	}
}
