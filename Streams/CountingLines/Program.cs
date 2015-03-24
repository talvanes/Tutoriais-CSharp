/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 01/08/2014
 * Hora: 19:25
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.IO;

namespace CountingLines
{
	class Program
	{
		public static void Main(string[] args)
		{			
			// para contarmos palavras e caracteres, precisamos de um contador
			int linhas = 0;		// contagem de linhas
			
			try
			{
				// lendo algum arquivo (cláusula "using")
				string caminho = @"..\..\..\com1-serial";
				using (StreamReader leitor = new StreamReader(caminho)) 
				{
					/* lendo caracter por caracter, até chegar ao final do arquivo */
					while (leitor.ReadLine() != null)
					{
						linhas++;
					}
					
					/* mostrando o resultado */
					Console.WriteLine("O arquivo {0} tem {1} linhas.", caminho, linhas);
				}
				
				
				
			} catch (IOException e) 
			{
				// problemas de entrada e saída (IO)
				Console.WriteLine("Cannot read file\n{0}.", e.Message);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}