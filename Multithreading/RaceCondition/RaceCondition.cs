/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 10/09/2014
 * Hora: 17:15
 * 
 * Based on InfoSec Institute's examples available in http://resources.infosecinstitute.com/multithreading/
 * 		Race Condition, one issue in concurrent systems [resolved, thanks to locks]
 * 
 */
using System;
using System.Threading;

namespace Multithreading
{
	class RaceCondition
	{
		// an object that is required for the lock statement
		public static object obj = new object();
		
		public static void Main(string[] args)
		{
			// um vetor que represente um grupo de threads, ou rotinas individuais que serão executadas
			Thread[] threads = new Thread[8];
			// atribuindo o mesmo valor a todas elas
			for (int i = 0; i < threads.Length; i++) 
			{
				// criando uma das threads, que fará a mesma rotina
				threads[i] = new Thread(new ThreadStart(Calculation));
				// dando um nome a ela
				threads[i].Name = String.Format("Thread {0}", i);
				// e, agora, iniciando-a
				threads[i].Start();
			}
			
			Console.ReadKey(true);
		}
		
		// alguma rotina a ser executada
		public static void Calculation()
		{
			lock(obj)
			{
				// inform others on what the current thread is doing 
				Console.Write("{0} is executing: ", Thread.CurrentThread.Name);
				
				short i = 0;
				while (i < 10) 
				{
					Random r = new Random();
					//  random time to wait, in order to simulate how long a calculation will be performed
					Thread.Sleep(1000 * r.Next(8));
					// show a number
					Console.Write("{0,-2}", i);
					i++;
				}
				Console.WriteLine();
			}
			
		}
	}
}