using System;
using UnityEngine;
using Camera = UnityEngine.Camera;

namespace Code
{
	[Serializable]
	public class CamerasProvider
	{
		[field: SerializeField] public Camera MainCamera { get; private set; }
		[field: SerializeField] public Camera UICamera   { get; private set; }
	}
}