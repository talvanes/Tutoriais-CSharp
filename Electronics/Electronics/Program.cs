/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 27/05/2014
 * Hora: 20:42
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;

namespace Electronics
{
	class Program
	{
		public static void Main(string[] args)
		{
			// TODO: Aguarde implementação...
			Electronic CoC = new Electronic();
			CoC.PlugIn();
			CoC.SwitchOn();
			CoC.VolumeUp(20);
			CoC.VolumeDown(12);
			CoC.VolumeUp(60);
			CoC.VolumeDown(14);
			CoC.VolumeUp();
			Console.WriteLine(CoC);
			
			CoC.Mute();
			Console.WriteLine(CoC);
			CoC.Unmute();
			Console.WriteLine(CoC);
			
			CoC.SwitchOff();
			Console.WriteLine(CoC);
			
			CoC.PlugOff();
			Console.WriteLine(CoC);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}