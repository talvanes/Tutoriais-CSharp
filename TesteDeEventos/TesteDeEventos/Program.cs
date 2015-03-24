/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/07/2014
 * Hora: 19:45
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Timers;

namespace TesteDeEventos
{
	class Program
	{
		public static void Main(string[] args)
		{
			// "criando" o evento,
			FiveEvent five = new FiveEvent();
			five.FiveEv += new OnFiveHandler(FiveEvent.Callback);
			/*
			// um contador para o tipo desse evento
			//(que tal se esse contador fosse criado como variável de classe?)
			int cont = 0;
			*/
			// e os argumentos que descrevam o evento FiveEventArgs
			FiveEventArgs fiveArgs;
			
			// geração de números aleatórios
			Random rand = new Random();
			
			// um timer para contar o tempo (100 milissegundos)
			Timer timer = new Timer();
			timer.Interval = 100;
			timer.Enabled = true;
			timer.Elapsed += new ElapsedEventHandler(
				delegate (object source, ElapsedEventArgs e)
				{
					//
					// Processando o evento FiveEvent
					//
					
					// gerar um número aleatório
					int num = rand.Next(50);
					if (num == 5) 
					{
						// Número 5? chame o evento FiveEvent
						fiveArgs = new FiveEventArgs(FiveEventArgs.fiveEventCounter, DateTime.Now);
						five.OnFiveEvent(fiveArgs);
					} else 
					{
						// senão, imprima o número
						Console.Write("{0,4}", num);
					}
				}
			);
			
			// o final...
			Console.ReadKey(true);
		}
	}
}