using UnityEngine;
using Zenject;

namespace Code
{
	public class CoordinatesView : BaseView, ICoordinatesListener
	{
		[SerializeField] private Transform _transform;

		private ILayoutService _layout;

		[Inject] public void Construct(ILayoutService layout) => _layout = layout;

		public void OnCoordinates(GameEntity entity, Coordinates value)
			=> _transform.position = value.ToTopDown() + _layout.OverFieldOffset;

		protected override void AddListener(GameEntity entity) => entity.AddCoordinatesListener(this);

		protected override bool HasComponent(GameEntity entity) => entity.hasCoordinates;

		protected override void UpdateValue(GameEntity entity) => OnCoordinates(entity, entity.coordinates.Value);
	}
}