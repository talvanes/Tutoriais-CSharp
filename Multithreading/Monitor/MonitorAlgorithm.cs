/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 10/09/2014
 * Hora: 17:15
 * 
 * Based on InfoSec Institute's examples available in http://resources.infosecinstitute.com/multithreading/
 * 		Monitor algorithm, which has an advantage over locks, because they wait for the time for threads to complete. 
 * 
 */
using System;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace Multithreading
{
	[SynchronizationAttribute]
	class MonitorAlgorithm
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
			// algoritmo Monitor para solução de problemas em sistemas multithreading
			Monitor.Enter(obj);
			try {
				// mostrando que thread será executada
				Console.Write("{0} is executing: ", Thread.CurrentThread.Name);
				// Monitor entra em ação para a rotina de cálculo
				short i = 0;
				while (i < 8) 
				{
					Random r = new Random();
					Thread.Sleep(1000 * r.Next(8));	// geração de tempos aleatórios entre 0 e 8 segundos
					Console.Write("{0,-2}", i);
					i++;
				}
			} catch {} // cláusula catch 'vazia'
			finally {
				// Fim de monitor
				Monitor.Exit(obj);
			}
			Console.WriteLine();
		}
	}
}