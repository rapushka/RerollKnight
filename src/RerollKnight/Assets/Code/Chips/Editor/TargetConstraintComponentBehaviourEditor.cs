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
			var names = GameComponentsLookup.componentNames;

			var nameProperty = property.FindPropertyRelative("_name");
			var selectedName = nameProperty.stringValue;

			var selectedIndex = names.IndexOf(selectedName, clamped: true);
			selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, names);

			nameProperty.stringValue = names[selectedIndex];

			EditorGUI.EndProperty();
		}
	}
}