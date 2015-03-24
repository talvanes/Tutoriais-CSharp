/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 13/05/2014
 * Hora: 20:35
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace TesteDeMetodos
{
	/// <summary>
	/// A delegate to switch methods easily
	/// </summary>
	/// 
	//public delegate void MethodIntoDecimalValue (decimal valor);
	public delegate void MethodIntoDecimalClass (Decimal valor);
	
	/// <summary>
	/// A delegate to represent a "pointer" to any method in Decimal class 
	/// </summary>
	public delegate void DecimalOperation (Decimal number);
	
	/// <summary>
	/// Another delegate to represent an anonymous method to execute a method passed as a paramenter
	/// </summary>
	/// 
	public delegate void DoDecimalOperation (Decimal valor, DecimalOperation operation);

	/// <summary>
	/// Description of Decimal.
	/// </summary>
	public class Decimal : ICloneable
	{
		// valor do número decimal
		protected decimal valor;
		
		/// <summary>
		/// Construtor da classe Decimal com objeto Decimal
		/// </summary>
		/// <param name="valor"></param>
		/// 
		public Decimal (Decimal d)
		{
			this.valor = d.valor;
		}
		
		/// <summary>
		/// Construtor da classe Decimal
		/// </summary>
		/// 
		public Decimal(decimal valor)
		{
			this.valor = valor;
		}
		
		/// <summary>
		/// Construtor da classe Decimal (construtor padrão)
		/// </summary>
		/// 
		public Decimal() : this(0.0m)
		{
		}
		
		public object Clone ()
		{
			//return new Decimal(this.valor);
			return this;
		}
		public object Copy ()
		{
			return new Decimal(this.valor);
		}
		
		public override string ToString()
		{
			/*
			 * Representação em String do Objeto Decimal
			 * */
			return string.Format("{0}", this.valor);
		}
		
		/// <summary>
		/// Ajusta o valor do número decimal
		/// </summary>
		/// <param name="d"></param>
		public void Valor (decimal valor)
		{
			this.valor = valor;
		}
		
		/// <summary>
		/// Ajusta o valor do número decimal
		/// </summary>
		/// <param name="d"></param>
		public void Valor (Decimal d)
		{
			this.valor = d.valor;
		}
		
		/*
		 * ----------------------------------------------------------------
		 * Métodos para adicionar, subtrair, multiplicar e dividir decimais
		 * ----------------------------------------------------------------
		 * */
		
		/// <summary>
		/// Adição de decimais (valor decimal)
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		/// 
		public void Adicao (decimal valor)
		{
			this.valor += valor;
		}
		
		/// <summary>
		/// Adição de decimais
		/// </summary>
		/// <param name="valor"></param>
		/// 
		public void Adicao (Decimal d)
		{
			this.valor += d.valor;
		}
		
		/// <summary>
		/// Subtração de decimais (valor decimal)
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		/// 
		public void Subtracao (decimal valor)
		{
			this.valor -= valor;
		}
		/// <summary>
		/// Subtração de decimais
		/// </summary>
		/// <param name="valor"></param>
		/// 
		public void Subtracao (Decimal d)
		{
			
			this.valor -= d.valor;
		}
		
		/// <summary>
		/// Multiplicação de decimais (valor decimal)
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		/// 
		public void Multiplicacao (decimal valor)
		{
			
			this.valor *= valor;
		}
		/// <summary>
		/// Multiplicação de decimais
		/// </summary>
		/// <param name="valor"></param>
		/// 
		public void Multiplicacao (Decimal d)
		{
			this.valor *= d.valor;
		}
		
		/// <summary>
		/// Divisão de números decimais (valor decimal)
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		/// 
		public void Divisao (decimal valor)
		{
			this.valor /= valor;
		}
		/// <summary>
		/// Divisão de números decimais
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		/// 
		public void Divisao (Decimal d)
		{
			this.valor /= d.valor;
		}
		
		/* Fim de métodos */

		
		// troca de valores
		public static void Troca (ref Decimal x, ref Decimal y)
		{
			/// <summary>
			/// Rotina para troca de valores
			/// </summary>
			/// <param name="lista"></param>
			/// <returns></returns>
			/// 
			Decimal temp = x;
			x = y;
			y = temp;
			if (y == null)
				return;
		}
		
		// soma de decimais
		public static decimal Soma (params decimal[] lista)
		{
			/// <summary>
			/// Soma de diversos números decimais
			/// </summary>
			/// 
			decimal soma = 0.0m;
			
			foreach (decimal x in lista) 
			{
				soma += x;
			}
			
			return soma;
		}
		public static Decimal Soma (params Decimal[] lista)
		{
			/// <summary>
			/// Soma de diversos números decimais
			/// </summary>
			/// <param name="lista"></param>
			/// <returns></returns>
			/// 
			Decimal soma = new Decimal();
			
			foreach (Decimal d in lista)
			{
				soma.Adicao(d);
			}
			
			return soma;
		}
		
		// média aritmética de decimais
		public static decimal Media (params decimal[] lista)
		{
			/// <summary>
			/// Média aritmética de diversos decimais
			/// </summary>
			/// 
			decimal soma;
			int cont;
			
			for (soma = 0.0m, cont = 0;
			    cont < lista.Length; 
			    cont++)
			{
				soma += lista[cont];
			}
			
			return (decimal) soma/cont;
		}
		public static Decimal Media (params Decimal[] lista)
		{
			/// <summary>
			/// Média aritmética de diversos decimais
			/// </summary>
			/// <param name="lista"></param>
			/// <returns></returns>
			/// 
			Decimal soma = new Decimal();
			int cont;
			
			for (cont = 0; 
			     cont < lista.Length; 
			     cont++)
			{
				soma.Adicao(lista[cont]);
			}
			
			soma.Divisao(cont);
			
			// retorna a média entre os valores, apesar do nome
			return soma;
		}
		
		// média harmônica de decimais
		public static decimal Harmonica (params decimal[] lista)
		{
			/// <summary>
			/// Média harmônica de diversos decimais
			/// </summary>
			/// 
			decimal somaInversos;
			int cont;
			
			for (somaInversos = 0.0m, cont = 0; 
			     cont < lista.Length; 
			     cont++)
			{
				somaInversos += 1.0m/lista[cont];
			}
			
			return (decimal) cont/somaInversos;
		}
		public static Decimal Harmonica (params Decimal[] lista)
		{
			/// <summary>
			/// Média harmônica de diversos decimais
			/// </summary>
			/// <param name="lista"></param>
			/// <returns></returns>
			/// 
			Decimal somaInversos = new Decimal(), aux;
			int cont;
			
			for (cont = 0,
			     // auxiliar para o cálculo ( 1, o numerador para o inverso)
			     aux = new Decimal(1.0m);
			     cont < lista.Length;
			     cont++)
			{
				aux.Divisao(lista[cont]);
				somaInversos.Adicao(aux);
			}
			
			aux.Valor(cont);
			aux.Divisao(somaInversos);
			
			// retorna a média harmônica entre os valores
			return aux;
		}
		
	}
}
