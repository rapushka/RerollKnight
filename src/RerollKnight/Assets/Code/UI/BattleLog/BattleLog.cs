using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	public class BattleLog : MonoBehaviour
	{
		private const float Spacing = 5f;

		[SerializeField] private LogEntry _logEntryPrefab;
		[SerializeField] private RectTransform _root;

		private readonly List<LogEntry> _showedLogs = new();
		private float _entryHeight;
		private float _wholeHeight;

		// Tricky way to fade and have all entries fit into root
		private float OpacityStep => 1 / ((_wholeHeight - _entryHeight) / (_entryHeight + Spacing));

		private void Start()
		{
			_wholeHeight = _root.rect.height;
			_entryHeight = _logEntryPrefab.GetComponent<RectTransform>().rect.height;
		}

		public void Log(string message)
		{
			DimShowedLogs();
			_showedLogs.Add(NewLogEntry(message));
		}

		private void DimShowedLogs()
		{
			for (var i = _showedLogs.Count - 1; i >= 0; i--)
			{
				var log = _showedLogs[i];
				log.Opacity -= OpacityStep;

				if (log.Opacity <= 0f)
				{
					_showedLogs.Remove(log);
					Destroy(log.gameObject);
				}
			}
		}

		private LogEntry NewLogEntry(string message)
		{
			var logEntry = Instantiate(_logEntryPrefab, _root);
			logEntry.Message = message;
			logEntry.Opacity = 1f;

			return logEntry;
		}
	}
}