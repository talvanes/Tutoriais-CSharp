/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 12/09/2014
 * Hora: 20:58
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 * 
 * Based on InfoSec Institute's examples available in http://resources.infosecinstitute.com/multithreading/
 * 		Semaphore, another multithreading algorithm, which lets more threads to execute at once
 */
 using System;
 using System.Threading;
 
 namespace Multithreading {
 	class SemaphoreAlgorithm {
 		// a Semaphore object
 		static Semaphore obj = new Semaphore(2, 4);
 		// Main: the mai routine
 		static void Main(string[] args) {
 			for (byte i = 1; i <= 10; i++) 
 			{
 				Thread th = new Thread(SempStart);
 				// Thread.Start(object parameter): parameter refers to a method's parameter, as in void Method(object arg) 
 				th.Start(i);
 			}
 			Console.ReadKey();
 		}
 		// our semaphore routine: it is similar to mutex, bu tcan handle more than one thread at once 
 		static void SempStart(object id)
 		{
 			Console.WriteLine("{0} <-- wants to get enter", id);
 			try {
 				obj.WaitOne();
 				Console.WriteLine("Success: {0} is in!", id);
 				// do some work
 				Random r = new Random();
 				Thread.Sleep(1000 * r.Next(5));	// espera de tempo de até 5 segundos
 				//
 				Console.WriteLine("{0} --> is evacuating", id);
 			} finally {
 				obj.Release();
 			}
 		}
 	}
 }

