/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 17/06/2014
 * Hora: 19:51
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

/// <summary>
/// CartesianSystem2D namespace
/// </summary>
/// <description>
/// It represents a 2D Cartesian System in Cartesian (Analytical) Geometry.
/// </description>
namespace CartesianSystem2D {
	/// <summary>
	/// A structure that represents a Point in our 2D Cartesian System
	/// </summary>
	public struct Point : IDistanceable {		
		// x coordinate
		private double x;
		/// <summary>
		/// X coordinate of a point
		/// </summary>
		/// <returns>Returns the value of Point X member.</returns>
		public double X {
			get { return x; }
		}
		// y coordinate
		private double y;
		/// <summary>
		/// Y coordinate of a point
		/// </summary>
		/// <returns>Returns the value of Point Y member.</returns>
		public double Y {
			get { return y; }
		}
		
		/// <summary>
		/// Point struct constructor.
		/// Since X and Y properties are read-only, you cannot do an assignment directly.
		/// First, you have to create it by using <code>Point P = new Point(0,0);</code>, for example.
		/// </summary>
		/// 
		public Point(double x, double y) {
			this.x = x;
			this.y = y;
		}
		
		/// <summary>
		/// struct Point ToString() representation.
		/// </summary>
		/// <returns>Returns struct Point's string version.</returns>
		public override string ToString()
		{
			return string.Format("({0},{1})", this.x, this.y);
		}
		
		/// <summary>
		/// This method calculates the distance between two points.
		/// </summary>
		/// <returns>Returns the distance between two points.</returns>
		/// 
		public double DistanceTo(Point toPoint)
		{
			// X coordinate length
			double x = toPoint.x - this.x;
			// Y coordinate length
			double y = toPoint.y - this.y;
			
			// now calculate their distance
			return Math.Sqrt(x * x + y * y);
		}
		
		/**
		 * Wait for more methods (e.g. DistanceTo(Point),DistanceTo(Line), etc.)
		 * */
		/// <summary>
		/// This method calculates the distance between a point and a line.
		/// </summary>
		/// <returns>Returns the distance between a point and a line.</returns>
		/// 
		/*
			public double DistanceTo(Line toLine)
			{
			}
		*/
	}
}
