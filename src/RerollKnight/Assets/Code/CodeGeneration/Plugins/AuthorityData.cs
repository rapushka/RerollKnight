using DesperateDevs.CodeGeneration;
using Entitas.CodeGeneration.Plugins;

namespace Code
{
	public class AuthorityData : CodeGeneratorData
	{
		public const string NameKey = "Authority.Name";
		public const string DataKey = "Authority.Data";

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
	}
}