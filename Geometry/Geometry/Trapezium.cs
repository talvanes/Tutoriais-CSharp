/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 01/06/2014
 * Hora: 18:57
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Geometry
{
	/// <summary>
	/// Description of Trapezium.
	/// </summary>
	public class Trapezium : Shape
	{
		// Trapezium (Trapezoid for Americans) large and small widths and height...
		protected double B;		// large width or "B"
		protected double b;		// small width or "b"
		protected double height;
		// and its top most point, which reprsents its height.
		protected Dot heightTop;		
		
		public Trapezium(double B, double b, double height, double topX, double topY, double x, double y) : base(x, y)
		{
			/// <summary>
			/// The main constructor of the Trapezium class, which represents a trapezium (trapezoid)
			/// </summary>
			/// <returns>Returns the Trapezium (Trapezoid) created.</returns>
			/// 
			this.B = B;
			this.b = b;
			this.height = height;
			// Checking if base and top dots are not the same, 
			// because topY (Y coordinate of the top most point) has to be equal to 
			// Y coordinate of the top most point, that is, (topY == y + height) has to be true
			if (topY != y + height) {
				// correcting this error...
				topY = y + height;
			}
			// ... before creating the point.
			this.heightTop = new Dot(topX, topY);
		}
		public Trapezium() : this(1.0, 1.0, 1.0, 0.0, 1.0, 0.0, 0.0)
		{
			/// <summary>
			/// Trapezium class default constructor.
			/// </summary>
			/// <returns></returns>
			/// 
		}
		public Trapezium(double B, double b, double height, Dot top, Dot d)
		{
			/// <summary>
			/// Another constructor for a Trapezium (trapezoid)
			/// </summary>
			/// 
			this.B = B;
			this.b = b;
			this.height = height;
			// Checking if base and top dots are not the same, 
			// because topY (Y coordinate of the top most point) has to be equal to 
			// Y coordinate of the top most point, that is, (topY == y + height) has to be true
			if (top.Y != d.Y + height) {
				// correcting this error...
				top.Y = d.Y + height;
			}
			// ...before defining the top most point of the triangle.
			this.heightTop = top;
		}
		
		public sealed override double Area()
		{
			/// <summary>
			/// It returns the area of a Trapezium (trapezoid).
			/// </summary>
			/// 
			return this.height * (this.B + this.b)/2.0;
		}
		
		public sealed override double Perimeter()
		{
			/// <summary>
			/// It returns the permeter of a Trapezium (trapezoid).
			/// </summary>
			/// 
			// Calculating distance between the base and the top most points of a trapezium (trapezoid)
			// in order to get its first side
			double side1 = this.heightTop.Distance(this.X, this.Y);
			// Creating two other points in order to calculate the last side of the trapezium (trapezoid)
			Dot thirdPoint = new Dot(this.heightTop.X + this.b, this.heightTop.Y);
			Dot fourthPoint = new Dot(this.X + this.B, this.Y);
			double side4 = thirdPoint.Distance(fourthPoint);
			
			// Now calculate the trapezium (trapezoid) perimeter
			return side1 + this.B + this.b + side4;
		}
		
		public sealed override string GetCoordinates()
		{
			/// <summary>
			/// It gets coordinates of a Trapezium (trapezoid)
			/// </summary>
			/// 
			return String.Format("Trapezium (Trapezoid) at ({0},{1})", this.X, this.Y);
		}
		
		public override string ToString()
		{
			return string.Format("{0} B={1}, b={2}, Height={3}\nArea={4}\nPerimeter={5}", 
			                     this.GetCoordinates(),
			                     this.B, 
			                     this.b, 
			                     this.height,
			                     this.Area(),
			                     this.Perimeter()
			                    );
		}

	}
}
