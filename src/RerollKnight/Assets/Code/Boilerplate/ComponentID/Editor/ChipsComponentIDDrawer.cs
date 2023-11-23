using Entitas.Generic;
using UnityEditor;

namespace Code.Editor
{
	[CustomPropertyDrawer(typeof(ChipsComponentID))]
	public class ChipsComponentIDDrawer : ComponentIDDrawer<ChipsScope> { }
}