using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
	[CustomPropertyDrawer(typeof(GameComponentID))]
	public class GameComponentIDDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);

			var valueProperty = property.FindPropertyRelative(nameof(GameComponentID.Value));
			var selectedIndex = valueProperty.intValue;

			selectedIndex = EditorGUI.Popup(position, selectedIndex, GameComponentsLookup.componentNames);
			valueProperty.intValue = selectedIndex;

			EditorGUI.EndProperty();
		}
	}
}