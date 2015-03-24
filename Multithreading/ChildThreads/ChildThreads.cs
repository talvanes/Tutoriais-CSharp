/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/09/2014
 * Hora: 19:14
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Threading;

namespace Multithreading
{
	class ChildThreads
	{
		public static void Main(string[] args)
		{
			// iniciar thread filha 1 (é um delegado)
			ThreadStart childRef1 = new ThreadStart(CallChildThread1);
			Console.WriteLine("In Main: creaing child thread 1");
			Thread childThread1 = new Thread(childRef1);
			childThread1.Name = "Child 1";
			childThread1.Start();
			
			Console.ReadKey(true);
		}
		
		public static void CallChildThread1()
		{
			Console.WriteLine("{0} starts...", Thread.CurrentThread.Name);
		}
	}
}