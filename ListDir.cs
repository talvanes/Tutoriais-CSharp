/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 17/08/2014
 * Hora: 01:00
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 * 
 * ListDir command:
 * 		Usage: ListDir [dir1 dir2 dir3 (...)]
 * 		where [dir1 dir2 dir3 (...)] is a list of directories to show its contents from, 
 * 
 */
using System;
using System.IO;

namespace ListDir
{
	class Program
	{
		public static void Main(string[] args)
		{
			// Analisar cada argumento passado por linha de comando, que será um diretório
			foreach (string arg in args) 
			{
				// Para cada arg, criar um objeto DirectoryInfo, que será um diretório
				DirectoryInfo dir = Directory.CreateDirectory(arg);
				// Listar os arquivos e subdiretórios que dir contém
				DirectoryInfo[] subDirs = dir.GetDirectories();
				FileInfo[] files = dir.GetFiles();
				
				// Mostrando o diretório e seu tamanho total
				Console.WriteLine("{0}", dir.FullName);
				
				// Mostrando os diretórios
				foreach (DirectoryInfo subDir in subDirs) 
				{
					Console.WriteLine("{0}\n{1}\n{2} {3} {4}", 
					                  // atributos
					                  subDir.Attributes,
					                  // nome
					                  subDir.Name, 
					                  // data de modificação
					                  "M:" + subDir.LastWriteTime,
					                  // data de criação
					                  "C:" + subDir.CreationTime,
					                  // último acesso
					                  "A:" + subDir.LastAccessTime
					                 );
					Console.WriteLine();
				}
				// Mostrando os arquivos
				foreach (FileInfo file in files) 
				{
					Console.WriteLine("{0} {5}B\n{1}\n{2} {3} {4}",
					    // atributos
						file.Attributes,
						// nome
						file.Name,
						// data de modificação
						"M:" + file.LastWriteTime,
						// data de criação
						"C:" + file.CreationTime,
						// último acesso
						"A:" + file.LastAccessTime,
						// tamanho do arquivo (em bytes)
						file.Length
					);
					Console.WriteLine();
				}
			}
			
			Console.ReadKey(true);
		}
	}
}