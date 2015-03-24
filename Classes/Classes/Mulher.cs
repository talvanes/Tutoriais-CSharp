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
	/// Description of Mulher.
	/// </summary>
	public class Mulher : Pessoa
	{
		public Mulher(string _sobrenome, string _nome, short _idade) : base(_sobrenome, _nome, _idade, 'F')
		{
			/// <summary>
			/// Mulher (sobrenome, nome, idade)
			/// sexo : feminino
			/// </summary>
		}
		
		public Mulher() : this("", "", 0)
		{
			
		}
	}
}
