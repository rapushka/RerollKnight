using System.IO;
using System.Linq;
using DesperateDevs.CodeGeneration;

namespace Code
{
	public class BaseAuthorityGenerator : ICodeGenerator
	{
		private const string DirectoryName = "Authorities";

		public string name         => "Authority";
		public int    priority     => 0;
		public bool   runInDryMode => true;

		public CodeGenFile[] Generate(CodeGeneratorData[] data)
			=> data
			   .OfType<AuthorityData>()
			   .Select((d) => d.Context)
			   .ToHashSet()
			   .Select(AsFile)
			   .ToArray();

		private CodeGenFile AsFile(string context)
			=> new
			(
				Path.Combine(DirectoryName, context, $"{Template.ClassName(context)}.cs"),
				Template.AuthoringBase(context),
				GetType().FullName
			);

		private static class Template
		{
			public static string AuthoringBase(string context)
				=> $@"
using UnityEngine;

public abstract class {ClassName(context)} : MonoBehaviour
{{
	public abstract void Register(ref {context}Entity entity);
}}";

			public static string ClassName(string context) => $"{context}AuthoringBase";
		}
	}
}