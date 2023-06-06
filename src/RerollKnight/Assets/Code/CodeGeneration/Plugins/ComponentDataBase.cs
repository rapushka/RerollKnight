using DesperateDevs.CodeGeneration;
using Entitas.CodeGeneration.Plugins;

namespace Code.CodeGeneration.Plugins
{
	public abstract class ComponentDataBase : CodeGeneratorData
	{
		protected abstract string NameKey    { get; }
		protected abstract string DataKey    { get; }
		protected abstract string ContextKey { get; }

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