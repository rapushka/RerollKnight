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

		public void UnMirror()
			=> SetRotation(0);

		private void SetRotation(int y)
			=> transform.eulerAngles = transform.eulerAngles.SetY(y);

		private void RegisterViewComponents()
		{
			GetComponentsInChildren<IViewComponentRegistrar>(includeInactive: true)
				.ForEach((r) => r.Register(_entity));
		}
	}
}
