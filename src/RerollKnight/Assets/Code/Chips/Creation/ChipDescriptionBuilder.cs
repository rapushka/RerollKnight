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
					stringBuilder.Append(Localized(Key.DealDamageAbility, ability.Get<DealDamage>().Value));

				// if 
			}

			return stringBuilder.ToString();
		}

		private string Localized(string key, params object[] arguments)
			=> _localization.GetLocalized(Table.Chips, key, arguments);
	}
}