/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/05/2014
 * Hora: 20:23
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Seres
{
	/// <summary>
	/// Description of Gato.
	/// </summary>
	public class Gato : Animal
	{
		public Gato(string _nome, short _idade, char _sexo) : base(_nome, _idade, _sexo)
		{
			/// <summary>
			/// Gato (nome, idade, sexo)
			/// </summary>
		}
		
		public Gato() : this("", 0, 'D')
		{
			
		}
	}
}
