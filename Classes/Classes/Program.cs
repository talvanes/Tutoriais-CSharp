/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/05/2014
 * Hora: 20:12
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Seres
{
	class Program
	{
		public static void Main(string[] args)
		{
			Gato mussy = new Gato("Mussy", 3, 'F');
			Console.WriteLine(mussy);
			Gato gato = new Gato();
			Console.WriteLine(gato);
			
			Cachorro beethoven = new Cachorro("Beethoven", 4, 'M');
			Console.WriteLine(beethoven);
			Cachorro cachorro = new Cachorro();
			Console.WriteLine(cachorro);
			
			Mulher eva = new Mulher("Fernandes", "Eva", 24);
			Console.WriteLine(eva);
			Mulher qualquerUma = new Mulher();
			Console.WriteLine(qualquerUma);
			
			Homem joao = new Homem("da Silva Leitão", "João", 36);
			Console.WriteLine(joao);
			Homem qualquerUm = new Homem();
			Console.WriteLine(qualquerUm);
			
			Console.WriteLine();
			Console.WriteLine("Há {0} seres aqui, {1} animais e {2} pessoas.", Ser.Quantos(), Animal.Quantos(), Pessoa.Quantos());
			
			Console.Write("\nPress any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}