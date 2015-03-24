/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 07/06/2014
 * Hora: 20:40
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using CustomExceptions;

namespace TesteDeExcecoes
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			try {
				
				// type in variables first
				Console.Write("Type in the first number:");
				double x = Convert.ToDouble(Console.ReadLine());
				if (x > BigValueException.LIMIT) {
					throw new BigValueException("Exceeded the maximum value.");
				}
				Console.Write("Type in the second number:");
				double y = Convert.ToDouble(Console.ReadLine());
				if (y > BigValueException.LIMIT) 
				{
					throw new BigValueException("Exceeded the maximum value.");
				}
				
				// let's try a calculation
				double z = x/y;
				
				Console.WriteLine("Result: {0:N}/{1:N} = {2:N}", x, y, z);
				
			} catch (DivideByZeroException e) {
				// Type: DivideByZeroException
				Console.WriteLine("Cannot divide by zero, because {0}.", e.Message);
			} catch (BigValueException e) {
				Console.WriteLine(e.Message);
			} catch (FormatException e) {
				Console.WriteLine("Wrong format of number.");
				Console.WriteLine(e.Message);
			}
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}