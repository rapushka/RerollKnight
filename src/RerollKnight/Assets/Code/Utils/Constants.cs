namespace Code
{
	public static class Constants
	{
		public const double Tolerance = 0.01f;
		public const int PlayerSidesCount = 6; // TODO: config

		public static class ToolPath
		{
			public const string Root = "Reroll Knight/";
		}

		public static class Audio
		{
			public const int MaxVolume = 0;
			public const int MinVolume = -80;

			public static class DefaultVolume
			{
				public const float Music = 0.6f;
				public const float Sound = 0.6f;
			}

			public static class ExposedParameter
			{
				public const string MusicVolume = nameof(MusicVolume);
				public const string SoundsVolume = nameof(SoundsVolume);
			}
		}
	}
}