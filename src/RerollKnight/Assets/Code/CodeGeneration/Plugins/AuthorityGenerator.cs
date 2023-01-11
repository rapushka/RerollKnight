using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Code.Extensions;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Utils;
using Entitas.CodeGeneration.Plugins;

namespace Code
{
	public class AuthorityGenerator : ICodeGenerator
	{
		private const string DirectoryName = "Authorities";

		public string name         => "Authority";
		public int    priority     => 0;
		public bool   runInDryMode => true;

		public CodeGenFile[] Generate(CodeGeneratorData[] data)
			=> data
			   .OfType<AuthorityData>()
			   .Select(DataToSystem)
			   .ToArray();

		private CodeGenFile DataToSystem(AuthorityData data)
		{
			var componentName = data.Name.ToComponentName(ignoreNamespaces: true);
			
			var fileName = Path.Combine(DirectoryName, data.Context, $"{Template.ClassName(componentName)}.cs");
			var fileContent = data.IsFlag()
				? Template.FlagComponent(componentName, data.Context)
				: Template.ValuableComponent(componentName, data.Context, data.MemberData);
			var generatorName = GetType().FullName;

			return new CodeGenFile(fileName, fileContent, generatorName);
		}

		private static class Template
		{
			public static string FlagComponent(string component, string context)
				=> $@"
public class {ClassName(component)} : {context}AuthoringBase
{{
	public override void Register(ref {context}Entity entity) => entity.is{component} = true;
}}
";

			public static string ValuableComponent(string component, string context, MemberData[] data)
				=> $@"
using UnityEngine;

public class {ClassName(component)} : {context}AuthoringBase
{{
{GenerateFields(data)}

	public override void Register(ref {context}Entity entity) => entity.Add{component}({GenerateArgs(data)});
}}
";

			public static string ClassName(string component) => $"{component}Authoring";

			private static string GenerateFields(IEnumerable<MemberData> data) => Generate(data, "\n", AsField);

			private static string GenerateArgs(IEnumerable<MemberData> data) => Generate(data, ", ", AsCamelCase);

			private static string Generate
				(IEnumerable<MemberData> data, string separator, Func<MemberData, string> template)
				=> string.Join(separator, data.Select(template.Invoke).ToArray());

			private static string AsField(MemberData member) => FieldTemplate(member.name, member.type);

			private static string AsCamelCase(MemberData member) => member.name.LowercaseFirst();

			private static string FieldTemplate(string name, string type)
				=> $"\t[SerializeField] private {type} _{name};";
		}
	}
}