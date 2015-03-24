/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 07/06/2014
 * Hora: 21:03
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.IO;
using System.Text;

namespace Arquivos
{
	class Program
	{
		public static void Main(string[] args)
		{
			// um arquivo no sistema
			FileStream arquivo = new FileStream("teste.txt", FileMode.OpenOrCreate);
			try {
				// um objeto que vai ajudar a ler esse arquivo
				StreamReader leitor = new StreamReader(arquivo);
				// uma linha lida a partir do arquivo
				string line;
				
				// (tentando) lendo o arquivo
				while ((line = leitor.ReadLine()) != null)
				{
					Console.WriteLine(line);
				}
				
			} catch (IOException e) {
				// Type: IOException
				Console.WriteLine("It tried to read your file, but {0}.", e.Message);
			} finally {
				Console.WriteLine("Ending application.");
				if (arquivo != null) {
					arquivo.Close();
				}
			}
			
			Console.Write("\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}