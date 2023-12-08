using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	public class ChipConfigBehaviour : MonoBehaviour
	{
		[field: SerializeField] public string                       Label     { get; private set; }
		[field: SerializeField] public List<AbilityConfigBehaviour> Abilities { get; private set; }
	}
}