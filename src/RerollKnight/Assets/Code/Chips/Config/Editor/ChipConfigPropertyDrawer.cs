using UnityEditor;
using UnityEngine;
using static UnityEngine.GUILayout;

namespace Code.Editor
{
	[CustomPropertyDrawer(typeof(ChipConfigBehaviour))]
	public class ChipConfigDrawer : PropertyDrawer
	{
		private static readonly float _lineHeight = EditorGUIUtility.singleLineHeight;

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginProperty(position, label, property);
			using var scope = new EditorGUILayout.HorizontalScope();

			var target = property.objectReferenceValue as ChipConfigBehaviour;
			DrawObjectField(property, target);

			if (target is not null)
			{
				DrawCostField(target);
				DrawRarityField(target);
			}

			EditorGUI.EndProperty();
			property.serializedObject.ApplyModifiedProperties();
			EditorUtility.SetDirty(target);
		}

		private static void DrawObjectField(SerializedProperty property, Object target)
		{
			property.objectReferenceValue = EditorGUILayout.ObjectField(target, typeof(ChipConfigBehaviour), false);
		}

		private static void DrawCostField(ChipConfigBehaviour target)
		{
			var cost = target.Cost;
			EditorGUILayout.LabelField(nameof(ChipConfigBehaviour.Cost) + ":", Width(35f));
			var newCost = EditorGUILayout.IntField(cost, Width(35f));

			if (newCost != cost)
				target.SetPrivatePropertyValue("Cost", newCost);
		}

		private static void DrawRarityField(ChipConfigBehaviour target)
		{
			var rarity = target.Rarity;
			EditorGUILayout.LabelField(nameof(ChipConfigBehaviour.Rarity) + ":", Width(40f));
			var newCost = EditorGUILayout.FloatField(rarity, Width(35f));

			if (!newCost.ApproximatelyEquals(rarity))
				target.SetPrivatePropertyValue("Rarity", newCost);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
			=> _lineHeight / 2;
	}
}