using System.Text;
using Code.Component;
using Entitas.Generic;
using Zenject;
using static Code.Constants.Localization;

namespace Code
{
	public class ChipDescriptionBuilder
	{
		private readonly ILocalizationService _localization;
		private StringBuilder _stringBuilder;

		[Inject]
		public ChipDescriptionBuilder(ILocalizationService localization)
		{
			_localization = localization;
		}

		public string Build(Entity<GameScope> chip)
		{
			_stringBuilder = new StringBuilder();

			foreach (var ability in chip.GetDependants<ChipsScope>())
			{
				AppendAbility(ability);

				if (ability.Has<PerpendicularSpread>())
					Append(Localized(Key.PerpendicularSpreadAbility, ability.Get<PerpendicularSpread>().Value));

				if (ability.Has<Range>())
					Append(Localized(Key.RangeAbility, ability.Get<Range>().Value));

				if (ability.Has<InactiveRange>())
					Append(Localized(Key.InactiveRangeAbility, ability.Get<InactiveRange>().Value + 1));

				if (ability.Is<AllowDiagonals>())
					Append(Localized(Key.AllowDiagonalsAbility));

				if (ability.Has<Recoil>())
					Append(Localized(Key.RecoilAbility, ability.Get<Recoil>().Value));

				if (ability.Has<CrashDamage>())
					Append(Localized(Key.CrashDamageAbility, ability.Get<CrashDamage>().Value));

				AppendAccessDescription(ability);

				if (ability.Has<TargetConstraints>())
					Append(BuildTargetConstrains(ability));
			}

			return _stringBuilder.ToString().Trim();
		}

		private void AppendAbility(Entity<ChipsScope> ability)
		{
			if (ability.Has<DealDamage>())
				Append(Localized(Key.DealDamageAbility, ability.Get<DealDamage>().Value));

			if (ability.Is<SetNextSide>())
				Append(Localized(Key.PickNextSideAbility));

			if (ability.Is<ShowNextSide>())
				Append(Localized(Key.ShowNextSideAbility));

			if (ability.Has<PushDistance>())
				Append(Localized(Key.PushAbility, ability.Get<PushDistance>().Value));

			if (ability.Is<SwapPositions>())
				Append(Localized(Key.SwapPositionsAbility));
		}

		private void AppendAccessDescription(Entity<ChipsScope> ability)
		{
			if (!ability.Is<ConstrainByVisibility>() && !ability.Is<ConsiderObstacles>())
				Append(Localized(Key.IgnoreObstaclesAbility));

			if (ability.Is<ConstrainByVisibility>())
				Append(Localized(Key.ConstrainByVisibilityAbility));

			if (ability.Is<ConsiderObstacles>())
				Append(Localized(Key.ConsiderObstaclesAbility));
		}

		private string BuildTargetConstrains(Entity<ChipsScope> ability)
		{
			var constraintsStringBuilder = new StringBuilder()
				.AppendLine(Localized(Key.TargetMustBePrefix));

			foreach (var constraint in ability.Get<TargetConstraints>().Value)
			{
				if (!constraint.MustHave)
					constraintsStringBuilder.Append(Localized(Key.NotPrefix));

				var name = $"{constraint.Component}Name";
				var displayName = _localization.GetLocalized(Table.DisplayNames, name);
				constraintsStringBuilder.AppendLine(displayName);
			}

			return constraintsStringBuilder.ToString();
		}

		private string Localized(string key, params object[] arguments)
			=> _localization.GetLocalized(Table.Chips, key, arguments);

		private void Append(string value)
		{
			_stringBuilder.AppendLine(value);
			_stringBuilder.AppendLine();
		}
	}
}