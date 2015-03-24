/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms.MenuWithImages {
	public class Janela : Form
	{
		// Componentes de barra de ferramentas: ToolBar, ToolBarButtons and ImageList
		// na verdade, TODOS os componentes do Form deveriam ser seus atributos
		//private ToolBar toolBar;
		//private ToolBarButton New;
		//private ToolBarButton Open;
		//private ToolBarButton Exit;
		//private ImageList toolBarIcons;
		
		// Construtor de Janela
		public Janela() {
			this.Text = "Menu with Images";
			this.Size = new Size(250,200);
			
			/* 
 			 * MenuStrip: main menu strip 
 			 */
			MenuStrip menuStrip = new MenuStrip();
			this.MainMenuStrip = menuStrip;
			// File Menu
			ToolStripMenuItem file_menu = new ToolStripMenuItem("&File");
			menuStrip.Items.Add(file_menu);
			// --> New submenu
			ToolStripMenuItem new_sub = new ToolStripMenuItem("&New");
			new_sub.Image = Image.FromFile(@"..\..\images\new.png");
			file_menu.DropDownItems.Add(new_sub);
			// --> Open submenu
			ToolStripMenuItem open_sub = new ToolStripMenuItem("&Open");
			open_sub.Image = Image.FromFile(@"..\..\images\open.png");
			file_menu.DropDownItems.Add(open_sub);
			// --> a separator
			file_menu.DropDownItems.Add(new ToolStripSeparator());
			// --> Exit submenu
			ToolStripMenuItem exit_sub = new ToolStripMenuItem("E&xit");
			exit_sub.Image = Image.FromFile(@"..\..\images\exit.png");
			exit_sub.ShortcutKeys = Keys.Control | Keys.Q;
			exit_sub.Click += OnExit;
			file_menu.DropDownItems.Add(exit_sub);
			
			// Tools Menu
			ToolStripMenuItem tools_menu = new ToolStripMenuItem("&Tools");
			menuStrip.Items.Add(tools_menu);
			/* End of MenuStrip */
			
			
			/*
			 * toolBar ToolBar component 
			 */
			// ToolBar created
			ToolBar toolBar = new ToolBar();
			//toolBar.Parent = this;
			// ImageList created
			ImageList toolBarIcons = new ImageList();
			// ToolBarButtons created and assigned an index
			ToolBarButton New = new ToolBarButton();		// New
			New.ImageIndex = 0;
			New.Tag = "New";
			ToolBarButton Open = new ToolBarButton();	// Open
			Open.ImageIndex = 1;
			Open.Tag = "Open";
			ToolBarButton Exit = new ToolBarButton();	// Exit
			Exit.ImageIndex = 2;
			Exit.Tag = "Exit";
			// adding icons for all buttons
			toolBarIcons.Images.Add(new Icon(@"..\..\images\new.ico"));
			toolBarIcons.Images.Add(new Icon(@"..\..\images\open.ico"));
			toolBarIcons.Images.Add(new Icon(@"..\..\images\exit.ico"));
			// assigning ImageList object to our ToolBar
			toolBar.ImageList = toolBarIcons;
			// show tooltips
			toolBar.ShowToolTips = true;
			// adding all toolbar buttons at once
			toolBar.Buttons.AddRange(new ToolBarButton[] {New, Open, Exit});
			toolBar.ButtonClick += new ToolBarButtonClickEventHandler(ToolBarOnClicked);
			// Adding ToolBar control to the Form
			//this.Controls.Add(toolBar);
			/* End of ToolBar */
			
			/* Adding Controls (menu & toolbar) to Form */
			this.Controls.AddRange(new Control[] {menuStrip, toolBar});
			/* Adding menuStrip to the Form */
			//this.Controls.Add(menuStrip);
			this.MainMenuStrip = menuStrip;
						
			CenterToScreen();
		}
		// OnExit Exit menu item event
		void OnExit(object sender, EventArgs e)
		{
			this.Close();
		}
		// OnClicked toolbar event
		void ToolBarOnClicked(object sender, ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Tag.Equals("Exit")) 
			{
				this.Close();
			}
		}
	}
}
