/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 19/06/2014
 * Hora: 15:17
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
	/// An interface for methods in classes that describe objects that can have distance to each other
	/// (e.g. two Points, a Point and a Line, two Lines, etc.)  
	/// </summary>
	/// 
	public interface IDistanceable {
		/// <summary>
		/// This method skeleton lets calculate a distance to a Point object. 
		/// </summary>
		/// <param name="toPoint">Some Point object given.</param>
		/// <returns>Returns how long is the distance from an object to the point.</returns>
		double DistanceTo(Point toPoint);
		/// <summary>
		/// This method skeleton lets calculate a distance to a Line object.
		/// </summary>
		/// <param name="toLine">Some Line object given</param>
		/// <returns>Returns how long is the distance from an object to the line.</returns>
		//double DistanceTo(Line toLine);
		/// <summary>
		/// This method skeleton lets calculate a distance to a LineSegment object.
		/// </summary>
		/// <param name="toShape">Some LineSegment object given.</param>
		/// <returns>Returns how long is the distance from an object to the line segment.</returns>
		//double DistanceTo(Shape toShape);
	}
}
