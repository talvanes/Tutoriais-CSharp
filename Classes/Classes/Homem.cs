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
	/// Description of Homem.
	/// </summary>
	public class Homem : Pessoa
	{
		public Homem(string _sobrenome, string _nome, short _idade) : base(_sobrenome, _nome, _idade, 'M')
		{
			/// <summary>
			/// Homem (sobrenome, nome, idade)
			/// sexo : masculino
			/// </summary>
		}
		
		public Homem() : this("", "", 0)
		{
			
		}
	}
}
