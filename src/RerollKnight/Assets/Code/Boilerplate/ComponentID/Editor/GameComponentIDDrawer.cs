using Entitas.Generic;
using UnityEditor;

namespace Code.Editor
{
	[CustomPropertyDrawer(typeof(GameComponentID))]
	public class GameComponentIDDrawer : ComponentIDDrawer<GameScope> { }
}