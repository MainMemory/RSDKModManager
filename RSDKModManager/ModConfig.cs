using IniFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSDKModManager
{
	public class ModConfig
	{
		[IniName("mods")]
		public ModList Mods { get; set; } = new ModList();
	}

	public class ModConfigV5
	{
		public ModList Mods { get; set; } = new ModList();
	}

	public class ModList
	{
		[IniCollection(IniCollectionMode.IndexOnly)]
		public Dictionary<string, string> Mods { get; set; } = new Dictionary<string, string>();
	}
}
