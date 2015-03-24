/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 07/09/2014
 * Hora: 13:32
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using Indexadores;

namespace Indexadores
{
	class Program
	{
		public static void Main(string[] args)
		{
			IndexedArray ia = new IndexedArray();
			ia[0] = "Pois é";
			ia[1] = "Não há de que";
			ia[2] = "Nao se engane!";
			ia[3] = "2.0";
			ia[4] = "CQC";
			ia[5] = "Pânico na Band";
			ia[6] = 0x083;
			//ia[7] = "ht";
			//ia[8] = 027637;
			//ia[9] = '\u0879';
			for (int i = 0; i < ia.Count; i++) {
				Console.WriteLine("{0}: {1}", i, ia[i]);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}