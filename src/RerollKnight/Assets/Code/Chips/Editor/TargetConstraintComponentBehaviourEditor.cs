using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Code.Editor
{
	[CustomEditor(typeof(TargetConstraintsComponentBehaviour))]
	public class TargetConstraintsComponentBehaviourEditor : UnityEditor.Editor
	{
		private ReorderableList _valueList;
		private string[] _componentNames;

		private void OnEnable()
		{
			_componentNames = GameComponentsLookup.componentNames;

			var constraints = serializedObject.FindProperty("_value");
			_valueList = new ReorderableList(serializedObject, constraints, true, true, true, true)
			{
				drawHeaderCallback = DrawHeader,
				drawElementCallback = DrawElement,
				onAddCallback = AddItem,
			};
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.LabelField("Target Constraints");

			// Apply custom style changes
			var customStyle = new GUIStyle(EditorStyles.helpBox)
			{
				padding = new RectOffset(10, 10, 10, 10),
				margin = new RectOffset(0, 0, 5, 10),
			};

			EditorGUILayout.BeginVertical(customStyle);

			serializedObject.Update();

			_valueList.DoLayoutList();

			serializedObject.ApplyModifiedProperties();

			EditorGUILayout.EndVertical();
		}

		private void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect, "Components");
		}

		private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
		{
			var elementProperty = _valueList.serializedProperty.GetArrayElementAtIndex(index);

			rect.y += 2;

			var selectedValue = elementProperty.intValue;

			// Find the index of the selected value in the component names array
			var selectedIndex = GetSelectedIndex(selectedValue);

			// Display the dropdown with component names as options
			selectedIndex = EditorGUI.Popup
			(
				new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
				selectedIndex,
				_componentNames
			);

			// Update the selected value in the list
			elementProperty.intValue = GetSelectedValue(selectedIndex);
		}

		private void AddItem(ReorderableList list)
		{
			var elementProperty = list.serializedProperty;
			elementProperty.arraySize++;
			serializedObject.ApplyModifiedProperties();
		}

		private int GetSelectedIndex(int selectedValue)
		{
			for (var i = 0; i < _componentNames.Length; i++)
			{
				if (_componentNames[i] == _componentNames[selectedValue])
				{
					return i;
				}
			}

			return 0;
		}

		private int GetSelectedValue(int selectedIndex)
		{
			return selectedIndex >= 0 && selectedIndex < _componentNames.Length
				? selectedIndex
				: 0;
		}
	}
}