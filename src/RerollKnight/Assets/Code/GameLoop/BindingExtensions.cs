using System;
using Zenject;

namespace Code
{
	public static class BindingExtensions
	{
		public static void BindInterfacesAndSelfToAsSingle(this DiContainer @this, params Type[] types)
		{
			foreach (var type in types)
				@this.BindInterfacesAndSelfTo(type).AsSingle();
		}
	}
}