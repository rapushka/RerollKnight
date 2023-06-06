using DesperateDevs.CodeGeneration;
using Entitas.CodeGeneration.Plugins;

namespace Code.CodeGeneration.Plugins
{
	public interface ICodeGeneratorData
	{
		string       Name       { get; set; }
		MemberData[] MemberData { get; set; }
		string       Context    { get; set; }
	}

	public class BehaviourData : CodeGeneratorData, ICodeGeneratorData
	{
		private const string NameKey = "Behaviour.Name";
		private const string DataKey = "Behaviour.Data";
		private const string ContextKey = "Behaviour.Context";

		public string Name
		{
			get => (string)this[NameKey];
			set => this[NameKey] = value;
		}

		public MemberData[] MemberData
		{
			get => (MemberData[])this[DataKey];
			set => this[DataKey] = value;
		}

		public string Context
		{
			get => (string)this[ContextKey];
			set => this[ContextKey] = value;
		}
	}
}