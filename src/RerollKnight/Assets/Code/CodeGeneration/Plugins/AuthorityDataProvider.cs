using System.Collections.Generic;
using System.Linq;
using Code.CodeGeneration.Attributes;
using Code.Extensions;
using DesperateDevs.CodeGeneration;
using DesperateDevs.CodeGeneration.Plugins;
using DesperateDevs.Serialization;
using Microsoft.CodeAnalysis;
using PluginUtil = DesperateDevs.Roslyn.CodeGeneration.Plugins.PluginUtil;

namespace Code
{
	public class AuthorityDataProvider : IDataProvider, IConfigurable, ICachable
	{
		private readonly ProjectPathConfig _projectPathConfig = new();

		public string name         => "Cool";
		public int    priority     => 0;
		public bool   runInDryMode => true;

		public Dictionary<string, string> defaultProperties => _projectPathConfig.defaultProperties;
		public Dictionary<string, object> objectCache       { get; set; }

		public void Configure(Preferences preferences) => _projectPathConfig.Configure(preferences);

		// ReSharper disable once CoVariantArrayConversion - this is a Roslyn API
		public CodeGeneratorData[] GetData()
			=> PluginUtil
			   .GetCachedProjectParser(objectCache, _projectPathConfig.projectPath)
			   .GetTypes()
			   .Where((t) => t.HasAttribute<AuthoringAttribute>())
			   .Select(AsCoolData)
			   .ToArray();

		private static AuthorityData AsCoolData(INamedTypeSymbol t)
			=> new()
			{
				Name = t.Name,
				MemberData = t.GetData(),
			};
	}
}