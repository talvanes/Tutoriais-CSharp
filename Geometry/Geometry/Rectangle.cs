/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 22/05/2014
 * Hora: 16:35
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Geometry
{
	/// <summary>
	/// Description of Rectangle.
	/// </summary>
	public class Rectangle : Shape
	{
		// Rectangle width and height
		protected double width;
		protected double height;
		
		public Rectangle(double width, double height, double x, double y) : base(x, y)
		{
			/// <summary>
			/// The main constructor of the Rectangle class, which represents a rectangle.
			/// </summary>
			/// <returns>Returns the rectangle created.</returns>
			/// 
			this.width = width;
			this.height = height;
		}
		public Rectangle() : this(1.0, 1.0, 0.0, 0.0)
		{
			/// <summary>
			/// Rectangle class default constructor.
			/// </summary>
			/// <returns></returns>
			/// 
		}
		public Rectangle(double width, double height, Dot d)
		{
			/// <summary>
			/// Another constructor for a Rectangle.
			/// </summary>
			/// <returns></returns>
			/// 
			this.width = width;
			this.height = height;
			this.X = d.X;
			this.Y = d.Y;
		}
		
		public sealed override double Area()
		{
			/// <summary>
			/// It returns the area of a rectangle
			/// </summary>
			/// 
			return this.width * this.height;
		}
		
		public sealed override double Perimeter()
		{
			/// <summary>
			/// It returns the perimeter of a rectangle
			/// </summary>
			/// 
			return 2 * (this.width + this.height);
		}
		
		public sealed override string GetCoordinates()
		{
			/// <summary>
			/// It gets coordinates from a rectangle 
			/// </summary>
			/// 
			return String.Format("Rectangle at ({0},{1})", this.X, this.Y);
		}
		
		public override string ToString()
		{
			return string.Format("{0} Width={1}, Height={2}\nArea={3}\nPerimeter={4}", 
			                     this.GetCoordinates(),
			                     this.width, this.height,
			                     this.Area(),
			                     this.Perimeter()
			                    );
		}

		
	}
}
