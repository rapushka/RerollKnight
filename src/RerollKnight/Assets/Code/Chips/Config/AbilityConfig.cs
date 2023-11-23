using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class AbilityConfig
	{
		[field: SerializeField] public ChipsComponentID Kind { get; private set; }

		[field: SerializeField] public int Range        { get; private set; }
		[field: SerializeField] public int TargetsCount { get; private set; }

		[field: SerializeField] public List<ComponentConstraint> TargetConstraints { get; private set; }
	}
}