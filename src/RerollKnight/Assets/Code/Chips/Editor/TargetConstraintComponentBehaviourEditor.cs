using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Code.Editor
{
	[CustomEditor(typeof(TargetConstraintsComponentBehaviour))]
	public class TargetConstraintsComponentBehaviourEditor : UnityEditor.Editor
	{
		private ReorderableList _values;
		private string[] _componentNames;

		private void OnEnable()
		{
			_componentNames = GameComponentsLookup.componentNames;

			var constraints = serializedObject.FindProperty("_value");
			_values = new ReorderableList(serializedObject, constraints, true, true, true, true)
			{
				drawHeaderCallback = DrawHeader,
				drawElementCallback = DrawElement,
				onAddCallback = AddItem,
			};
		}

		public override void OnInspectorGUI()
		{
			EditorGUILayout.LabelField("Target Constraints");

			var customStyle = new GUIStyle(EditorStyles.helpBox)
			{
				padding = new RectOffset(10, 10, 10, 10),
				margin = new RectOffset(0, 0, 5, 10),
			};

			EditorGUILayout.BeginVertical(customStyle);
			{
				serializedObject.Update();
				_values.DoLayoutList();
				serializedObject.ApplyModifiedProperties();
			}
			EditorGUILayout.EndVertical();
		}

		private void DrawHeader(Rect rect)
		{
			EditorGUI.LabelField(rect, "Components");
		}

		private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
		{
			rect.y += 2;

			var elementProperty = _values.serializedProperty.GetArrayElementAtIndex(index);
			rect = new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight);

			var selectedIndex = EditorGUI.Popup(rect, elementProperty.intValue, _componentNames);

			elementProperty.intValue = Clamp(selectedIndex);
		}

		private void AddItem(ReorderableList list)
		{
			var elementProperty = list.serializedProperty;
			elementProperty.arraySize++;
			serializedObject.ApplyModifiedProperties();
		}

		private int Clamp(int selectedIndex) => selectedIndex.Clamp(min: 0, max: _componentNames.Length);
	}
}