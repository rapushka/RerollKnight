using System.IO;
using System.Linq;
using DesperateDevs.CodeGeneration;
using Entitas.CodeGeneration.Plugins;

namespace Code
{
	public class AuthorityGenerator : ICodeGenerator
	{
		private const string DirectoryName = "DependenciesSystems";

		public string name         => "Dependency";
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
			var fileName = Path.Combine(DirectoryName, $"{Template.ClassName(componentName)}.cs");
			var generatorName = GetType().FullName;

			var fileContent = IsFlag(data)
				? Template.FlagComponent(componentName, data.Context)
				: Template.ValuableComponent(componentName, data.Context, data.MemberData.Single().type);

			return new CodeGenFile(fileName, fileContent, generatorName);
		}

		private static bool IsFlag(AuthorityData data) 
			=> data.MemberData.ToArray().Any() == false;

		private static class Template
		{
			public static string Base(string context)
				=> $@"
using UnityEngine;

public abstract class {context}AuthoringBase : MonoBehaviour
{{
	public abstract void Register(ref {context}Entity entity);
}}";

			public static string FlagComponent(string component, string context)
				=> $@"
public class {ClassName(component)} : {context}RegistrarBase
{{
	public override void Register(ref {context}Entity entity) => entity.is{component} = true;
}}
";

			public static string ValuableComponent(string component, string context, string type)
				=> $@"
using UnityEngine;

public class {ClassName(component)} : {context}RegistrarBase
{{
	[SerializeField] private {type} _value;

	public override void Register(ref {context}Entity entity) => entity.Add{component}(_value);
}}
";

			public static string ClassName(string component) => $"{component}Authoring";
		}
	}
}