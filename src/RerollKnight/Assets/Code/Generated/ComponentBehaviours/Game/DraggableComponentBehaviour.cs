//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Code.CodeGeneration.Plugins.Behaviours.ComponentBehavioursGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

public class DraggableComponentBehaviour : GameComponentBehaviourBase
{
	public override void AddToEntity(ref GameEntity entity) => entity.isDraggable = true;

	public override void RemoveFromEntity(ref GameEntity entity) => entity.isDraggable = false;
}
