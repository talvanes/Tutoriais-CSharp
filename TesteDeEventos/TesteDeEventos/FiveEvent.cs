/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/07/2014
 * Hora: 19:47
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace TesteDeEventos
{
	/// <summary>
	/// Five Event descriptor (a delegate)
	/// </summary>
	/// 
	public delegate void OnFiveHandler (object sender, FiveEventArgs e);
	
	/// <summary>
	/// Description of FiveEvent.
	/// </summary>
	public class FiveEvent
	{
		// Five Handler field, which is fired when the system generates a number 5.
		public event OnFiveHandler FiveEv;
		
		// routine that is going to be called by our Five Handler event
		public void OnFiveEvent(FiveEventArgs e)
		{
			// executing FiveEvent
			if (FiveEv != null) FiveEv(this, e);
		}
		
		// Callback method: it is executed when the FiveEvent is triggered
		public static void Callback(object sender, FiveEventArgs e)
		{
			Console.WriteLine("\nFive Event {0} ocurred at {1}", e.count, e.when);
		}
		
	}
}
