using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
	[CustomPropertyDrawer(typeof(ArrayLayout<bool>))]
	public class WallsLayoutDrawer : PropertyDrawer
	{
		private const float ElementHeight = 18f;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			EditorGUI.PrefixLabel(position, label);

			var newPosition = position;
			newPosition.y += ElementHeight;
			var rows = property.FindPropertyRelative("Rows");

			for (var y = 0; y < Constants.RoomSizes; y++)
			{
				var row = rows.GetArrayElementAtIndex(y).FindPropertyRelative("Value");
				newPosition.height = ElementHeight;

				newPosition.width = ElementHeight; // position.width / Constants.RoomSizes * 0.33f;
				DrawRow(row, newPosition);

				newPosition.x = position.x;
				newPosition.y += ElementHeight;
			}

			EditorGUI.EndProperty();
		}

		private void DrawRow(SerializedProperty row, Rect newPosition)
		{
			for (var x = 0; x < Constants.RoomSizes; x++)
			{
				var element = row.GetArrayElementAtIndex(x);
				GUI.backgroundColor = element.boolValue ? Color.black : Color.white;

				EditorGUI.PropertyField(newPosition, element, GUIContent.none);
				newPosition.x += newPosition.width;
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
		{
			return ElementHeight * (Constants.RoomSizes + 1);
		}
	}
}