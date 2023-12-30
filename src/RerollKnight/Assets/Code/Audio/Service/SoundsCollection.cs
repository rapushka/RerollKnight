using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class SoundsCollection
	{
		[field: SerializeField] public List<Entry> Entries { get; private set; }

		private Dictionary<Sound, AudioClip> _dictionary;

		private Dictionary<Sound, AudioClip> Dictionary
			=> _dictionary ??= Entries.ToDictionary((e) => e.Type, (e) => e.Clip);

		public AudioClip this[Sound index] => Dictionary[index];

		[Serializable]
		public class Entry
		{
			[field: SerializeField] public Sound     Type { get; private set; }
			[field: SerializeField] public AudioClip Clip { get; private set; }
		}
	}
}