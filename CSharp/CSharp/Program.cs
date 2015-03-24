/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 13/04/2014
 * Hora: 00:52
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Collections.Generic;

namespace CSharp
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// Lista de números
			List<int> numeros = new List<int> {};
			// digite um número: n
			int num;
			do {
				Console.WriteLine("Digite um número: ");
				num = Convert.ToInt32(Console.ReadLine());
			} while (num <= 0);
			
			/* Inserir elementos na lista */
			/* que tenham uma categoria */
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}