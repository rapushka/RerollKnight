using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FullScreenRenderPassFeature : ScriptableRendererFeature
{
	[SerializeField] private Material _material;

	private CustomRenderPass _customRenderPass;

	public override void Create()
	{
		_customRenderPass = new CustomRenderPass(_material)
		{
			renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing,
		};
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
#if UNITY_EDITOR
		if (renderingData.cameraData.isSceneViewCamera)
			return;
#endif

		renderer.EnqueuePass(_customRenderPass);
	}

	[Serializable]
	public class CustomRenderPass : ScriptableRenderPass
	{
		private const string TempTextureName = "_TempTexture";

		private Material _material;

		private RTHandle _tempTexture;
		private RTHandle _sourceTexture;

		public CustomRenderPass(Material material)
		{
			_material = material;
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
			_sourceTexture = renderingData.cameraData.renderer.cameraColorTargetHandle;
			_tempTexture = RTHandles.Alloc(new RenderTargetIdentifier(TempTextureName), TempTextureName);
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
			var commandBuffer = CommandBufferPool.Get("Full Screen Render Feature");

			var targetDescriptor = renderingData.cameraData.cameraTargetDescriptor;
			targetDescriptor.depthBufferBits = 0;
			commandBuffer.GetTemporaryRT(Shader.PropertyToID(_tempTexture.name), targetDescriptor, FilterMode.Point);
			// TODO: mb Point?

			Blit(commandBuffer, _sourceTexture, _tempTexture, _material);
			Blit(commandBuffer, _tempTexture, _sourceTexture);

			context.ExecuteCommandBuffer(commandBuffer);
			CommandBufferPool.Release(commandBuffer);
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
			_tempTexture.Release();
		}
	}
}