/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/05/2014
 * Hora: 17:08
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.ComponentModel;

namespace Geometry
{
	/// <summary>
	/// Description of Dot.
	/// </summary>
	public class Dot : Shape
	{
		
		public Dot(double x, double y) : base(x, y)
		{
			/// <summary>
			/// The main constructor of the Dot class, which represents a single dot.
			/// </summary>
			/// <returns>Returns the dot created.</returns>
			/// 
		}
		public Dot() : this(0.0, 0.0)
		{
			/// <summary>
			/// Dot class default constructor.
			/// </summary>
			/// <returns>Returns the dot created.</returns>
			///
		}
		public Dot(Dot d)
		{
			/// <summary>
			/// Another constructor for a Dot.
			/// </summary>
			/// <returns></returns>
			/// 
			this.X = d.X;
			this.Y = d.Y;
		}
		
		public sealed override double Area()
		{
			return 0.0;
		}
		
		public sealed override double Perimeter()
		{
			return 0.0;
		}
		
		public sealed override string ToString()
		{
			/// <summary>
			/// It returns the string representation of a circle.  
			/// </summary>
			/// 
			return String.Format("Dot at ({0:N},{1:N}).", this.X, this.Y);
		}
		
		public sealed override string GetCoordinates()
		{
			/// <summary>
			/// It gets coordinates from a dot. 
			/// </summary>
			/// 
			return this.ToString();
		}
		
		public double Distance(Dot d)
		{
			/// <summary>
			/// Calculates the distance between two dots.
			/// </summary>
			/// <returns></returns>
			/// 
			double _x = this.X - d.X;
			double _y = this.Y - d.Y;
			return Math.Sqrt(_x * _x + _y * _y);
		}
		public double Distance(double x, double y)
		{
			/// <summary>
			/// Calculates the distance between a dot at two given coordinates.
			/// </summary>
			/// <returns></returns>
			/// 
			double _x = this.X - x;
			double _y = this.Y - y;
			return Math.Sqrt(_x * _x + _y * _y);
		}
		
	}
}
