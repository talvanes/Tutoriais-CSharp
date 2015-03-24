/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 27/05/2014
 * Hora: 20:53
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Electronics
{
	/// <summary>
	/// Description of Electronic.
	/// </summary>
	public class Electronic : IDevice, IVolume, IPluggable
	{
		/// <summary>
		/// Fields that describe an electronic device programmatically.
		/// </summary>
		/// 
		protected bool swtch;
		protected int volume;
		private int persistentVolume;
		protected bool plugged;
		
		public Electronic(bool sw, int vol, bool plug)
		{
			/// <summary>
			/// Main constructor
			/// </summary>
			/// 
			this.swtch = sw;
			this.volume = (vol<0)? 0 :
				(
					(vol>100)? 100 : vol
				);
			this.plugged = plug;
		}
		public Electronic() : this(false, 0, false)
		{
			/// <summary>
			/// Default constructor
			/// </summary>
		}
		
		public override string ToString()
		{
			return string.Format("[Electronic Switched={0}, Volume={1,2}, Plugged={2}]", 
			                     (this.swtch)? "Yes" : "No",
			                     this.volume,
			                     (this.plugged)? "Yes" : "No"
			                    );
		}

		
	/**
	 * Implementação de Interfaces a caminho
	 * */
		
		// SwitchOn: switching electronic device on
		public void SwitchOn ()
		{
			this.swtch = true;
		}
		// SwitchOff: switching electronic device off
		public void SwitchOff ()
		{
			this.persistentVolume = 0;
			this.volume = 0;
			this.swtch = false;
		}
		
		// VolumeUp: turning up the volume of the electronic device
		// provided its volume is less than 100%.
		public void VolumeUp (int level = 1)
		{
			if (this.volume < 100)
			{
				this.volume += level;				
			}
		}
		// VolumeDown: turning down the volume of the electronic device
		// provided its volume is greater than 0.
		public void VolumeDown (int level = 1)
		{
			if (this.volume > 0) 
			{
				this.volume -= level;
			}
		}
		// Mute
		public void Mute ()
		{
			// save its volume info first...
			this.persistentVolume = this.volume;
			// ...in order to mute channel.
			this.volume = 0;
		}
		// Unmute
		public void Unmute ()
		{
			// get its volume info saved...
			this.volume = this.persistentVolume;
			// ...in order to unmute channel.
			this.persistentVolume = 0;
		}
		
		// PlugIn
		public void PlugIn ()
		{
			this.plugged = true;
		}
		// PlugOff
		public void PlugOff ()
		{
			this.persistentVolume = 0;
			this.volume = 0;
			this.plugged = false;
		}
		
	/** Fim */
		
	}
}
