using Entitas;

namespace Code.Unity.Views.ViewController
{
	public interface IViewController
	{
		IViewController Initialize(GameEntity entity);

		void Mirror();
		void UnMirror();
	}
}
