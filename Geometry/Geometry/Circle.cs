/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/05/2014
 * Hora: 17:29
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Geometry
{
	/// <summary>
	/// Description of Circle.
	/// </summary>
	public class Circle : Shape
	{
		// Circle radius
		protected double radius;
		
		public Circle(double r, double x, double y) : base(x, y)
		{
			/// <summary>
			/// The main constructor of the Circle class, which represents a circle.
			/// </summary>
			/// <returns>Returns the circle created.</returns>
			///
			this.radius = r;
		}
		public Circle() : this(1.0, 0.0, 0.0)
		{
			/// <summary>
			/// Circle class default constructor.
			/// </summary>
			/// <returns>Returns the circle created.</returns>
			///
		}
		public Circle (double r, Dot d)
		{
			/// <summary>
			/// Another constructor for a Circle.
			/// </summary>
			/// <returns></returns>
			/// 
			this.radius = r;
			this.X = d.X;
			this.Y = d.Y;
		}
		
		public override double Area()
		{
			/// <summary>
			/// It returns the area of a circle
			/// </summary>
			/// 
			return Math.PI * this.radius * this.radius;
		}
		
		public override double Perimeter()
		{
			/// <summary>
			/// It returns the circumference of a circle.
			/// </summary>
			/// 
			return 2 * Math.PI * this.radius;
		}
		
		public override string ToString()
		{
			/// <summary>
			/// It returns the string representation of a circle.  
			/// </summary>
			/// 
			return string.Format("{0}, Radius={1:N}\nArea={2:N}\nCircumference={3:N}.", 
			                     this.GetCoordinates(),
			                     this.radius, 
			                     this.Area(), 
			                     this.Perimeter()
			                    );
		}
		
		public override string GetCoordinates()
		{
			/// <summary>
			/// It gets coordinates from a circle. 
			/// </summary>
			/// 
			return String.Format("Circle at ({0},{1})", this.X, this.Y);
		}

	}
}
