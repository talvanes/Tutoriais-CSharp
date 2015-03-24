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
	/// Description of Cachorro.
	/// </summary>
	public class Cachorro : Animal
	{
		public Cachorro(string _nome, short _idade, char _sexo) : base(_nome, _idade, _sexo)
		{
			/// <summary>
			/// Cachorro (nome, idade, sexo)
			/// </summary>
		}
		
		public Cachorro() : this("", 0, 'D')
		{
			
		}
	}
}
