/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 31/07/2014
 * Hora: 20:41
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.IO;

namespace Streams
{
	class Program
	{
		public static void Main(string[] args)
		{
			/*
			 * Leitura de arquivo com StreamReader:
			 * liberando recursos automaticamente com a cláusula "using"
			  * */
			 try {
			 	// lendo arquivo com "using" (despejo automático) 
			 	using (StreamReader somenteLeitura = new StreamReader(@"..\..\..\com1-serial")) 
			 	{
			 		// lendo arquivo até o final e mostrando tudo no console
			 		Console.WriteLine(somenteLeitura.ReadToEnd());
			 	}
			 } catch (IOException e) {
			 	// problemas de entrada e saída (IO)
			 	Console.WriteLine("Cannot read file\n{0}.", e.Message);
			 } catch (UnauthorizedAccessException e) {
			 	// restrição de acesso a arquivo
			 	Console.WriteLine("Cannot access file\n{0}.", e.Message);
			 }
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}