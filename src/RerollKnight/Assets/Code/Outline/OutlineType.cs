using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public struct OutlineParams
	{
		[field: SerializeField] public Type OutlineType { get; private set; }
		[field: SerializeField] public bool Enabled     { get; private set; }

		public OutlineParams(Type outlineType, bool enabled)
		{
			OutlineType = outlineType;
			Enabled = enabled;
		}

		public enum Type
		{
			Available,
			Selected,
			Wrong,
		}
	}
}