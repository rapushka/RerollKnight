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

		[Inject]
		public ChipDescriptionBuilder(ILocalizationService localization)
		{
			_localization = localization;
		}

		public string Build(Entity<GameScope> chip)
		{
			var stringBuilder = new StringBuilder();

			foreach (var ability in chip.GetDependants<ChipsScope>())
			{
				if (ability.Has<DealDamage>())
					Append(Localized(Key.DealDamageAbility, ability.Get<DealDamage>().Value));

				if (ability.Has<TargetConstraints>())
					Append(BuildTargetConstrains(ability));
			}

			return stringBuilder.ToString();

			void Append(string value)
			{
				stringBuilder.AppendLine(value);
				stringBuilder.AppendLine();
			}
		}

		private string BuildTargetConstrains(Entity<ChipsScope> ability)
		{
			var stringBuilder = new StringBuilder()
				.AppendLine(Localized(Key.TargetMustBePrefix));

			foreach (var constraint in ability.Get<TargetConstraints>().Value)
			{
				if (!constraint.MustHave)
					stringBuilder.Append(Localized(Key.NotPrefix));

				var name = $"{constraint.Component}Name";
				var displayName = _localization.GetLocalized(Table.DisplayNames, name);
				stringBuilder.AppendLine(displayName);
			}

			return stringBuilder.ToString();
		}

		private string Localized(string key, params object[] arguments)
			=> _localization.GetLocalized(Table.Chips, key, arguments);
	}
}