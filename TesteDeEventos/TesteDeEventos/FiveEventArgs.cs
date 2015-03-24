/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 08/07/2014
 * Hora: 21:09
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace TesteDeEventos
{
	/// <summary>
	/// Description of FiveEventArgs, a child of EventArgs.
	/// </summary>
	public class FiveEventArgs : EventArgs
	{
		// defines how many times this kind of event occurred
		public int count;
		// tells exactly when this event occurred
		public DateTime when;
		
		// a flag to control FiveEvent instances created
		public static int fiveEventCounter = 1; 
		
		/// <summary>
		/// FiveEventArgs constructor
		/// </summary>
		/// <param name="count">Defines how many times this kind of event occurred</param>
		/// <param name="when">Tells exactly the date and time when this event occurred</param>
		public FiveEventArgs(int count, DateTime when)
		{
			// a counter for counting one more FiveEventArgs created
			fiveEventCounter++;
			// initializing FiveEventArgs fields
			this.count = count;
			this.when = when;
		}
	}
}
