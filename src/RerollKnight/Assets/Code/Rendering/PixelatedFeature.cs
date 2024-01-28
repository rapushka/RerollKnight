using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Code.Rendering
{
	public class PixelatedFeature : ScriptableRendererFeature
	{
		[SerializeField] private Settings _settings;

		private PixelatedPass _customPass;

		public override void Create()
		{
			_customPass = new PixelatedPass(_settings);
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
#if UNITY_EDITOR
			if (renderingData.cameraData.isSceneViewCamera)
				return;
#endif

			renderer.EnqueuePass(_customPass);
		}

		[Serializable]
		public class Settings
		{
			public RenderPassEvent RenderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
			public int ScreenHeight = 144; // TODO: ???
		}
	}
}