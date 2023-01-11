using System.Collections.Generic;
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

		public static IEnumerable<INamedTypeSymbol> WithAttribute<T>(this IEnumerable<INamedTypeSymbol> @this)
			=> @this.Where((t) => t.HasAttribute<T>());

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

		public static bool IsFlag(this AuthorityData @this) => @this.MemberData.ToArray().Any() == false;
	}
}