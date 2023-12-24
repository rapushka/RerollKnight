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
			EditorGUI.PropertyField(position, property, label, true);
			var target = (ChipConfigBehaviour)property.objectReferenceValue;
			var cost = target.Cost;

			var costRect = new Rect(position.x, position.y + _lineHeight + 1f, position.width, _lineHeight);

			var newCost = EditorGUI.IntField(costRect, nameof(ChipConfigBehaviour.Cost), cost);

			if (newCost != cost)
				target.SetPrivateFieldValue("_cost", newCost);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
			=> EditorGUI.GetPropertyHeight(property, label, true) + _lineHeight + (_lineHeight * 0.5f);
	}
}