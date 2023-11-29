using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class ChipConfig
	{
		[field: SerializeField] public string              Label     { get; private set; }
		[field: SerializeField] public List<AbilityConfig> Abilities { get; private set; }
	}
}