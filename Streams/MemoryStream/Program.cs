/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 31/07/2014
 * Hora: 21:02
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.IO;

namespace Streams
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*
			 * Leitura e escrita de bytes aleatórios na memória
			 * */
			
			// Gerador de números aleatórios
			Random rand = new Random();
			// Capacidade da sequência de bytes
			int capacidade = 100;
			
			try 
			{
				// lendo e escrevendo números na memória
				using (Stream seqBytes = new MemoryStream(capacidade)) 
				{
					// 1. Escrevendo bytes com números aleatórios
					byte[] bytes = new byte[capacidade];					// criando sequência de bytes,
					rand.NextBytes(bytes);									// preenchendo com bytes aleatórios
					Array.ForEach<byte>(bytes, B => seqBytes.WriteByte(B));	// e escrevendo na memória.
									
					
					// 2. Lendo os bytes já escritos
					seqBytes.Position = 0;	// retornar o cursos ao início para ler a sequência
					
					int byteLido = seqBytes.ReadByte();
					do {
						Console.Write("{0,4:000}", byteLido);
						byteLido = seqBytes.ReadByte();
					} while (byteLido != -1);
					Console.WriteLine();
					
				}
			} catch (IOException e) 
			{
				// problemas de entrada e saída (IO)
				Console.WriteLine("Frustrated IO\n{0}", e.Message);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}