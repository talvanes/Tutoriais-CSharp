/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/05/2014
 * Hora: 20:21
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Seres
{
	/// <summary>
	/// Description of Pessoa.
	/// </summary>
	public abstract class Pessoa : Ser
	{
		protected string sobrenome;
		
		// contagem de pessoas
		private static int cont;
		
		public Pessoa(string _sobrenome, string _nome, short _idade, char _sexo) : base(_nome, _idade, _sexo)
		{
			/// <summary>
			/// Pessoa (sobrenome, nome, idade, sexo)
			/// </summary>
			cont++;
			this.sobrenome = _sobrenome;
		}
		
		public Pessoa() : this("", "", 0, 'D')
		{
			
		}
		
		public static new string Quantos()
		{
			/// <summary>
			/// Quantas pessoas há por aqui?
			/// : conta o número de pessoas criadas
			/// </summary>
			return cont.ToString();
		}
		public override string ToString()
		{
			return string.Format("[Pessoa Nome={0} {1} Idade(anos)={2} Sexo={3}]", 
			                     (nome.Equals(""))? "nenhum" : "'" + nome, 
			                     (!sobrenome.Equals(""))? sobrenome + "'" : "",
			                     idade,
			                     (sexo == 'D')? "desconhecido" : 
			                     (
			                     	(sexo == 'M')? "masculino" : "feminino"
			                     )
			                    );
		}


	}
}
