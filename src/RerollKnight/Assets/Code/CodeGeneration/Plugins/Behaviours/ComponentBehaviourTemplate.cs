using System;
using System.IO;
using System.Linq;
using DesperateDevs.Utils;
using Entitas.CodeGeneration.Plugins;

namespace Code.CodeGeneration.Plugins
{
	public class ComponentBehaviourTemplate
	{
		private const string Coma = ", ";
		private const string LineBreak = "\n";

		private readonly string _name;
		private readonly string _context;
		private readonly MemberData[] _memberData;
		private readonly string _component;
		private readonly bool _isFlag;

		public ComponentBehaviourTemplate(ICodeGeneratorData data)
		{
			_name = data.Name;
			_context = data.Context;
			_memberData = data.MemberData;

			_component = data.Name.ToComponentName(ignoreNamespaces: true);
			_isFlag = data.IsFlag();
		}

		public string FileName => Path.Combine(ComponentBehavioursGenerator.DirectoryName, _context, $"{ClassName}.cs");

		public string FileContent => _isFlag ? FlagClass : ValuedClass;

		private string FlagClass
			=> $@"
public class {ClassName} : {BaseClassName}
{{
	public override void Register(ref {_context}Entity entity) => entity.is{_component} = true;
}}
";

		private string ValuedClass
			=> $@"
using UnityEngine;

public class {ClassName} : {BaseClassName}
{{
{Fields}

	public override void Register(ref {_context}Entity entity) => entity.Add{_component}({Args});
	}}
";

		private string ClassName => $"{_component}ComponentBehaviour";

		private string BaseClassName => $"{_context}ComponentBehaviourBase";

		private string Fields => MembersAs(Field, separator: LineBreak);

		private string Args => MembersAs((m) => m.GetCamelCaseName(), separator: Coma);

		private string MembersAs(Func<MemberData, string> format, string separator)
			=> string.Join(separator, _memberData.Select(format.Invoke).ToArray());

		private static string Field(MemberData member)
			=> $"\t[SerializeField] private {member.type} _{member.GetCamelCaseName()};";
	}
}