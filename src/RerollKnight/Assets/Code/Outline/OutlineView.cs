using cakeslice;
using UnityEngine;

namespace Code
{
	public class OutlineView : BaseView, IEnableOutlineListener, ITargetStateListener
	{
		[SerializeField] private Outline _outline;

		public void OnEnableOutline(GameEntity entity) => UpdateValue(entity);

		public void OnTargetState(GameEntity entity, TargetState value) => UpdateValue(entity);

		protected override void AddListener(GameEntity entity)
		{
			entity.AddEnableOutlineListener(this);
			entity.AddTargetStateListener(this);
		}

		protected override bool HasComponent(GameEntity entity) => entity.EnableOutline && entity.hasTargetState;

		protected override void UpdateValue(GameEntity entity)
		{
			_outline.enabled = entity.EnableOutline;
			_outline.color = (int)entity.targetState.Value;
		}
	}
}