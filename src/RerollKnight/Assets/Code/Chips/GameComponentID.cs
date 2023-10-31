using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class GameComponentID
	{
		[SerializeField] private string _name;

		private int? _cashedIndex;

		public int Index => _cashedIndex ??= GetIndex();

		private int GetIndex()
		{
			var indexOf = GameComponentsLookup.componentNames.IndexOf(_name);
			Debug.Assert(indexOf != -1, $"the component {_name} is lost");

			return indexOf;
		}
	}
}