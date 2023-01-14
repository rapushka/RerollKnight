using System;
using System.Collections.Generic;
using System.Linq;
using Code.CodeGeneration.Attributes;
using Code.Extensions;
using DesperateDevs.CodeGeneration;
using DesperateDevs.CodeGeneration.Plugins;
using DesperateDevs.Roslyn;
using DesperateDevs.Serialization;
using Microsoft.CodeAnalysis;
using UnityEngine.UI;
using PluginUtil = DesperateDevs.Roslyn.CodeGeneration.Plugins.PluginUtil;

namespace Code
{
	public class AuthorityDataProvider : IDataProvider, IConfigurable, ICachable
	{
		private readonly ProjectPathConfig _projectPathConfig = new();

		public string name         => "Authority";
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
			   .Where((t) => Enumerable.Any(t.GetAttributes(), (a) => a.ToString() == "Authoring"))
			   .Select(AsAuthorityData)
			   .ToArray();

		private static AuthorityData AsAuthorityData(INamedTypeSymbol type)
			=> new()
			{
				Name = type.Name,
				MemberData = type.GetData(),
				Context = type.GetContext(),
			};
	}
}