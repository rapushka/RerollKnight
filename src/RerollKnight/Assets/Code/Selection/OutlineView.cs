using cakeslice;
using UnityEngine;

namespace Code
{
	public class OutlineView : BaseView, IOutlineListener
	{
		[SerializeField] private Outline _outline;

		public void OnOutline(GameEntity entity, OutlineParams value)
		{
			_outline.color = (int)value.OutlineType;
			_outline.enabled = value.Enabled;
		}

		protected override void AddListener(GameEntity entity) => entity.AddOutlineListener(this);

		protected override bool HasComponent(GameEntity entity) => entity.hasOutline;

		protected override void UpdateValue(GameEntity entity) => OnOutline(entity, entity.outline.Value);
	}
}