/*
 * Criado por SharpDevelop.
 * Usuário: talba
 * 
 * Para alterar este modelo use Ferramentas | Opções | Codificação | Editar Cabeçalhos Padrão.
 */
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace WinForms.BasicControls {
	public class Janela : Form
	{
		// Barra de título
		private static string titulo = "WinForms Basic Controls";
		// Texto no Label
		private static string texto = @"Uma dica: seja você mesmo.
Não importa o que digam ou o que pensem de você.
Seja você mesmo!";
		
		// Label (texto) do Form Janela
		private Label label;
		// CheckBox para exibir ou não o Label(texto)
		private CheckBox check;
		// CheckBox para a barra de título
		private CheckBox cbTitulo;
		// TrackBar para um controle de volume fictício
		private TrackBar volume;
		// PictureBox para imagem que represente nível de volume
		private PictureBox picbox;
		// Imagens que representem o nível de volume do PictureBox
		private Bitmap mute, min, med, max;	
		// controle de lista combinado (combobox) que listará as fontes instaladas no sistema
		private ComboBox combobox;		
		
		// Construtor de Janela
		public Janela() {
			this.Text = titulo;
			this.Size = new Size(320, 520);
			
			// Label label
			label = new Label();
			label.Parent = this;
			label.Text = texto;
			label.Font = new Font(FontFamily.GenericSerif.Name, 0.5f);
			label.Location = new Point(10,10);
			label.Size = new Size(290,290);
			
			// CheckBox check
			check = new CheckBox();
			check.Parent = this;
			check.Location = new Point(10,310);
			check.Text = "Show Label";
			check.Checked = true;
			check.CheckedChanged += new EventHandler(this.check_OnChanged);
			// CheckBox cbTitulo
			cbTitulo = new CheckBox();
			cbTitulo.Parent = this;
			cbTitulo.Location = new Point(10,330);
			cbTitulo.Text = "Show Title Bar";
			cbTitulo.Checked = true;
			cbTitulo.CheckedChanged += new EventHandler(this.cbTitulo_OnChanged);
			
			// TrackBar volume
			volume = new TrackBar();
			volume.Parent = this;
			volume.Size = new Size(160,30);
			volume.Location = new Point(10,380);
			volume.TickStyle = TickStyle.None;
			volume.ValueChanged += new EventHandler(volume_OnChanged);
			// -- (try) loading picbox images
			try {
				mute = new Bitmap(@"..\..\controls\mute.png");
				min = new Bitmap(@"..\..\controls\min.png");
				med = new Bitmap(@"..\..\controls\med.png");
				max = new Bitmap(@"..\..\controls\max.png");
			} catch (Exception e) {
				MessageBox.Show(e.Message, "Icon missing!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			// PictureBox picbox
			picbox = new PictureBox();
			picbox.Parent = this;
			picbox.Location = new Point(190,380);
			picbox.Image = mute;
			
			// Label apeas rótulo
			Label rotulo = new Label();
			rotulo.Parent = this;
			rotulo.Location = new Point(10, 450);
			rotulo.Text = "Fonte:";
			// ComboBox combobox
			combobox = new ComboBox();
			combobox.Parent = this;
			combobox.Location = new Point(150, 450);
			foreach (FontFamily fonte in FontFamily.Families)
			{
				combobox.Items.Add(fonte.Name);
			}
			combobox.SelectedItem = FontFamily.GenericSerif.Name;
			combobox.SelectedValueChanged += new EventHandler(combo_OnChanged);
			
			this.CenterToScreen();
		}
		
		// CheckBox event: check
		void check_OnChanged(object sender, EventArgs e)
		{
			if (check.Checked) {
				// checkbox check marcado, exibir o texto,
				this.label.Text = texto;
				// e habilite o controle de volume, com seu respectivo ícone 
				this.volume.Enabled = true;
				this.picbox.Enabled = true;
				this.combobox.Enabled = true;
			} else {
				// caso contrário, não exibir,
				this.label.Text = "";
				// desabilitando o controle de volume, com seu respectivo ícone
				this.volume.Enabled = false;
				this.picbox.Enabled = false;
				this.combobox.Enabled = false;
			}
		}
		// CheckBox event: cbTitulo
		void cbTitulo_OnChanged(object sender, EventArgs e)
		{
			this.Text = (cbTitulo.Checked)?
				// checkbox cbTitulo marcado, exibir o texto
				titulo
				:
				// caso contrário, não exibir
				""
				;
		}
		
		// TrackBar event: volume
		void volume_OnChanged(object sender, EventArgs e)
		{
			// obtendo o valor do controle de barra (TrackBar)
			int val = volume.Value;
			// comparando o valor obtido
			if (val == 0) {
				// volume mudo
				picbox.Image = mute;
			} else if (val <= 3) {
				// volume mínimo
				picbox.Image = min;
			} else if (val < 8) {
				// volume médio
				picbox.Image = med;
			} else {
				// volume máximo
				picbox.Image = max;
			}
			
			// um tamanho de fonte a ser ajustado no Label
			// 	val ainda está em pixels, então devemos converter antes para em.	
			float fontSize = (float) (4 * val + 0.5);
			// criando novo objeto Font, já que a propriedade Font é imutável
			Font newFont = new Font(this.label.Font.Name, fontSize);
			this.label.Font = newFont;
		}
		
		// ComboBox event: combo
		void combo_OnChanged(object sender, EventArgs e)
		{
			// capturando o evento de selecionar item na ComboBox do Form
			ComboBox combo2 = (ComboBox) sender;
			string fonte = combo2.Text;
			// ajustar a fonte no label do texto usando o item já selecionado
			Font newFont = new Font(fonte, this.label.Font.Size);
			this.label.Font = newFont;
		}
		
	}
}
