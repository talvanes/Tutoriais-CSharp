/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 31/07/2014
 * Hora: 20:25
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
			 * liberando recursos manualmente
			  * */
			 
			 // criando arquivo somente-leitura (objeto StreamReader)
			 StreamReader somenteLeitura = null;
			 
			 try {
			 	// leitura do arquivo
			 	somenteLeitura = new StreamReader(@"..\..\..\com1-serial");
			 	Console.WriteLine(somenteLeitura.ReadToEnd());
			 } catch (IOException e) {
			 	// problemas de entrada e saída (IO)
			 	Console.WriteLine("Cannot read file\n{0}.", e.Message);
			 } catch (UnauthorizedAccessException e) {
			 	// restrição de acesso a arquivo
			 	Console.WriteLine("Cannot access file\n{0}.", e.Message);
			 } finally {
			 	// liberando recursos
			 	if (somenteLeitura != null) somenteLeitura.Dispose();
			 }
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}