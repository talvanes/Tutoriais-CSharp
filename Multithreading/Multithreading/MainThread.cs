/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/09/2014
 * Hora: 19:00
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Threading;

namespace Multithreading
{
	class MainThread
	{
		public static void Main(string[] args)
		{
			Thread thread = Thread.CurrentThread;
			thread.Name = "MainThread";
			Console.WriteLine("Current Thread Information:\n");
			Console.WriteLine("Thread Name: {0}", thread.Name);
			Console.WriteLine("Thread Status: {0}", thread.IsAlive);
			Console.WriteLine("Priority: {0}", thread.Priority);
			Console.WriteLine("Context ID: {0}", Thread.CurrentContext.ContextID);
			Console.WriteLine("Current Application Domain: {0}", Thread.GetDomain().FriendlyName);
			Console.ReadKey(true);
		}
	}
}