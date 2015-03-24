/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 17/06/2014
 * Hora: 21:20
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
	/// An interface for methods in classes that are going to implement them into themselves, as they might need.
	/// It describes all shapes that can intersect each other.
	/// </summary>
	/// 
	public interface IIntersectable {
		/// <summary>
		/// Method skeleton for a Line that is going to intersect another Line in order to return a Point. 
		/// </summary>
		/// <param name="line">A line to intersect</param>
		/// <returns>Returns a Point from this intersection.</returns>
		List<Point> Intersection(Line line);
		/// <summary>
		/// Method skeleton for a Line that is going to intersect a Shape in order to return a LineSegment. 
		/// </summary>
		/// <param name="line">A shape to intersect</param>
		/// <returns>Returns a LineSegment from this intersection.</returns>
		//List<LineSegment> Intersection(Shape shape);
	}
}
