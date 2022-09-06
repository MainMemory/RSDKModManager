using System.Collections.Generic;

namespace RSDKModManager
{
	class GameInfo
	{
		public readonly Game game;
		public readonly string name, protocol;

		public GameInfo(Game game, string name, string protocol)
		{
			this.game = game;
			this.name = name;
			this.protocol = protocol;
		}

		static readonly Dictionary<Game, string> namedict = new Dictionary<Game, string>();
		static readonly Dictionary<Game, string> protdict = new Dictionary<Game, string>();
		static readonly Dictionary<string, Game> gameprotdict = new Dictionary<string, Game>();
		static GameInfo()
		{
			GameInfo[] games =
			{
				new GameInfo(Game.SonicCD, "Sonic CD", "scdmm"),
				new GameInfo(Game.Sonic1, "Sonic 1", "s1mm"),
				new GameInfo(Game.Sonic2, "Sonic 2", "s2mm"),
				new GameInfo(Game.SonicMania, "Sonic Mania", "smmm"),
				new GameInfo(Game.Sonic1Forever, "Sonic 1 Forever", "s1fmm"),
				new GameInfo(Game.Sonic2Absolute, "Sonic 2 Absolute", "s2amm")
			};
			foreach (var item in games)
			{
				namedict.Add(item.game, item.name);
				protdict.Add(item.game, item.protocol);
				gameprotdict.Add(item.protocol, item.game);
			}
		}

		public static string GetName(Game game) => namedict[game];

		public static string GetProtocol(Game game) => protdict[game];

		public static Game? GetGame(string protocol)
		{
			if (gameprotdict.TryGetValue(protocol, out Game game))
				return game;
			return null;
		}
	}
}
