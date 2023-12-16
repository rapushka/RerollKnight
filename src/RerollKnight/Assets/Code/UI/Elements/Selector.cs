using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public abstract class Selector<TBase> : MonoBehaviour
	{
		[SerializeField] private TMP_Text _currentOptionTextMesh;
		[SerializeField] private Button _nextButton;
		[SerializeField] private Button _previousButton;

		private int _currentIndex;
		private TBase[] _options;

		public event Action<TBase> OptionSelected;

		public TBase Selected
		{
			get => _options[_currentIndex];
			set
			{
				_currentIndex = _options.IndexOf(value);
				UpdateVariantText();
			}
		}

		public void Fill(IEnumerable<TBase> options)
			=> _options = options.ToArray();

		private void OnEnable()
		{
			_nextButton.onClick.AddListener(SelectNext);
			_previousButton.onClick.AddListener(SelectPrevious);
		}

		private void OnDisable()
		{
			_nextButton.onClick.RemoveListener(SelectNext);
			_previousButton.onClick.RemoveListener(SelectPrevious);
		}

		private void SelectNext()
		{
			_currentIndex--;
			if (_currentIndex < 0)
				_currentIndex = _options.Length - 1;

			UpdateVariantText();
		}

		private void SelectPrevious()
		{
			_currentIndex++;
			if (_currentIndex >= _options.Length)
				_currentIndex = 0;

			UpdateVariantText();
		}

		private void UpdateVariantText()
		{
			_currentOptionTextMesh.text = Show(_options[_currentIndex]);
			OptionSelected?.Invoke(Selected);
		}

		protected virtual string Show(TBase option) => option.ToString();
	}
}