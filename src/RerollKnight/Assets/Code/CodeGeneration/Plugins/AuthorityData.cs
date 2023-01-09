using DesperateDevs.CodeGeneration;
using Entitas.CodeGeneration.Plugins;

namespace Code
{
	public class AuthorityData : CodeGeneratorData
	{
		private const string NameKey = "Authority.Name";
		private const string DataKey = "Authority.Data";
		private const string ContextKey = "Authority.Context";
		
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
		}	}
}