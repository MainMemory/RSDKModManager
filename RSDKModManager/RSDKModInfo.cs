using IniFile;
using ModManagerCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace RSDKModManager
{
	public class RSDKModInfo : ModInfo
	{
		[TypeConverter(typeof(RSDKBoolConverter))]
		public bool TxtScripts { get; set; }
		public string DisableFocusPause { get; set; }
		[TypeConverter(typeof(RSDKBoolConverter))]
		public bool RedirectSaveRAM { get; set; }
		[TypeConverter(typeof(RSDKBoolConverter))]
		public bool DisableSaveIniOverride { get; set; }
		[TypeConverter(typeof(RSDKBoolConverter))]
		public bool SkipStartMenu { get; set; }
		[TypeConverter(typeof(RSDKBoolConverter))]
		public bool ForceSonic1 { get; set; }
		[TypeConverter(typeof(RSDKBoolConverter))]
		public bool DisableGameLogic { get; set; }
		public int ForceVersion { get; set; }
		[DefaultValue(5)]
		public int TargetVersion { get; set; }
		public string LogicFile { get; set; }
		public string ConfigFile { get; set; }
		[IniCollection(IniCollectionMode.IndexOnly)]
		public Dictionary<string,string> MiscSettings { get; set; }

		public static new IEnumerable<string> GetModFiles(DirectoryInfo directoryInfo)
		{
			string modini = Path.Combine(directoryInfo.FullName, "mod.ini");
			if (File.Exists(modini))
			{
				yield return modini;
				yield break;
			}

			foreach (DirectoryInfo item in directoryInfo.GetDirectories())
			{
				if (item.Name.Equals("data", StringComparison.OrdinalIgnoreCase) || item.Name[0] == '.')
				{
					continue;
				}

				foreach (string filename in GetModFiles(item))
					yield return filename;
			}
		}
	}
}
