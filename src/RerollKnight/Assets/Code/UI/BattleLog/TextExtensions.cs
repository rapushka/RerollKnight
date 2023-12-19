using TMPro;
using static System.Single;

namespace Code
{
	public static class TextExtensions
	{
		public static void SetColor(this TMP_Text @this, float r = NaN, float g = NaN, float b = NaN, float a = NaN)
		{
			var newColor = @this.color;

			if (!IsNaN(r))
				newColor.r = r;
			if (!IsNaN(g))
				newColor.g = g;
			if (!IsNaN(b))
				newColor.b = b;
			if (!IsNaN(a))
				newColor.a = a;

			@this.color = newColor;
		}
	}
}