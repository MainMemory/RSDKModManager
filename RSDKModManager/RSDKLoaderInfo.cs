using ModManagerCommon;
using System.ComponentModel;

namespace RSDKModManager
{
	class RSDKLoaderInfo : LoaderInfo
	{
		public Game? Game { get; set; }
		public string EXEFile { get; set; }
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
