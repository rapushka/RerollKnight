using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class Vector3Extensions
	{
		public static Vector3 SetX(this Vector3 @this, float x)
		{
			Vector3 temp = @this;
			temp.x = x;
			@this = temp;

			return @this;
		}
		
		public static Vector3 SetY(this Vector3 @this, float y)
		{
			Vector3 temp = @this;
			temp.y = y;
			@this = temp;

			return @this;
		}
	}
}
