using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class AudioSourcesProvider
	{
		[field: SerializeField] public AudioSource SoundsSource { get; private set; }
		[field: SerializeField] public AudioSource MusicSource  { get; private set; }
	}
}