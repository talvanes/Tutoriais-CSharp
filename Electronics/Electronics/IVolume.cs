/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 27/05/2014
 * Hora: 20:46
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Electronics
{
	/// <summary>
	/// Description of IVolume.
	/// </summary>
	public interface IVolume
	{
		/// <summary>
		/// Method signatures for how to change the volume of a device. 
		/// </summary>
		/// 
		void VolumeUp(int level);
		void VolumeDown(int level);
		void Mute();
		void Unmute();
	}
}
