//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Code.CodeGeneration.Plugins.Behaviours.EntityBehaviourGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UnityEngine;

public class GameEntityBehaviour : EntityBehaviourBase
{
	[SerializeField] private GameComponentBehaviourBase[] _componentBehaviours;
	private GameEntity _entity;

	public GameEntity Entity => _entity;

#if DEBUG
	private void Awake()
	{
		var actualComponentBehaviours = GetComponents<GameComponentBehaviourBase>();
		if (actualComponentBehaviours.Length != _componentBehaviours.Length)
		{
			Debug.LogError("Not all component are added to the entity!");
		}
	}
#endif

	public override void Register()
	{
		_entity = Contexts.sharedInstance.game.CreateEntity();
		foreach (var component in _componentBehaviours)
		{
			component.AddToEntity(ref _entity);
		}
	}

	public override void CollectComponentsFromGameObject()
	{
		_componentBehaviours = GetComponents<GameComponentBehaviourBase>();
	}
}
