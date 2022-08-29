using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class CharacterControllerExtensions
	{
		public static void WarpTo(this CharacterController @this, Vector3 position)
		{
			@this.enabled = false;
			@this.transform.position = position;
			@this.enabled = true;
		}
	}
}