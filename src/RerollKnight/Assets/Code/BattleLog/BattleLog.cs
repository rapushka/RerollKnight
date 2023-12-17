using System.Collections.Generic;
using UnityEngine;

namespace Code
{
	public class BattleLog : MonoBehaviour
	{
		[SerializeField] private LogEntry _logEntryPrefab;
		[SerializeField] private RectTransform _root;

		[Header("View")]
		[SerializeField] private float _opacityStep;

		private readonly List<LogEntry> _showedLogs = new();

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
				log.Opacity -= _opacityStep;

				if (log.Opacity == 0f)
					_showedLogs.Remove(log);
			}
		}

		private LogEntry NewLogEntry(string message)
		{
			var logEntry = Instantiate(_logEntryPrefab, _root);
			logEntry.Message = message;
			logEntry.Opacity = 1;

			return logEntry;
		}
	}
}