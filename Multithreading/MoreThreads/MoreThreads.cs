/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 10/09/2014
 * Hora: 16:42
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Threading;

namespace Multithreading
{
	class MoreThreads
	{
		public static void Main(string[] args)
		{
			// Main Program is created and started
			Console.WriteLine("Main Program Running");
			
			// One Thread
			Thread t1 = new Thread(OneThread);
			t1.Name = "Thread One";
			t1.IsBackground = true;	// thread is in background
			t1.Start();
			
			// Main Program finished
			//Console.WriteLine("Main Program finished");
			
			Console.ReadKey(true);
		}
		// One thread
		public static void OneThread()
		{
			// One Thread started
			Console.WriteLine("{0} started", Thread.CurrentThread.Name);
			// doing some work, like waiting for 5 seconds (5000 ms)
			Thread.Sleep(5000);
			// One Thread finished
			Console.WriteLine("{0} finished", Thread.CurrentThread.Name);
		}
	}
}