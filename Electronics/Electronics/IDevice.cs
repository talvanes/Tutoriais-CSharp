/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 27/05/2014
 * Hora: 20:44
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Electronics
{
	/// <summary>
	/// Description of IDevice.
	/// </summary>
	public interface IDevice
	{
		/// <summary>
		/// Method signatures for how to switch a device.
		/// </summary>
		void SwitchOn();
		void SwitchOff();
	}
}
