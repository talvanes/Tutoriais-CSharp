/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/09/2014
 * Hora: 19:57
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Threading;

namespace Multithreading
{
	class ManagingAndDestroying
	{
		public static void Main(string[] args)
		{
			// criando thread filha 1
			ThreadStart childRef1 = new ThreadStart(CallToChildThread1);
			Thread childThread1 = new Thread(childRef1);
			childThread1.Name = "Child 1";
			Console.WriteLine("In Main: {0} Created", childThread1.Name);
			
			// iniciando thread filha 1
			childThread1.Start();
			
			// criando thread filha 2
			ThreadStart childRef2 = new ThreadStart(CallToChildThread2);
			Thread childThread2 = new Thread(childRef2);
			childThread2.Name = "Child 2";
			Console.WriteLine("In Main: {0} Created", childThread2.Name);
			
			// interrompendo o processo principal por algum tempo
			int wait = 4;
			Console.WriteLine("Waiting {0} seconds", wait);
			Thread.Sleep(1000 * wait);		// 5 segundos
			// iniciando thread filha 2
			childThread2.Start();
			// agora, abortando a thread filha 1
			Console.WriteLine("In Main: Aborting {0} Thread", childThread1.Name);
			childThread1.Abort();
			
			// abortando a thread filha 2
			//Console.WriteLine("In Main: Aborting {0} Thread", childThread2.Name);
			//childThread2.Abort();
			
			Console.ReadKey(true);
		}
		
		// Child 1
		public static void CallToChildThread1()
		{
			// desta vez, faremos isso em um bloco try-catch-finally, 
			// pois em alguma hora a thread 1 será abortada
			try {
				Console.WriteLine("\n{0} starts", Thread.CurrentThread.Name);
				// do some work, like counting 
				for (int cont = 1; cont <= 10; cont++) 
				{
					// pausa de 500 ms (meio segundo)
					Thread.Sleep(500);
					Console.Write("{0,-2}", cont);
				}
				Console.WriteLine("\n{0} completed", Thread.CurrentThread.Name);
			} catch (ThreadAbortException e) {
				Console.WriteLine("Thread Abort Exception");
			} /*finally {
				Console.WriteLine("Couldn't catch the Thread Exception");
			}*/
		}
		// Child 2
		public static void CallToChildThread2()
		{
			try {
				Console.WriteLine("\n{0} starts", Thread.CurrentThread.Name);
				// do another work
				int cont = 0;
				while (cont < 10) {
					// espera de 1 segundo
					Thread.Sleep(1000);
					Console.Write("{0,-2}", cont);
					cont++;
				}
				// finished
				Console.WriteLine("\n{0} completed", Thread.CurrentThread.Name);
			} catch (ThreadAbortException e) {
				Console.WriteLine("Thread Abort Exception");
			} /*finally {
				Console.WriteLine("Couldn't catch the Thread Exception");
			}*/
		}
	}
}