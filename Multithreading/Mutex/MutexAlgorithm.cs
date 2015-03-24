/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 12/09/2014
 * Hora: 20:33
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 * 
 * Based on InfoSec Institute's examples available in http://resources.infosecinstitute.com/multithreading/
 * 		Mutex, another multithreading algorithm 
 * 
 */
using System;
using System.Threading;

namespace Multithreading {
	class MutexAlgorithm {
		// um objeto mutex
		private static Mutex mutex = new Mutex();
		// Main: a rotina principal
		public static void Main(string[] args) {
			short i = 1;
			while (i <= 5) 
			{
				Thread th = new Thread(new ThreadStart(MutexDemo));
				th.Name = String.Format("Thread {0}", i);
				th.Start();
				i++;
			}
			Console.ReadKey();
		}
		// MutexDemo: uma demonstração do algoritmo Mutex
		public static void MutexDemo()
		{
			try {
				// wait until it is safe to enter
				mutex.WaitOne();
				// 
				Console.WriteLine("{0} has entered the Domain", Thread.CurrentThread.Name);
				// wait until it is safe to enter
				Random r = new Random();
				Thread.Sleep(1000 * r.Next(10));	// tempo de espera de até 10 segundos
				// 
				Console.WriteLine("{0} is leaving the Domain", Thread.CurrentThread.Name);
			} finally {
				// release Mutex object
				mutex.ReleaseMutex();
			}
		}
	}
}
