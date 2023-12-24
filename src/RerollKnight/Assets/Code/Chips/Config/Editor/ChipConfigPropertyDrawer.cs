using Entitas.Generic;
using UnityEditor;
using UnityEngine;

namespace Code.Editor
{
	[CustomPropertyDrawer(typeof(ChipConfigBehaviour))]
	public class ChipConfigDrawer : PropertyDrawer
	{
		private static readonly float _lineHeight = EditorGUIUtility.singleLineHeight;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			using var scope = new EditorGUILayout.HorizontalScope();

			var target = (ChipConfigBehaviour)property.objectReferenceValue;
			EditorGUILayout.ObjectField(target, typeof(ChipConfigBehaviour), false);
			var cost = target.Cost;

			EditorGUILayout.LabelField(nameof(ChipConfigBehaviour.Cost) + ":", GUILayout.Width(35f));
			var newCost = EditorGUILayout.IntField(cost);

			if (newCost != cost)
				target.SetPrivateFieldValue("_cost", newCost);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
			=> _lineHeight / 2;
	}
}