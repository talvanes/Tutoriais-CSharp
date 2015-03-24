/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms.SimpleMenu {
	public class Janela : Form
	{
		// Since the application will look for the behaviour of the statusbar and the menu item,
		// 		we'll consider them class fields 
		private StatusBar statusbar;
		private ToolStripMenuItem viewStatusBar;
		
		// Construtor de Janela
		public Janela() {
			this.Text = "Menus & Toolbars";
			this.Size = new Size(250,200);
			
			//// MainMenu as a MainMenuStrip ////
			MenuStrip mainMenu = new MenuStrip();
			mainMenu.Parent = this;
			
			//// File ToolStripMenuItem
			ToolStripMenuItem file = new ToolStripMenuItem("&File");
			
			// Exit ToolStripMenuItem as a command of File menu item
			ToolStripMenuItem exit = new ToolStripMenuItem("&Exit", null, new EventHandler(this.OnExit));
			exit.ShortcutKeys = Keys.Control | Keys.X;
			
			// Import submenu (it is another ToolStripMenuItem)
			ToolStripMenuItem import = new ToolStripMenuItem();
			import.Text = "Import";
			
			//// View ToolStripMenuItem
			ToolStripMenuItem view = new ToolStripMenuItem("&View");
			
			// viewStatusBar ToolStripMenuItem field
			viewStatusBar = new ToolStripMenuItem("View statusbar");
			viewStatusBar.Checked = true;
			viewStatusBar.Click += new EventHandler(ToggleStatusBar);
			view.DropDownItems.Add(viewStatusBar);
			
			// All commands of Import submenu 
			ToolStripMenuItem temp = new ToolStripMenuItem();
			temp.Text = "Import newsfeed list...";
			import.DropDownItems.Add(temp);
			
			temp = new ToolStripMenuItem();
			temp.Text = "Import bookmarks...";
			import.DropDownItems.Add(temp);
			
			temp = new ToolStripMenuItem();
			temp.Text = "Import mail...";
			import.DropDownItems.Add(temp);
			
			
			//// Application StatusBar ////
			statusbar = new StatusBar();
			statusbar.Parent = this;
			statusbar.Text = "Ready";
			
			
			// Adds Import menu item to File menu
			file.DropDownItems.Add(import);
			// Adds Exit menu item to File menu
			file.DropDownItems.Add(exit);
			// Adds File menu to the main menu strip
			mainMenu.Items.Add(file);
			// Adds View menu to the main menu strip
			mainMenu.Items.Add(view);
			// Plugs mainMenu into the application
			this.MainMenuStrip = mainMenu;
			
			CenterToScreen();
		}
		// OnExit event handler
		public void OnExit(object sender, EventArgs e)
		{
			this.Close();
		}
		// ToggleStatusBar event handler
		public void ToggleStatusBar(object sender, EventArgs e)
		{
			// this flag determines if our menu item (View menu) is checked
			bool check = viewStatusBar.Checked;
			if (check) {
				// if checked, set to false
				statusbar.Visible = false;
				viewStatusBar.Checked = false;
			} else {
				// if not checked, set to true
				statusbar.Visible = true;
				viewStatusBar.Checked = true;
			}			
		}
	}
}
