//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Code.CodeGeneration.Plugins.Behaviours.ComponentBehavioursGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

public class TeleportComponentBehaviour : ChipsComponentBehaviourBase
{
	public override void AddToEntity(ref ChipsEntity entity) => entity.isTeleport = true;

	public override void RemoveFromEntity(ref ChipsEntity entity) => entity.isTeleport = false;
}
