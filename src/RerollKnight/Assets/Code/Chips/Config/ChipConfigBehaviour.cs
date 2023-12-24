using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace Code
{
	public class ChipConfigBehaviour : MonoBehaviour
	{
		[field: SerializeField] public LocalizedString LabelKey { get; private set; }
		[SerializeField] private int _cost;
		[field: SerializeField] public List<AbilityConfigBehaviour> Abilities { get; private set; }

		public int Cost => _cost;
	}
}