//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Code.AuthorityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UnityEngine;

public class SomeAuthoring : GameAuthoringBase
{
	[SerializeField] private string _Value;

	public override void Register(ref GameEntity entity) => entity.AddSome(_Value);
}
