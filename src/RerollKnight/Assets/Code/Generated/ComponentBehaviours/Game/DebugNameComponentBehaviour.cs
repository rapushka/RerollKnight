//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Code.CodeGeneration.Plugins.Behaviours.ComponentBehavioursGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UnityEngine;

public class DebugNameComponentBehaviour : GameComponentBehaviourBase
{
	[SerializeField] private string _value;

	public override void AddToEntity(ref GameEntity entity) => entity.AddDebugName(_value);

	public override void RemoveFromEntity(ref GameEntity entity) => entity.RemoveDebugName();
}
