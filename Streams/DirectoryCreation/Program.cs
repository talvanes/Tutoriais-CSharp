/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 13/08/2014
 * Hora: 20:51
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.IO;

namespace DirectoryCreation
{
	class Program
	{
		public static void Main(string[] args)
		{
			// caminho absoluto
			string absolutePath = @"C:\Users\talba\Documents\Projects\";
			// um diretório qualquer
			string directoryName = "dir";
			string directoryName2 = "temp";
			string directoryName3 = "tmp";
			
			
			try 
			{
				if (!Directory.Exists(absolutePath + directoryName) && !Directory.Exists(absolutePath + directoryName2))
				{
					/* criando os diretórios */
					Directory.CreateDirectory(absolutePath + directoryName);
					Directory.CreateDirectory(absolutePath + directoryName2);
					Directory.Move(absolutePath + directoryName2, absolutePath + directoryName3);
				}
				/* mostrando arquivos e pastas */
				DirectoryInfo dir = new DirectoryInfo(absolutePath);
				
				DirectoryInfo[] subDirs = dir.GetDirectories();
				string[] files = Directory.GetFiles(absolutePath);
				// mostrando arquivos
				foreach (DirectoryInfo subDir in subDirs) 
				{
					Console.WriteLine(subDir.Name);
				}
				// mostrando pastas
				foreach (string fileName in files) 
				{
					Console.WriteLine(fileName);
				}	
				
				Console.WriteLine();
				
				/*
				 * Usando Directory.GetFileSystemEntries
				 * */
				string[] entries = Directory.GetFileSystemEntries(absolutePath);
				foreach (string entry in entries) 
				{
					Console.WriteLine(entry);
				}
				
			} catch (IOException e) {
				Console.WriteLine("IO Exception\n{0}", e.Message);
			} catch (UnauthorizedAccessException e) {
				Console.WriteLine("Cannot acess file\n{0}", e.Message);
			}
			
			Console.ReadKey(true);
		}
	}
}