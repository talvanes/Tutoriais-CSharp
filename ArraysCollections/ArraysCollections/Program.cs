/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 22/07/2014
 * Hora: 20:30
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Globalization;

namespace ArraysCollections
{
	//public delegate void Posicao(char l, string[] V);
	
	class Program
	{
		public static void Main(string[] args)
		{
			/*
			 * Arrays (standard collection)
			 * */
			string[] vetor = new string[] {"Nestlé", "Ades", "Jussara", "Jandaia", "Bauducco", "Camil", "Brejeiro", "Triunfo", "Chamyto", "Danone", "Yakult", "Renata"};
			Array.Sort(vetor);
			Array.Reverse(vetor);
			Array.ForEach<string>(vetor, el => Console.Write("{0,-20}", el));
			// método para mostrar a posição do primeiro elemento que começa com alguma letra
			Action<char, string[]> PrimeiraPosicao = delegate(char l, string[] V)
				{	// l: letra, V: vetor de strings
						Console.WriteLine("\n\nPosição do primeiro elemento que começa com '{0}': {1}ª.",
				                l,
				                Array.FindIndex<string>(V, el => el.StartsWith(l.ToString())) + 1
			                 );
				};
			// método para mostrar a posição do primeiro elemento que começa com alguma letra
			Action<char, string[]> UltimaPosicao = delegate(char l, string[] V)
				{	// l:letra, V: vetor de strings
						Console.WriteLine("\n\nPosição do último elemento que começa com '{0}': {1}ª.",
				                l,
				                Array.FindLastIndex<string>(V, el => el.StartsWith(l.ToString())) + 1
			                 );
				};
			PrimeiraPosicao('J', vetor);
			UltimaPosicao('N', vetor);
			PrimeiraPosicao('A', vetor);
			UltimaPosicao('P', vetor);
			PrimeiraPosicao('B', vetor);
			UltimaPosicao('C', vetor);
			
			Console.WriteLine();
			
			/*
			 * ArrayList
			 * */
			// criando um vetor dinâmico com base nos elementos do vetor anterior
			ArrayList vetorDinamico = new ArrayList(vetor);
			vetorDinamico.AddRange(
				new string[] {"Toddy", "Panco", "Arcor", "Galinha Pintadinha"}
			);
			vetorDinamico.Sort();
			vetorDinamico.Remove("Galinha Pintadinha");
			string[] novoVetor = vetorDinamico.ToArray(typeof(String)) as string[];
			Array.ForEach<string>(novoVetor, el => Console.Write("{0,-20}", el));
			PrimeiraPosicao('A', novoVetor);
			PrimeiraPosicao('P',novoVetor);
			UltimaPosicao('T', novoVetor);
			
			Random rand = new Random();
			
			/*
			  * List
			  */
			 List<int> lista = new List<int>();
			 for (int i = 0, num; i < 50; i++) {
			 	num = rand.Next(50);
			 	lista.Add(num);
			 }
			 lista.Remove(46);
			 lista.Remove(12);
			 lista.Remove(8);
			 lista.ForEach(
			 	num => Console.Write("{0,-5}", num)
			 );
			 
			 Console.WriteLine("\n");
			 
			/*
			 * LinkedList
			 * */
			LinkedList<double> decimais = new LinkedList<double>();
			LinkedListNode<double> nodoDecimal = new LinkedListNode<double>(0);
			double num2;
			for (int i = 0; i < 25; i++) {
				num2 = 20 * rand.NextDouble();
				decimais.AddLast(num2);
			}
			for (int i = 0; i < 25; i++) {
				num2 = 20 * rand.NextDouble();
				decimais.AddFirst(num2);
			}
			foreach (double num in decimais) {
				Console.Write("{0,8:0.##}", num);
			}
			
			Console.WriteLine("\n");
			
			/*
			 * Dictionary
			 * */
			/* Estrutura baseada nos Sufixos Bytes (SUFFIXES) contidos no módulo Wgetter (linguagem Python) por Fernando (phoemur) */
			Dictionary<ushort, string[]> suffixes = new Dictionary<ushort, string[]>();
			suffixes.Add(1000, new string[] {"KB","MB","GB","TB","PB","EB","ZB","YB"});
			suffixes.Add(1024, new string[] {"KiB","MiB","GiB","TiB","PiB","EiB","ZiB","YiB"});
			// 1º Teste: representando as grandezas
			foreach (ushort num_system in suffixes.Keys)
			{
				Console.WriteLine("Unidades na base {0}:", num_system);
				// "multiplicador" para o sistema adotado
				BigInteger multiplicador = new BigInteger(num_system);
				BigInteger numSys = new BigInteger(num_system);
				CultureInfo ptPT = CultureInfo.CreateSpecificCulture("pt-PT");
				// multiplicando e representando ...
				foreach (string unid in suffixes[num_system]) 
				{
					Console.WriteLine("1 {0}: {1} B = {2} b", 
					                  // nome do múltiplo digital
					                  unid,	
					                  // represntação em bytes (B)
					                  String.Format(ptPT, "{0:00,0}", multiplicador),
					                  // represntação em bits (b)
					                  String.Format(CultureInfo.CreateSpecificCulture("pt-PT"), "{0:00,0}", 8 * multiplicador)
					);
					// atualizando "multiplicador" (índice) para iterar a próxima unidade
					multiplicador = BigInteger.Multiply(multiplicador, numSys);
				}
				Console.WriteLine();
			}			
			
			Console.WriteLine("\n");
			
			/*
			 * Queue
			 * */
			
			
			Console.WriteLine("\n");
			
			/*
			 * Stack
			 * */
			
			
			Console.WriteLine("\n\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}