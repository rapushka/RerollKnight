using System.Linq;
using DesperateDevs.Roslyn;
using Entitas.CodeGeneration.Attributes;
using Entitas.CodeGeneration.Plugins;
using Microsoft.CodeAnalysis;

namespace Code.Extensions
{
	public static class NamedTypeSymbolExtensions
	{
		private const string Attribute = nameof(Attribute);
		public static bool HasAttribute<T>(this INamedTypeSymbol @this) => @this.GetAttribute<T>() != null;

		private static string RemoveAttributeSuffix(this string @this)
			=> @this.EndsWith(Attribute) ? @this[..^Attribute.Length] : @this;

		public static string GetContext(this INamedTypeSymbol @this)
			=> @this.GetAttributes()
			        .Select((ad) => ad.AttributeClass)
			        .Single((a) => a.BaseType.Name == nameof(ContextAttribute))
			        .Name.RemoveAttributeSuffix();

		public static MemberData[] GetData(this INamedTypeSymbol @this)
			=> @this.GetMembers()
			        .OfType<IFieldSymbol>()
			        .Select((f) => new MemberData(f.Type.ToCompilableString(), f.Name))
			        .ToArray();
	}
}