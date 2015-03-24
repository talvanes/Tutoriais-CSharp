/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 13/05/2014
 * Hora: 20:34
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Timers;

namespace TesteDeMetodos
{
	class Program
	{
		public static void Main(string[] args)
		{
			Decimal d1 = new Decimal(1.01m);
			Decimal d2 = new Decimal(3.57m);
			Decimal d3 = new Decimal(7.023m);
			Decimal d4 = new Decimal(new Decimal(10.175m));
			
			Decimal d5 = new Decimal(d1);
			d5.Multiplicacao(d2);
			Decimal.Troca(ref d5, ref d2);
			d5.Subtracao(d3);
			Decimal.Troca(ref d4, ref d1);
			d5.Adicao(d4);
			d5.Divisao(d1);
			
			Decimal d6 = (Decimal) d5.Clone();
			Decimal d7 = (Decimal) d5.Copy();
			Console.WriteLine("d5:{0}\nd6:{1}", d5, d6);
			d6.Adicao(1.0m);
			Console.WriteLine("d5:{0}\nd6:{1}", d5, d6);
			d7.Adicao(2.5m);
			Console.WriteLine("d5:{0}\nd7:{1}", d5, d7);
			
			Console.WriteLine("Soma: {0};\nMédia: {1};\nHarmônica: {2}.",
			                  Decimal.Soma(d1, d2, d3, d4, d5, d6, d7),
			                  Decimal.Media(d1, d2, d3, d4, d5, d6, d7),
			                  Decimal.Harmonica(d1, d2, d3, d4, d5, d6, d7)
			                 );
			
			// delegates e timers (métodos anônimos)
			Timer timer = new Timer();
			timer.Elapsed += new ElapsedEventHandler(
				delegate (object source, ElapsedEventArgs e) 
				{
					Console.WriteLine("Event triggered at {0}.", e.SignalTime);
				}
			);
			timer.Interval = 1000;	// em milissegundos
			timer.Enabled = true;	// habilita o evento
			
			// teste de delegate: objeto Decimal
			MethodIntoDecimalClass operateDecimalObject = new MethodIntoDecimalClass(d7.Adicao);
			//operateDecimalObject += new MethodIntoDecimalClass(d7.Subtracao);
			//operateDecimalObject += new MethodIntoDecimalClass(d7.Multiplicacao);
			operateDecimalObject += new MethodIntoDecimalClass(d7.Divisao);
			operateDecimalObject(d1);
			Console.WriteLine(d7);
			operateDecimalObject -= new MethodIntoDecimalClass(d7.Divisao);
			//operateDecimalObject -= new MethodIntoDecimalClass(d7.Multiplicacao);
			//operateDecimalObject -= new MethodIntoDecimalClass(d7.Subtracao);
			//operateDecimalObject -= new MethodIntoDecimalClass(d7.Adicao);
			operateDecimalObject(d1);
			Console.WriteLine(d7);
			
			/*
			  * 
			  * Implementação de delegado anônimo
			  * 
			  * */
			 DoDecimalOperation acao = delegate (Decimal valor, DecimalOperation operation) {
			 	Decimal x = operation.Target as Decimal;
			 	// chamar a operação (só aceita void)
			 	operation(valor);
			 	// calcular o resultado
			 	// propriedade Target nos dá o objeto a que se refere o método
			 	Console.WriteLine("{0:N} {1:N} -> {2:N}", x, valor, operation.Target);
			 };
			 acao(d7, d3.Adicao);
			 acao(d7, d3.Subtracao);
			 acao(d7, d3.Multiplicacao);
			 acao(d7, d3.Divisao);
			 
			
			Console.ReadKey(true);
		}
	}
}