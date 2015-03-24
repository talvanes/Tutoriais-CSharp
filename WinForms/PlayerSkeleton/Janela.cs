/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/09/2014
 * Hora: 17:27
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms.PlayerSkeleton {
	public class Janela : Form
	{
		// Construtor de Janela
		public Janela() {
			this.Text = "Player Skeleton";
			this.Size = new Size(350, 280);
			
			/* Main MenuBar, the app's menu */
			MainMenu mainMenu = new MainMenu();
			MenuItem file = mainMenu.MenuItems.Add("&File");
			file.MenuItems.Add(
				new MenuItem(
					"E&xit",
					new EventHandler(this.OnExit),
					Shortcut.CtrlX
				)
			);
			MenuItem playm = mainMenu.MenuItems.Add("&Play");
			MenuItem view = mainMenu.MenuItems.Add("&View");
			MenuItem tools = mainMenu.MenuItems.Add("&Tools");
			MenuItem favourites = mainMenu.MenuItems.Add("F&avourites");
			MenuItem help = mainMenu.MenuItems.Add("&Help");
			this.Menu = mainMenu;
			
			/* A black panel that 'mimics' a media control */
			Panel panel = new Panel();
			panel.Parent = this;
			panel.BackColor = Color.Black;
			panel.Dock = DockStyle.Fill;	// pay attention!
			
			/* Another tiny panel where to place all media buttons in */
			Panel buttonPanel = new Panel();
			buttonPanel.Parent = this;
			buttonPanel.Height = 40;	// height: 40px
			buttonPanel.Dock = DockStyle.Bottom;	// pay attention!
			// Pause button
			Button pause = new Button();
			pause.FlatStyle = FlatStyle.Popup;
			pause.Parent = buttonPanel;
			pause.Location = new Point(5,10);
			pause.Size = new Size(25,25);
			pause.Image = new Bitmap(@"..\..\images\pause.png");
			// Play button
			Button play = new Button();
			play.FlatStyle = FlatStyle.Popup;
			play.Parent = buttonPanel;
			play.Location = new Point(35,10);
			play.Size = new Size(25,25);
			play.Image = new Bitmap(@"..\..\images\play.png");
			// Backward button
			Button backward = new Button();
			backward.FlatStyle = FlatStyle.Popup;
			backward.Parent = buttonPanel;
			backward.Location = new Point(110,10);
			backward.Size = new Size(25,25);
			backward.Image = new Bitmap(@"..\..\images\backward.png");
			// Forward button
			Button forward = new Button();
			forward.FlatStyle = FlatStyle.Popup;
			forward.Parent = buttonPanel;
			forward.Location = new Point(80,10);
			forward.Size = new Size(25,25);
			forward.Image = new Bitmap(@"..\..\images\forward.png");
			// Audio button
			Button audio = new Button();
			audio.FlatStyle = FlatStyle.Popup;
			audio.Parent = buttonPanel;
			audio.Location = new Point(170,10);
			audio.Size = new Size(25,25);
			audio.Image = new Bitmap(@"..\..\images\audio.png");
			audio.Anchor = AnchorStyles.Right;	// pay attention!
			// TrackBar component
			TrackBar trackBar = new TrackBar();
			trackBar.Parent = buttonPanel;
			trackBar.TickStyle = TickStyle.None;
			trackBar.Size = new Size(150,25);
			trackBar.Location = new Point(200,10);
			trackBar.Anchor = AnchorStyles.Right;	// pay attention!
			
			/* And a StatusBar */
			StatusBar statusBar = new StatusBar();
			statusBar.Parent = this;
			statusBar.Text = "Ready";
			statusBar.ShowPanels = true;
			
			/*
			 * Looking for the application's icon
			  * */
			try {
			 	this.Icon = new Icon(@"..\..\images\Windows-Media-Player.ico", new Size(16,16));
			} catch (Exception e) {
			 	MessageBox.Show(e.Message, "Application icon missing!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			CenterToScreen();
		}
		// and an OnExit event, which will close the "Janela" Form
		public void OnExit(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
