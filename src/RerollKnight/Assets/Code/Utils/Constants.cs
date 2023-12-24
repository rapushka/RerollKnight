namespace Code
{
	public static class Constants
	{
		public const double Tolerance = 0.01f;

		public static class ToolPath
		{
			public const string Root = "Reroll Knight/";
		}

		public static class Localization
		{
			public static class Key
			{
				// Game
				public const string PlayerCurrentActor = "PlayerCurrentActor";
				public const string EnemyCurrentActor = "EnemyCurrentActor";
				public const string NoCurrentActor = "NoCurrentActor";
				public const string NextSideHudView = "NextSideHudView";

				// Display Names
				public const string ChipCastedMessage = "ChipCastedMessage";
				public const string EntityAtCoordinatesMessage = "EntityAtCoordinatesMessage";

				// Abilities
				public const string DealDamageAbility = "DealDamageAbility";
				public const string NotPrefix = "NotPrefix";
				public const string TargetMustBePrefix = "TargetMustBePrefix";
				public const string RangeAbility = "RangeAbility";
				public const string PickNextSideAbility = "PickNextSideAbility";
				public const string ShowNextSideAbility = "ShowNextSideAbility";
				public const string ConstrainByVisibilityAbility = "ConstrainByVisibilityAbility";
				public const string ConsiderObstaclesAbility = "ConsiderObstaclesAbility";
				public const string IgnoreObstaclesAbility = "IgnoreObstaclesAbility";
				public const string PushAbility = "PushAbility";
				public const string SwapPositionsAbility = "SwapPositionsAbility";
				public const string CrashDamageAbility = "CrashDamageAbility";
				public const string AllowDiagonalsAbility = "AllowDiagonalsAbility";
				public const string RecoilAbility = "RecoilAbility";
				public const string PerpendicularSpreadAbility = "PerpendicularSpreadAbility";
				public const string InactiveRangeAbility = "InactiveRangeAbility";
				public const string MoveChipToSideAbility = "MoveChipToSideAbility";
			}

			public static class Table
			{
				public const string Game = "Game";
				public const string Chips = "Chips";
				public const string DisplayNames = "DisplayNames";
			}
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