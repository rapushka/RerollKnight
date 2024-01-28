using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Code
{
	public class PixelatedPass : ScriptableRenderPass
	{
		private PixelatedFeature.Settings _settings;

		private RenderTargetIdentifier _colorBuffer;
		private RenderTargetIdentifier _pixelBuffer;
		private int _pixelBufferID = Shader.PropertyToID("_PixelBuffer");

		private Material _material;
		private int _pixelScreenHeight;
		private int _pixelScreenWidth;

		public PixelatedPass(PixelatedFeature.Settings settings)
		{
			_settings = settings;
			renderPassEvent = settings.RenderPassEvent;
			_material = CoreUtils.CreateEngineMaterial("Hidden/Pixelated");
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			_colorBuffer = renderingData.cameraData.renderer.cameraColorTarget; // TODO: obsolete
			var descriptor = renderingData.cameraData.cameraTargetDescriptor;

			_pixelScreenHeight = _settings.ScreenHeight;
			_pixelScreenWidth = (int)(_pixelScreenHeight * renderingData.cameraData.camera.aspect + 0.5f); // TODO: ???

			_material.SetVector("_BlockCount", new Vector2(_pixelScreenWidth, _pixelScreenHeight));
			_material.SetVector("_BlockSize", new Vector2(1f / _pixelScreenWidth, 1f / _pixelScreenHeight));
			_material.SetVector("_HalfBlockSize", new Vector2(0.5f / _pixelScreenWidth, 0.5f / _pixelScreenHeight));

			descriptor.height = _pixelScreenHeight;
			descriptor.width = _pixelScreenWidth;

			cmd.GetTemporaryRT(_pixelBufferID, descriptor, FilterMode.Point);
			_pixelBuffer = new RenderTargetIdentifier(_pixelBufferID);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			var cmd = CommandBufferPool.Get();

			using (new ProfilingScope(cmd, new ProfilingSampler("Pixelated Pass")))
			{
				// TODO: obsolete
				Blit(cmd, _colorBuffer, _pixelBuffer, _material);
				Blit(cmd, _pixelBuffer, _colorBuffer);
			}
			
			context.ExecuteCommandBuffer(cmd);
			CommandBufferPool.Release(cmd);
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
			if (cmd == null)
				throw new ArgumentNullException(nameof(cmd));
			
			cmd.ReleaseTemporaryRT(_pixelBufferID);
		}
	}
}