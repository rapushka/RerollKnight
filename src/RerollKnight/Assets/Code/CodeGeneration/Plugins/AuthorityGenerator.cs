using System.Collections.Generic;
using System.IO;
using System.Linq;
using DesperateDevs.CodeGeneration;
using DesperateDevs.Utils;
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
		{
			return data.MemberData.ToArray().Any() == false;
		}

		private static string Resolving(IEnumerable<string> dependencies)
			=> string.Join("\n", dependencies.Select(Template.ResolveDependency));

		private static class Template
		{
			public static string System(string component, string context, string resolving, bool isFlag)
				=> $@"
using System.Collections.Generic;
using Entitas;
public sealed class {ClassName(component)} : ReactiveSystem<{context}Entity>
{{
	public {ClassName(component)}(Contexts contexts) : base(contexts.{context.LowercaseFirst()}) {{ }}
	protected override ICollector<{context}Entity> GetTrigger(IContext<{context}Entity> context)
		=> context.CreateCollector({context}Matcher.{component});
	protected override bool Filter({context}Entity entity) => entity.{(isFlag ? "is" : "has")}{component};
	protected override void Execute(List<{context}Entity> entities)
	{{
		foreach (var e in entities)
		{{
{resolving}
		}}
	}}
}}";

			public static string Base(string context)
				=> $@"
using UnityEngine;

public abstract class {context}AuthoringBase : MonoBehaviour
{{
	public abstract void Register(ref {context}Entity entity);
}}";

			public static string FlagComponent(string component, string context)
				=> $@"
public class {component}Authoring : {context}RegistrarBase
{{
	public override void Register(ref {context}Entity entity) => entity.is{component} = true;
}}
";

			public static string ValuableComponent(string component, string context, string type)
				=> $@"
using UnityEngine;

public class {component}Authoring : {context}RegistrarBase
{{
	[SerializeField] private {type} _value;

	public override void Register(ref {context}Entity entity) => entity.Add{component}(_value);
}}
";

			public static string ClassName(string component) => $"Resolve{component}DependenciesSystem";

			public static string ResolveDependency(string member) => $"\t\t\t{member};";
		}
	}
}