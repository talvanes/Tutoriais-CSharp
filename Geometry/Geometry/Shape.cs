/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/05/2014
 * Hora: 16:58
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Reflection;

namespace Geometry
{
	/// <summary>
	/// Description of Shape.
	/// </summary>
	public abstract class Shape
	{
		// coordinates of the shape
		private double x;
		private double y;
		// should be replaced by properties X and Y later
		// because x and y instance variables should be *protected*.
		public double X {
			set { x = value; }
			get { return x; }
		}
		public double Y {
			get; set;
		}
		
		// the number of shapes created until now
		private static int count;
		
		/// <summary>
		/// The main constructor of the Shape class, which represents a shape.
		/// </summary>
		/// <returns>Returns the shape created.</returns>
		/// 
		public Shape(double x, double y)
		{
			// count one being
			count++;
			this.x = x;
			this.y = y;
		}
		/// <summary>
		/// Shape class default constructor.
		/// </summary>
		/// <returns>Returns the shape created.</returns>
		/// 
		public Shape() : this(0.0, 0.0)
		{
			
		}
		
		// area of a shape
		public abstract double Area();
		// and its perimetre
		public abstract double Perimeter();
		
		// get shape coordinates
		public abstract string GetCoordinates();
				
		// how many shapes created until now?
		public static int GetCount()
		{
			return count;
		}
		
	}
}
