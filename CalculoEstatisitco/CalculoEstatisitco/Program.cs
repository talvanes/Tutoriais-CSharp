/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 06/05/2014
 * Hora: 20:46
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Matematica
{
	class Program
	{
		public static void Main(string[] args)
		{			
			try {
				List<int> lista = new List<int>();
				int num;
				/* 
				 * preenchendo a lista com números de 1 até n 
				 * */
				do {
					Console.Write("Digite um número inteiro: ");
					num = Int32.Parse(Console.ReadLine());
				} while (num <= 0);
				// Ação: um objeto que executará as funções solicitadas
				// 	primeiro -> preencher a lista até um certo número digitado
				Action<List<int>, int> PreencheLista = (colecao, quantos) => {
					// inserir elementos na lista
					for (int cont = 1; cont <= num; cont++) 
						colecao.Add(cont);
				};
				PreencheLista(lista, num);
				// segundo -> mostra numeros: rotina a ser usada para mostrar números primos de uma maneira mais 'apresentável'
				Action<int> MostraNumero = numero => {
					Console.Write("{0,-10}", numero);
				};
				
				/* 
				 * números primos 
				 * */
				Predicate<int> EhPrimo = numero => {
					// serão aceitos apenas números maiores que 1
					if (numero > 1)
					{
						int quantos, contador;
						for (
							// contagem de divisores
							// ao menos, todos os números têm o número 1 como divisor
							quantos = 0,
							// valores para testar
							contador = 1;
							// testando todos os números menores que 'numero'
						     contador <= numero; 
						     // próximo passo...
						     contador++ )
						{
							// 'numero' é divisível por 'contador'? conte-o
							if ( numero % contador == 0 )
							{
								quantos += 1;
							}
						}
						
						// ao final do laço, verificar se 'quantos' é igual a 2 (nº divisores dos números primos)
						return quantos == 2;
						
					}
					// 0 e 1 não são primos
					return false;
				};
				
				Console.WriteLine("Números primos até {0}:", num);
				
				var primos = from item in lista	// elecionando números primos
					where EhPrimo(item)
					select item;
				primos.ToList().ForEach(MostraNumero);	// mostrando esses números
				
				// pula linha
				Console.WriteLine();
				
				/* 
				 * números perfeitos 
				 * */
				
				Predicate<int> EhPerfeito = numero => {
					// TODO: Predicate para números perfeitos
				};
				
				Console.WriteLine("Números perfeitos até {0}:", num);
				
				// TODO: lista para gerar números perfeitos (LINQ)
				
			} 
			catch (Exception e)
			{
				Console.WriteLine("{0}", e.Message);
			} finally {
				Console.Write("Press any key to continue . . . ");
				Console.ReadKey(true);
			}
		}
	}
}