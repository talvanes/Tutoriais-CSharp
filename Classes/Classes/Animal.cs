/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/05/2014
 * Hora: 20:22
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Seres
{
	/// <summary>
	/// Description of Animal.
	/// </summary>
	public abstract class Animal : Ser
	{
		// contagem de animais
		private static int cont;
		
		public Animal(string _nome, short _idade, char _sexo) : base(_nome, _idade, _sexo)
		{
			/// <summary>
			/// Animal (nome, idade, sexo)
			/// </summary>
			cont++;
		}
		
		public Animal() : this("", 0, 'D')
		{
			
		}
		
		public static new string Quantos()
		{
			/// <summary>
			/// Quantos animais há por aqui?
			/// : conta o número de animais criados
			/// </summary>
			return cont.ToString();
		}
	}
}
