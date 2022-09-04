using System;
using System.Windows.Forms;

namespace RSDKModManager
{
	public partial class GameSelectForm : Form
	{
		private Game _game;
		public GameSelectForm(Game game)
		{
			InitializeComponent();
			_game = game;
		}

		private void GameSelectForm_Load(object sender, EventArgs e)
		{
			Game = _game;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			okButton.Enabled = listBox1.SelectedIndex != -1;
		}

		public Game Game
		{
			get => (Game)listBox1.SelectedIndex;
			set => listBox1.SelectedIndex = (int)value;
		}
	}
}
