/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 24/06/2014
 * Hora: 21:06
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using CartesianSystem2D;

// mesmos parâmetros da função referenciada
internal delegate void TesteDelegado();
// outro tipo delegado (equivale em C/C++ como um ponteiro para função)
internal delegate void Delegado2<T>(T objeto);
internal delegate void Delegado3(object objeto);

namespace TesteDeDelegado
{
	class Program
	{
		public static void Main(string[] args)
		{
			// criando instância do delegado
			//TesteDelegado delega = new TesteDelegado(ToNemAi);
			TesteDelegado delega = ToNemAi;
			
			// para usar um método em sua forma mais simples
			delega();
			
			/* 
			 * Testes 
			 * */
			Delegado2<double> DoublDelega = new Delegado2<double>(Mostra);
			//DoublDelega(2.0);
			DoublDelega += new Delegado2<double>(MostraTudo);
			DoublDelega(2.0);
			
			Delegado2<string> StringDelega = new Delegado2<string>(Mostra);
			//StringDelega("Talvanes");
			StringDelega += new Delegado2<string>(MostraTudo);
			StringDelega("Talvanes");
			
			Point ponto = new Point(1.0, 2.0);
			Delegado2<Point> PointTypeDelega = new Delegado2<Point>(Mostra);
			//PointTypeDelega(ponto);
			PointTypeDelega += new Delegado2<Point>(MostraTudo);
			PointTypeDelega(ponto);
			
			/*
			 * Mais testes
			 * */
			Delegado3 Generico = delegate (object objeto) {
				Console.WriteLine(@"Hi! I'm a {0}. My value is {1} and I'm in {2}.", objeto.GetType(), objeto, objeto.GetType().Module);
			};
			Generico(new Point(2,3));
			Generico(PointTypeDelega);
			Generico(Generico);
			Generico(2.01);
			Generico(StringDelega);
			
			Console.WriteLine("Pressione qualquer tecla...");
			Console.ReadKey(true);
		}
		
		// função destino com os mesmos parâmetros do delegado
		public static void ToNemAi()
		{
			Console.WriteLine("Meu tipo é: {0}.", typeof(TesteDelegado));
		}
		
		// funções destino (delegados) que mostrarão um tipo de dado e seu tipo
		public static void Mostra<T>(T objeto)
		{
			Console.WriteLine("{0}->{1}", objeto, objeto.GetType().Name);
		}
		public static void MostraTudo<T>(T objeto)
		{
			Console.WriteLine("{0}->{1}:{2}", objeto, objeto.GetType().Name, objeto.GetHashCode());
		}
	}
}