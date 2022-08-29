using UnityEngine;
// ReSharper disable UnusedMember.Global

namespace Code.Workflow.Extensions
{
	public static class CharacterControllerExtensions
	{
		public static void WarpToGlobal(this CharacterController @this, Vector3 position)
		{
			@this.enabled = false;
			@this.transform.position = position;
			@this.enabled = true;
		}
		
		public static void WarpToLocal(this CharacterController @this, Vector3 position)
		{
			@this.enabled = false;
			@this.transform.localPosition = position;
			@this.enabled = true;
		}
	}
}