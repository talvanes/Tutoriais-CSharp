/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 01/08/2014
 * Hora: 19:59
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.IO;

namespace MemoryReadWrite2
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Gerador de números aleatórios
			Random rand = new Random();
			
			try
			{
				// criar fluxo de memória
				using (MemoryStream memoria = new MemoryStream()) 
				{
					// gravar na memória, o nosso dispositivo primário
					using (StreamWriter gravador = new StreamWriter(memoria))
					{
						// gravando um texto
						gravador.WriteLine("Apenas um teste:");
						byte[] bytes = new byte[300];
						rand.NextBytes(bytes);
						Array.ForEach(bytes, 
						              delegate (byte b) {
						              	gravador.Write("{0,-4:000}", b);
						              });
						gravador.Write("Fim do teste...");
						// e liberando recursos
						gravador.Flush();
						
						// ler o que foi escrito
						memoria.Position = 0;	// reiniciando o "apontador" do "arquivo" 
						using (StreamReader leitor = new StreamReader(memoria)) 
						{
							Console.WriteLine(leitor.ReadToEnd());
						}
					}
					
				}
				
			} catch (IOException e) 
			{
				// problemas ao gravar o arquivo
				Console.WriteLine("Cannot write to memory\n{0}.", e.Message);
			}
			Console.ReadKey(true);
		}
	}
}