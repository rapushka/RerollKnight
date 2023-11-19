using System.Collections.Generic;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class ChipsEntityFormatter : EntityComponentsListFormatter<ChipsScope>
	{
		protected override string Separator => " | ";

		protected override IEnumerable<string> CreateList(Entity<ChipsScope> entity)
		{
			yield return entity.ToString<Teleport>();
			yield return entity.ToString<MaxCountOfTargets, int>("max targets: ");
			yield return entity.ToString<Range, int>("range: ");
			yield return entity.ToString<Component.AbilityState, AbilityState>("state: ");

			yield return TargetConstraints(entity);

			var abilityOfChip = entity.GetOrDefault<AbilityOfChip>();
			if (abilityOfChip is not null)
				yield return ChipId.Index.GetEntity(abilityOfChip.Value)?.ToString() ?? "no chip!";
			// yield return abilityOfChip.Value.ToString();
		}

		private string TargetConstraints(Entity<ChipsScope> entity)
		{
			var component = entity.GetOrDefault<TargetConstraints>();
			return component is not null
				? $"constraints: [{string.Join(", ", component.Value)}]"
				: string.Empty;
		}
	}
}