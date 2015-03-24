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
 using System;
 using System.Drawing;
 using System.Windows.Forms;
 
namespace WinForms.Anchor {
 	public class Janela : Form 
 	{
 		public Janela() {
 			this.Text = "Anchor";
 			this.Size = new Size(210, 210);
 			// Button 1
 			Button button1 = new Button();
 			button1.Text = "Button";
 			button1.Parent = this;
 			button1.Location = new Point(30, 30);
 			// default Anchor : Top | Left
 			// Button 2
 			Button button2 = new Button();
 			button2.Text = "Button";
 			button2.Parent = this;
 			button2.Location = new Point(30, 80);
 			button2.Anchor = AnchorStyles.Right;
 			
 			CenterToScreen();
 		}
 	}
}
