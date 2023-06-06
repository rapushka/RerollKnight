using System.Collections.Generic;
using System.Linq;
using Code.CodeGeneration.Attributes;
using DesperateDevs.CodeGeneration;
using DesperateDevs.CodeGeneration.Plugins;
using DesperateDevs.Serialization;
using Microsoft.CodeAnalysis;
using PluginUtil = DesperateDevs.Roslyn.CodeGeneration.Plugins.PluginUtil;

namespace Code.CodeGeneration.Plugins
{
	// ReSharper disable once UnusedType.Global – used in Jenny
	public class ComponentBehaviourDataProvider : IDataProvider, IConfigurable, ICachable
	{
		private readonly ProjectPathConfig _projectPathConfig = new();

		public string name         => "ComponentBehaviour";
		public int    priority     => 0;
		public bool   runInDryMode => true;

		public Dictionary<string, object> objectCache { get; set; }

		public Dictionary<string, string> defaultProperties => _projectPathConfig.defaultProperties;

		public void Configure(Preferences preferences) => _projectPathConfig.Configure(preferences);

		// ReSharper disable once CoVariantArrayConversion - this is a Roslyn API
		public CodeGeneratorData[] GetData()
			=> PluginUtil
			   .GetCachedProjectParser(objectCache, _projectPathConfig.projectPath)
			   .GetTypes()
			   .WithAttribute<BehaviourAttribute>()
			   .Select(AsAuthorityData)
			   .ToArray();

		private static BehaviourData AsAuthorityData(INamedTypeSymbol type)
			=> new()
			{
				Name = type.Name,
				MemberData = type.GetData(),
				Context = type.GetContext(),
			};
	}
}