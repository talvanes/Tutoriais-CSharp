/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 07/06/2014
 * Hora: 21:44
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
 using System;
 
namespace CustomExceptions
{
	/// <summary>
	/// A class representing an Exception in a very simple way.
	/// </summary>
	public class BigValueException : Exception
	{
		// a limit number for our custom exception
		public const int LIMIT = 1000000000;
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="msg"></param>
		public BigValueException(string msg) : base(msg)
		{
		}
	}
	
}
