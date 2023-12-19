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
		[SerializeField] private float _oldLogsDim;

		private readonly List<LogEntry> _showedLogs = new();

		public void Log(string message)
		{
			DimOldLogs();
			AddNewLog(message);
			RemoveTooOldLogs();
		}

		private void DimOldLogs()
		{
			if (_showedLogs.Any())
				_showedLogs.Last().Opacity -= _oldLogsDim;
		}

		private void AddNewLog(string message)
			=> _showedLogs.Add(NewLogEntry(message));

		private void RemoveTooOldLogs()
		{
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