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

		private void RegisterViewComponents()
		{
			GetComponentsInChildren<IViewComponentRegistrar>(includeInactive: true)
				.ForEach((r) => r.Register(_entity));
		}
	}
}