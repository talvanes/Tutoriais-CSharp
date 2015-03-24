/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/09/2014
 * Hora: 12:56
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
 
namespace WinForms.EditorSkeleton {
	public class Janela : Form {
		// Construtor para Janela
		public Janela() {
			this.Text = "Editor Skeleton";
			this.Size = new Size(210, 180);
			// Main Menu and its menu itens and subitems
			MainMenu mainMenu = new MainMenu();
			MenuItem file = mainMenu.MenuItems.Add("&File");
			file.MenuItems.Add(
				new MenuItem("E&xit", 
				             new EventHandler(this.OnExit), 
				             Shortcut.CtrlX
				            )
			);
			this.Menu = mainMenu;
			// one multiline TextBox docked at all sides (filled)
			TextBox textBox = new TextBox();
			textBox.Parent = this;
			textBox.Dock = DockStyle.Fill;
			textBox.Multiline = true;
			// and one StatusBar
			StatusBar statusBar = new StatusBar();
			statusBar.Parent = this;
			statusBar.Text = "Ready";
			
			CenterToScreen();
		}
		// Manipulador para Evento OnExit
		public void OnExit(object sender, EventArgs e) {
			this.Close();
		}
	}
}