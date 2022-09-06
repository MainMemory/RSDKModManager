using IniFile;
using ModManagerCommon;
using System.Collections.Generic;
using System.ComponentModel;

namespace RSDKModManager
{
	class RSDKLoaderInfo : LoaderInfo
	{
		public Game? Game { get; set; }
		public string EXEFile { get; set; }
		public int LastGame { get; set; }
		[IniName("Game")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 1)]
		public List<InstalledGame> Games { get; set; } = new List<InstalledGame>();
	}

	public class InstalledGame
	{
		public string Name { get; set; }
		public string Folder { get; set; }
		public string EXEFile { get; set; }
		public Game Game { get; set; }
		[DefaultValue(0)] public long ModUpdateTime { get; set; }
	}

	public enum Game
	{
		SonicCD,
		Sonic1,
		Sonic2,
		SonicMania,
		Sonic1Forever,
		Sonic2Absolute
	}
}
