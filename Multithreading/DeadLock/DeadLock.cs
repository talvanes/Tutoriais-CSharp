/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 10/09/2014
 * Hora: 17:39
 * 
 * Based on InfoSec Institute's examples available in http://resources.infosecinstitute.com/multithreading/
 * 		Deadlock, another serious issue in concurrent systems
 * 
 */
using System;
using System.Threading;

namespace Multithreading
{
	class DeadLock
	{
		// two objects to be locked
		static object object1 = new Object();
		static object object2 = new Object();
		
		// Deadlock1 will lock object1 first and then object2
		public static void DeadLock1()
		{
			lock (object1)
			{
				Console.WriteLine("Object1 locked");
				// wait for 1 second
				Thread.Sleep(1000);
				// and then lock object2
				lock (object2) {
					Console.WriteLine("Object2 locked");
				}
			}
		}
		// Deadlock2 will lock object2 first and then object1
		public static void DeadLock2()
		{
			lock (object2)
			{
				Console.WriteLine("Object2 locked");
				// wait for 1 second
				Thread.Sleep(1000);
				// and then lock object1
				lock (object1) {
					Console.WriteLine("Object1 locked");
				}
			}
		}
		public static void Main(string[] args)
		{
			// Create and start two threads that will deadlock your system
			Thread t1 = new Thread(new ThreadStart(DeadLock1));
			Thread t2 = new Thread(new ThreadStart(DeadLock2));
			t1.Start();
			t2.Start();
			
			Console.ReadKey(true);
		}
	}
}