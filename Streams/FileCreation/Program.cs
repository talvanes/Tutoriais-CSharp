/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 12/08/2014
 * Hora: 22:21
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace FileCreation
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			// Nome do arquivo
			string filename = @"..\..\..\teste.txt";
			string newfilename = @"..\..\..\cópia de teste.txt";
 			
 			try 
 			{
 				/* Se arquivo TAL existir, obtenha data criação, data modificação e último acesso 
			 	 * Senão, crie-o
 				 */
 				if (File.Exists(filename)) 
 				{
					// Se teste.txt existir, obtenha sua data criação, data modificação e último acesso
					Console.WriteLine("Data da criação: {0}", File.GetCreationTime(filename));
					Console.WriteLine("Data de modificação: {0}", File.GetLastWriteTime(filename));
					Console.WriteLine("Último acesso: {0}", File.GetLastAccessTime(filename));
				} 
 				else
 				{
					// Senão, crie-o.
					using (StreamWriter gravador = File.CreateText(filename)) 
					{
						// (English word vs. Palabra en español)
						Dictionary<string, string> lexicon = new Dictionary<string, string>();
						// populando com palavras
						lexicon.Add("Pineapple", "Ananás");
						lexicon.Add("Apple", "Manzana");
						lexicon.Add("Passion fruit", "Maracuyá");
						lexicon.Add("Banana", "Plátano");
						lexicon.Add("Strawberry", "Frutilla");
						lexicon.Add("Watermelon", "Sandía");
						lexicon.Add("Melon", "Melón");
						lexicon.Add("Lemon", "Limón");
						lexicon.Add("Orange", "Naranja");
						lexicon.Add("Peach", "Melocotón");
						lexicon.Add("Apricot", "Albaricoque");
						lexicon.Add("Sauce", "Salsa");
						lexicon.Add("Bread", "Pán");
						lexicon.Add("Coffee", "Café");
						lexicon.Add("Tea", "Té");
						lexicon.Add("Cake", "Pastel");
						
						// gravando no arquivo
						gravador.WriteLine("*{0,-20}**{1, 20}*\n", new StringBuilder("English"), new StringBuilder("Español"));
						foreach (KeyValuePair<string,string> pair in lexicon) 
						{
							gravador.WriteLine("{0,-20}{1, 20}", pair.Key, pair.Value);
						}
 					}
					
					// vamos copiar o arquivo?
					File.Copy(filename, newfilename);
					//File.Move(newfilename, String.Format("{0} {1}", filename, newfilename));
				} 				
 			} catch (IOException e) {
 				Console.WriteLine("Cannot create file\n{0}", e.Message);
 			} catch (UnauthorizedAccessException e) {
 				Console.WriteLine("Cannot access file\n{0}", e.Message);
 			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}