using System;

namespace Code
{
	[Serializable]
	public class GameComponentID
	{
		public int Value;

		public string Name => GameComponentsLookup.componentNames[Value];
	}
}