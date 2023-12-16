using Zenject;

namespace Code
{
	public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<ToMainMenuTransfer>().AsSingle();
		}
	}
}