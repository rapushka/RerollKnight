using System.Collections.Generic;
using NSubstitute;
using UnityEngine.Localization;

namespace Code.Editor.Tests
{
	public static class Mock
	{
		public static IChipConfig ChipConfig()
		{
			var config = Substitute.For<IChipConfig>();
			config.LabelKey.Returns(new LocalizedString());
			config.Abilities.Returns(new List<AbilityConfigBehaviour>());
			return config;
		}
	}
}