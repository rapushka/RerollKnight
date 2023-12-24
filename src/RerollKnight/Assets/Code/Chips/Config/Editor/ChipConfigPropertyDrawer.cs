using System;
using UnityEditor;
using UnityEngine;
using static System.Reflection.BindingFlags;

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
				target.SetPrivatePropertyValue("Cost", newCost);
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
			=> _lineHeight / 2;
	}

	public static class ReflectionExtensions
	{
		public static void SetPrivatePropertyValue<T>(this object @this, string propertyName, T value)
		{
			var type = @this.GetType();
			var propertyInfo = type.GetProperty(propertyName, Instance | NonPublic | Public)
			                   ?? throw NoPropertyException(propertyName, type);

			propertyInfo.SetValue(@this, value);
		}

		private static ArgumentException NoPropertyException(string propertyName, Type type)
			=> new($"Property '{propertyName}' not found in type '{type}'.");
	}
}