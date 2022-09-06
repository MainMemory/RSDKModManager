using System;
using System.Windows.Forms;

namespace RSDKModManager
{
	public partial class GameSelectForm : Form
	{
		public GameSelectForm(Game game)
		{
			InitializeComponent();
			listBox1.SelectedIndex = (int)game;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			textBox1.Text = GameInfo.GetName(Game);
		}

		public Game Game => (Game)listBox1.SelectedIndex;

		public string GameName => textBox1.Text;
	}
}
