/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 18/06/2014
 * Hora: 21:38
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

/// <summary>
/// CartesianSystem2D namespace
/// </summary>
/// <description>
/// It represents a 2D Cartesian System in Cartesian (Analytical) Geometry
/// </description>
namespace CartesianSystem2D {
	/// <summary>
	/// A structure that represents a Line Segment (just a limited part of a line) in our 2D Cartesian System 
	/// </summary>
	/// 
	public struct LineSegment {
		// a starting point
		private Point initial;
		public Point Initial { 
			get { return initial; }
		}
		// and an ending point
		private Point final;
		public Point Final {
			get { return final; }
		}
		
		/// <summary>
		/// As in Line Struct, it represents the direction (angular coefficient) of a Line Segment
		/// </summary>
		/// <returns>Returns the Angular coefficient (A property) of a Line Segment.</returns>
		/// 
		public double M {
			get { return (final.Y - initial.Y)/(final.X - initial.X); }
		}
		
		/// <summary>
		/// Represents the length of a Line Segment.
		/// </summary>
		/// <returns>Returns the length of a Line Segment, since it is just a part of a straight line.</returns>
		public double Length {
			get { return initial.DistanceTo(final); }
		}
		
		/// <summary>
		/// LineSegment constructor.
		/// We use two points to construct a Line Segment by instantiating them in a constructor, just like in
		/// <code>LineSegment ls = new LineSegment(initial, final)</code>. We cannot assign properties diretly because they are read-only.
		/// </summary>
		/// <param name="i">InitialPpoint</param>
		/// <param name="f">Final Point</param>
		public LineSegment(Point i, Point f)
		{
			this.initial = i;
			this.final = f;
		}
		
		/// <summary>
		/// struct LineSegment ToString() representation.
		/// </summary>
		/// <returns>Returns struct LineSegment's string version.</returns>
		/// 
		public override string ToString()
		{
			return string.Format("{0}-{1},m={2:N},length={3:N}",
			                     this.initial, 
			                     this.final,
			                     this.M,
			                     this.Length
			                    );
		}

	}
}
