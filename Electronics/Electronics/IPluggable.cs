/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 27/05/2014
 * Hora: 20:49
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Electronics
{
	/// <summary>
	/// Description of IPluggable.
	/// </summary>
	public interface IPluggable
	{
		/// <summary>
		/// Method signatures for how to plug a device.
		/// </summary>
		/// 
		void PlugIn();
		void PlugOff();
	}
}
