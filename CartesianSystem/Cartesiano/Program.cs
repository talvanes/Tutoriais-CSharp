/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 17/06/2014
 * Hora: 19:50
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using CartesianSystem2D;

namespace Cartesiano
{
	class Program
	{
		public static void Main(string[] args)
		{
			Point P = new Point(-2,5);
			Point Q = new Point(4,-1);
			Line r1 = new Line(P,Q);
			LineSegment AB = new LineSegment(P, Q);
			Point R = new Point(10,14.5);
			Point S = new Point(5,10.5);
			LineSegment CD = new LineSegment(R, S);
			Line r2 = new Line(CD);
			
			Console.WriteLine("P{0},Q{1}", P, Q);
			Console.WriteLine("r1:{0},r2:{1}", r1, r2);
			Console.WriteLine("AB:{0}\nCD:{1}", AB, CD);
			
			Console.WriteLine();
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}