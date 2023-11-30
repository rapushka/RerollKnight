using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class HUD : MonoBehaviour
	{
		[SerializeField] private Button _endTurnButton;

		private Contexts _contexts;

		[Inject]
		public void Construct(Contexts contexts)
		{
			_contexts = contexts;
		}

		private void OnEnable()
		{
			_endTurnButton.onClick.AddListener(OnEndTurnButtonClick);
		}

		private void OnDisable()
		{
			_endTurnButton.onClick.RemoveListener(OnEndTurnButtonClick);
		}

		private void OnEndTurnButtonClick()
		{
			Debug.Log("end turn");
		}
	}
}