using Code.Component;
using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public class RoomPreview : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private Color _currentRoomColor;
		[SerializeField] private Color _completedRoomColor;
		[SerializeField] private Color _incompletedRoomColor;

		private Entity<GameScope> _roomEntity;
		private MapProvider _mapProvider;

		public void SetData(MapProvider mapProvider, Entity<GameScope> roomEntity)
		{
			_mapProvider = mapProvider;
			_roomEntity = roomEntity;
			Update();
		}

		public void Update()
		{
			if (_roomEntity is null)
				return;

			_image.color
				= IsCurrentRoom                   ? _currentRoomColor
				: _roomEntity.Is<CompletedRoom>() ? _completedRoomColor
				                                    : _incompletedRoomColor;
		}

		private bool IsCurrentRoom => _mapProvider.CurrentRoom == _roomEntity;
	}
}