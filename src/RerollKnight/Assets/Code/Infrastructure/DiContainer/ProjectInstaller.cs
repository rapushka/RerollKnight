using Zenject;

namespace Code
{
	public class ProjectInstaller : MonoInstaller<ProjectInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindInstance(Contexts.sharedInstance).AsSingle();
		}
	}
}