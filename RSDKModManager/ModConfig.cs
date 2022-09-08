using IniFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace RSDKModManager
{
	public class ModConfig
	{
		[IniIgnore]
		public ModList Mods { get; set; } = new ModList();
		[IniIgnore]
		public bool IsV5 { get; set; }
		[IniName("mods")]
		public ModList ModsV3V4
		{
			get => IsV5 ? null : Mods;
			set
			{
				if (value?.Mods != null)
				{
					Mods = value;
					IsV5 = false;
				}
			}
		}
		[IniName("Mods")]
		public ModList ModsV5
		{
			get => IsV5 ? Mods : null;
			set
			{
				if (value?.Mods != null)
				{
					Mods = value;
					IsV5 = true;
				}
			}
		}
	}

	public class ModList
	{
		[IniCollection(IniCollectionMode.IndexOnly, ValueConverter = typeof(RSDKBoolConverter))]
		public Dictionary<string, bool> Mods { get; set; } = new Dictionary<string, bool>();
	}

	public class RSDKBoolConverter : BooleanConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string str)
				switch (str)
				{
					case "true":
					case "1":
					case "y":
						return true;
					default:
						return false;
				}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
				return (bool)value ? "true" : "false";
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
