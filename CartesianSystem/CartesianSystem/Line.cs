/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 17/06/2014
 * Hora: 20:36
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;

/// <summary>
/// CartesianSystem2D namespace
/// </summary>
/// <description>
/// It represents a 2D Cartesian System in Cartesian (Analytical) Geometry
/// </description>
namespace CartesianSystem2D {
	/// <summary>
	/// A structure that represents a Line (a straight line) in our 2D Cartesian System
	/// </summary>
	/// 
	public struct Line : IIntersectable	{
		// a strarting point, from which we get a and b in f(x)=ax+b
		private Point P0;
		// and a direction (angular coefficient, or line tangent) for our line
		private double m;
		
		/// <summary>
		/// Represents the direction (or Angular coefficient) of a Line
		/// </summary>
		/// <returns>Returns the Angular coefficient (A property) of a Line</returns>
		/// 
		public double A {
			get { return m; }
		}
		/// <summary>
		/// Represents the coefficeint where a Line intersects Y axis in a 2D Cartesian System
		/// </summary>
		/// <returns>Returns the Linear coefficient (B property) of a Line</returns>
		/// 
		public double B {
			get { return P0.Y - m * P0.X; }
		}
		
		/// <summary>
		/// Line struct constructors, because we can construct a Line in two ways:
		/// one is by using two points (P and Q), just like in a line segment, e.g. <code>Line(Point,Point)</code>,
		/// and another is by using a point and a direction (P0 and m), e.g. <c>Line(Point,double)</c>.
		/// As in Point structure, you also cannot do direct assignment to this structure type. 
		/// You have to call its constructors instead, like in <c>Line r1 = new Line(new Point(0,0),1.5)</c> or <c>Line r2 = new Line(new Point(0,0),new Point(2,3))</c>
		/// </summary>
		/// 
		public Line(Point initial, Point final) {
			// setting a initial point
			this.P0 = initial;
			// and a direction
			this.m = (final.Y - initial.Y)/(final.X - initial.X);
		}
		/// <summary>
		/// Line struct constructors, because we can construct a Line in two ways:
		/// one is by using two points (P and Q), just like in a line segment, e.g. <code>Line(Point,Point)</code>,
		/// and another is by using a point and a direction (P0 and m), e.g. <c>Line(Point,double)</c>.
		/// As in Point structure, you also cannot do direct assignment to this structure type. 
		/// You have to call its constructors instead, like in <c>Line r1 = new Line(new Point(0,0),1.5)</c> or <c>Line r2 = new Line(new Point(0,0),new Point(2,3))</c>
		/// </summary>
		/// 
		public Line(Point initial, double angular) {
			// direct assignment
			this.P0 = initial;
			this.m = angular;
		}
		/// <summary>
		/// Or we can make a Line by using a Line Segment.
		/// Just like the other constructors, we cannot assign properties directly, instead we have to construct our object this way:
		/// <c>Line line = new Line(lineSegment)</c>.
		/// </summary>
		/// 
		public Line(LineSegment ls)
		{
			// we do almost the same way as in Line(Point initial,Point final)	
			this.P0 = ls.Initial;
			this.m = (ls.Final.Y - ls.Initial.Y)/(ls.Final.X - ls.Initial.X);
		}
		
		/// <summary>
		/// struct Line ToString() representation.
		/// </summary>
		/// <returns>Returns struct Line's string version.</returns>
		/// 
		public override string ToString()
		{	// (m equals to A)
			// if m produces NaN, there's no Line
			if (Double.IsNaN(this.A)) return null;
			// if m produces +Infinity or -Infinity, our Line becomes x=k
			if (Double.IsInfinity(this.A))
			{
				return String.Format("x={0:N}", this.P0.X);
			}
			// otherwise, we get a straight Line
			return string.Format("y{0:+0.##;-0.##;+0}x{1:+0.##;-0.##;+0}=0",
			                     this.A,
			                     this.B
			                    );
		}
		
		/// <summary>
		/// Brings possible points against a line
		/// </summary>
		/// <param name="line">Another line to find out intersection</param>
		/// <returns>Returns one point, infinite points or no points depending on lines provided.</returns>
		public List<Point> Intersection(Line line)
		{
			List<Point> points = null;
			
			// TODO: implementation goes here
			
			return points;
		}

		/*
		 * Wait for more methods, and an implementation of a possible IIntersectable method.
		 * */
	}
}
