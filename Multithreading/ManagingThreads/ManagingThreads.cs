/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/09/2014
 * Hora: 19:24
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Threading;

namespace Multithreading
{
	class ManagingThreads
	{
		public static void Main(string[] args)
		{
			// criando thread filha 1 (ThreadStart é um delegado)
			ThreadStart childRef1 = new ThreadStart(CallToChildThread1);
			Console.WriteLine("In Main: Creating {0} thread", Thread.CurrentThread.Name);
			Thread childThread1 = new Thread(childRef1);
			childThread1.Name = "Child 1";
			childThread1.Start();
			
			Console.ReadKey(true);
		}
		public static void CallToChildThread1()
		{
			Console.WriteLine("{0} starts", Thread.CurrentThread.Name);
			// forçando espera, pausando a thread por 5 segundos
			int wait = 5;
			Console.WriteLine("{0} is paused for {1} seconds", Thread.CurrentThread.Name, wait);
			Thread.Sleep(1000 * wait);	// convertendo para milissegundos
			// retomando execução da thread filha
			Console.WriteLine("{0} resumes", Thread.CurrentThread.Name);
		}
	}
}