/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * Data: 11/09/2014
 * Hora: 13:25
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms.AnchoredButtons {
	public class Janela : Form {
		// "variáveis" int que auxiliarão o dimensionamento da nossa caixa de diálogo		
		private int WIDTH = 250;
		private int HEIGHT = 150;
		private int BUTTONS_SPACE = 15;
		private int PANEL_SPACE = 8;
		private int CLOSE_SPACE = 10;
		// Construtor de Janela
		public Janela() {
			this.Text = "Fake Dialog";
			this.Size = new Size(WIDTH, HEIGHT);
			// botão OK
			Button ok = new Button();
			int PANEL_HEIGHT = ok.Height + PANEL_SPACE;
			// Um painel, que vai abrigar os botões
			Panel panel = new Panel();
			panel.Height = PANEL_HEIGHT;
			panel.Dock = DockStyle.Bottom;
			panel.Parent = this;
			// botão OK (continuação)
			int x = 2 * ok.Width + BUTTONS_SPACE;
			int y = (PANEL_HEIGHT - ok.Height) / 2;
			ok.Text = "OK";
			ok.Parent = panel;
			ok.Location = new Point(WIDTH - x, y);
			ok.Anchor = AnchorStyles.Right;
			// botão Fechar
			Button close = new Button();
			x = close.Width;
			close.Text = "Close";
			close.Parent = panel;
			close.Location = new Point(WIDTH - x - CLOSE_SPACE, y);
			close.Anchor = AnchorStyles.Right;
			
			CenterToScreen();
		}
		
	}
}
