using System;
using System.IO;
using System.Linq;
using Code.CodeGeneration.Plugins.Behaviours;
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
		private readonly bool _isFlag;

		public ComponentBehaviourTemplate(ComponentDataBase data)
		{
			_name = data.Name;
			_context = data.Context;
			_memberData = data.MemberData;

			_isFlag = data.IsFlag();
		}

		public string FileName => Path.Combine(Constants.DirectoryName, _context, $"{ClassName}.cs");

		public string FileContent => _isFlag ? FlagClass : ValuedClass;

		private string FlagClass
			=> $@"
public class {ClassName} : {BaseClassName}
{{
	public override void Register(ref {_context}Entity entity) => entity.is{ComponentName} = true;
}}
";

		private string ValuedClass
			=> $@"
using UnityEngine;

public class {ClassName} : {BaseClassName}
{{
{Fields}

	public override void Register(ref {_context}Entity entity) => entity.Add{ComponentName}({Args});
	}}
";

		private string ClassName => ComponentName + Constants.GeneratorClassPostfix;

		private string BaseClassName => _context + Constants.BaseClassPostfix;

		private string ComponentName => _name.ToComponentName(ignoreNamespaces: true);

		private string Fields => MembersAs(Field, separator: LineBreak);

		private string Args => MembersAs((m) => m.GetCamelCaseName(), separator: Coma);

		private string MembersAs(Func<MemberData, string> format, string separator)
			=> string.Join(separator, _memberData.Select(format.Invoke).ToArray());

		private static string Field(MemberData member)
			=> $"\t[SerializeField] private {member.type} _{member.GetCamelCaseName()};";
	}
}