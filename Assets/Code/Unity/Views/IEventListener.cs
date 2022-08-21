using Entitas;

namespace Code.Unity.Views
{
	public interface IEventListener
	{
		void Register(IEntity entity);
		void UnRegister();
	}
}
