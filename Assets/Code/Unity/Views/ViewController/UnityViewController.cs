using Code.Unity.Views.Registrars;
using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Unity.Views.ViewController
{
	public class UnityViewController : MonoBehaviour, IViewController
	{
		private GameEntity _entity;

		public IViewController Initialize(GameEntity entity)
		{
			_entity = entity;
			
			_entity.AddViewController(this);
			RegisterViewComponents();
			return this;
		}

		public void Mirror()
			=> SetRotation(90);

		public void Unmirror()
			=> SetRotation(0);

		private void SetRotation(int y)
			=> transform.rotation = transform.rotation.SetY(y);

		private void RegisterViewComponents()
		{
			GetComponents<IViewComponentRegistrar>()
			   .ForEach((r) => r.Register(_entity));
		}
	}

	public static class QuaternionExtensions
	{
		public static Quaternion SetY(this Quaternion @this, float y)
		{
			@this.y = y;
			return @this;
		}
	}
}
