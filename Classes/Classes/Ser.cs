/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/05/2014
 * Hora: 20:21
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Text;

namespace Seres
{
	/// <summary>
	/// Description of Ser.
	/// </summary>
	public abstract class Ser
	{
		protected string nome;
		protected short idade;
		protected char sexo;
		
		// contador de seres - método de classe
		private static int cont;
		
		public Ser(string _nome, short _idade, char _sexo)
		{
			/// <summary>
			/// Ser (nome, idade, sexo)
			/// </summary>
			cont++;
			this.nome = _nome;
			this.idade = _idade;
			if ( _sexo == 'M' || _sexo == 'F' ) 
			{
				this.sexo = _sexo;
			} else this.sexo = 'D';
		}
		
		public Ser() : this("", 0, 'D')
		{
			cont++;
		}
		
		public static string Quantos()
		{
			/// <summary>
			/// Quantos seres há por aqui?
			/// : conta o número de seres criados
			/// </summary>
			return cont.ToString();
		}
		
		public override string ToString()
		{
			/// <summary>
			/// Representação de um ser em código.
			/// </summary>
			return string.Format("[Ser Nome={0}, Idade(anos)={1}, Sexo={2}]", 
			                     (nome.Equals(""))? "nenhum" : nome,
			                     idade, 
			                     (sexo == 'D')? "desconhecido" : 
			                     (
			                     	(sexo == 'M')? "masculino" : "feminino"
			                     )
			                    );
		}
		
	}
}
