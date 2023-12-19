using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
	public class BattleLog : MonoBehaviour
	{
		[SerializeField] private LogEntry _logEntryPrefab;
		[SerializeField] private RectTransform _root;
		[SerializeField] private int _maxCountOfLogs;

		private readonly List<LogEntry> _showedLogs = new();

		public void Log(string message)
		{
			_showedLogs.Add(NewLogEntry(message));

			if (_showedLogs.Count > _maxCountOfLogs)
				Remove(_showedLogs.First());
		}

		private void Remove(LogEntry log)
		{
			_showedLogs.Remove(log);
			Destroy(log.gameObject);
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