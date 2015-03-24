/*
  * 
  * C# Winforms Message Box Properties, 
  * 	from http://stackoverflow.com/questions/1326566/c-sharp-winforms-message-box-properties
  * 
  * */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForms.WinForms {
	public class Janela : Form
	{
		// tooltip e button são membros da classe Janela
		protected ToolTip tooltip;
		protected Button botao;
		
		// construtor da janela
		public Janela() 
		{
			Text = "Programa em C# WinForms";
			Size = new Size(300,250);
			MaximizeBox = false;
			
			// criando dica de ferramenta (ToolTip control)
			this.tooltip = new ToolTip();
			tooltip.IsBalloon = true;
			tooltip.UseAnimation = true;
			tooltip.UseFading = true;
			tooltip.ToolTipIcon = ToolTipIcon.Info;
			
			// definindo "tooltip" no formulário
			tooltip.SetToolTip(this, "Eu sou uma janela de aplicação Windows!");
			
			// definindo "tooltip" em um botão que ainda será criado
			this.botao = new Button();
			tooltip.SetToolTip(botao, "Eu sou um botão");
			botao.Text = "Botão";	// texto do botão
			// botao.Parent = this;	// o botão está contido na janela do programa
			// código para centralizar o botão no formulário
			botao.Location = new Point(this.Width/2 - botao.Width/2, this.Height/2 - botao.Height/2);
			
			// o botão entra agora em ação: eventos para o BOTÃO!
			botao.Click += new EventHandler(JanelaOnClick);
			botao.MouseEnter += new EventHandler(JanelaOnEnter);
			
			// adicionando componentes (1 botão) na janela do programa
			this.Controls.Add(botao);
			
			// tentar carregar um icone de aplicação
			// uma boa prática em programação com WinForms é colocá-lo em um bloco try-catch 
			try {
				Icon = new Icon(@"..\..\web.ico");
			} catch (Exception e) {
				MessageBox.Show(e.Message, "Icon missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			
			CenterToScreen();
		}
		
		/* JanelaOnClick for Click event */
		void JanelaOnClick(object sender, EventArgs e)
		{
			this.Close();	// fechar o formaulário (janela de aplicação)
		}
		
		/* JanelaOnEnter for MouseEnter event */
		void JanelaOnEnter(object sender, EventArgs e)
		{
			this.tooltip.ToolTipTitle = "O mouse entrou aqui!";
			this.tooltip.ToolTipIcon = ToolTipIcon.Warning;
		}
	}
}