/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/09/2014
 * Hora: 12:39
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 * 
 * From www.zetcode.com
 * 
 */
using System.Windows.Forms;

namespace WinForms.Anchor {
	public class Aplicacao {
		public static void Main(string[] args)
		{
			Janela jan = new Janela();
			Application.Run(new Janela());
		}
	}
}
