//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Code.AuthorityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UnityEngine;

public class HealthAuthoring : GameAuthoringBase
{
	[SerializeField] private int _Value;

	public override void Register(ref GameEntity entity) => entity.AddHealth(value);
}
