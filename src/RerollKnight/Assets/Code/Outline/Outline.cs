using System;
using UnityEngine;

// ReSharper disable LocalVariableHidesMember - UnityEngine.Component.renderer is obsolete

namespace Code
{
	public class Outline : MonoBehaviour
	{
		[SerializeField] private Material _outlineMaterial;
		[SerializeField] private Renderer[] _renderers;

		private Material _materialInstance;

		private Material MaterialInstance
		{
			get
			{
				if (_materialInstance == null)
					_materialInstance = new Material(_outlineMaterial);

				return _materialInstance;
			}
		}

		private static readonly int EnabledId = Shader.PropertyToID("_Enabled");
		private static readonly int ColorId = Shader.PropertyToID("_Color");

		private void Start()
		{
			foreach (var renderer in _renderers)
				renderer.materials = renderer.materials.Add(MaterialInstance);
		}

		private void OnDestroy()
		{
			foreach (var renderer in _renderers)
			{
				var indexOfOutline = renderer.materials.IndexOf(MaterialInstance);

				if (indexOfOutline == -1)
					throw new InvalidOperationException($"{name}'s Renderer doesn't have outline");

				renderer.materials = renderer.materials.RemoveAt(indexOfOutline);
			}

			if (MaterialInstance != null)
				Destroy(MaterialInstance);
		}

		public bool Enabled { set => MaterialInstance.SetInt(EnabledId, value ? 1 : 0); }

		public int Color
		{
			set
			{
				// Unavailable = -1,
				// Available,
				// Hovered,
				// Wrong,
				var color = value switch // TODO: config
				{
					0 => UnityEngine.Color.yellow,
					1 => UnityEngine.Color.white,
					2 => UnityEngine.Color.red,
					_ => UnityEngine.Color.clear,
				};

				MaterialInstance.SetColor(ColorId, color);
			}
		}
	}
}