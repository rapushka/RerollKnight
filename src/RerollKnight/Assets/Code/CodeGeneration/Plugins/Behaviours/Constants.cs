namespace Code.CodeGeneration.Plugins.Behaviours
{
	public static class Constants
	{
		public const string GeneratorName = "Behaviour";
		public const int GeneratorPriority = 0;
		public const bool GeneratorRunInDryMode = true;

		public static class ComponentBehaviour
		{
			public const string DirectoryName = "ComponentBehaviours";

			public const string GeneratorClassPostfix = "ComponentBehaviour";
			public const string BaseClassPostfix = "ComponentBehaviourBase";
		}

		public static class EntityBehaviour
		{
			public const string DirectoryName = "EntityBehaviours";

			public const string GeneratorClassPostfix = "EntityBehaviour";
			public const string BaseClassName = "EntityBehaviourBase";
		}

		public static class MethodName
		{
			public const string AddToEntity = nameof(AddToEntity);
			public const string RemoveFromEntity = nameof(RemoveFromEntity);
		}
	}
}