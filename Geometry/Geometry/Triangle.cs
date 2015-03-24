/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 31/05/2014
 * Hora: 18:53
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Geometry
{
	/// <summary>
	/// Description of Triangle.
	/// </summary>
	public class Triangle : Shape
	{
		// Triangle width and height...
		protected double width;
		protected double height;
		// ...and its top most point, which represents its height
		protected Dot heightTop;
		
		public Triangle(double width, double height, double topX, double topY, double x, double y) : base(x, y)
		{
			/// <summary>
			/// The main constructor of the Triangle class, which represents a triangle 
			/// </summary>
			/// <returns>Returns the Triangle created.</returns>
			/// 
			this.width = width;
			this.height = height;
			// Checking if base and top dots are not the same, 
			// because topY (Y coordinate of the top most point) has to be equal to 
			// the base point Y coordinate, that is, (topY == y + height) has to be true
			if (topY != y + height)
			{
				// correcting this error...
				topY = y + height;
			}
			// ...before creating the point.
			this.heightTop = new Dot(topX, topY);
		}
		public Triangle() : this(1.0, 1.0, 0.0, 1.0, 0.0, 0.0)
		{
			/// <summary>
			/// Triangle class default constructor.
			/// </summary>
			/// <returns></returns>
			/// 
		}
		public Triangle(double width, double height, Dot top, Dot d)
		{
			/// <summary>
			/// Another constructor for a Triangle
			/// </summary>
			/// 
			this.width = width;
			this.height = height;
			// Checking if base and top dots are not the same, 
			// because topY (Y coordinate of the top most point) has to be equal to 
			// the base point Y coordinate, that is, (topY == y + height) has to be true
			if (top.Y != d.Y + height) {
				// correting this error...
				top.Y = d.Y + height;
			}
			// ...before defining the top most point of the triangle.
			this.heightTop = top;
		}
		
		public sealed override double Area()
		{
			/// <summary>
			/// It returns the area of a triangle.
			/// </summary>
			/// <returns></returns>
			return (this.width * this.height)/2.0;
		}
		
		public sealed override double Perimeter()
		{
			/// <summary>
			/// It returns the perimeter of a triangle.
			/// </summary>
			///
			
			// Calculating distance between the base and the top most points of a triangle
			// in order to get its first side
			double side1 = this.heightTop.Distance(this.X, this.Y);
			// Creating another point in order to get the triangle last side afterwards
			// (one of the sides is its width)
			Dot thirdPoint = new Dot(this.X + this.width, this.Y);
			double side3 = thirdPoint.Distance(this.heightTop);
			
			// Now calculate the triangle perimeter
			return side1 + this.width + side3;
		}
		
		public sealed override string GetCoordinates()
		{
			/// <summary>
			/// It gets coordinates of a Triangle
			/// </summary>
			/// <returns></returns>
			/// 
			return String.Format("Triangle at ({0},{1})", this.X, this.Y);
		}
		
		public override string ToString()
		{
			return string.Format("{0} Width={1}, Height={2}\nArea={3}\nPerimeter={4}", 
			                     this.GetCoordinates(),
			                     this.width,
			                     this.height,
			                     this.Area(),
			                     this.Perimeter()
			                    );
		}

	}
}
