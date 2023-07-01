//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class RequestEntity {

    static readonly Code.CastAbilityComponent castAbilityComponent = new Code.CastAbilityComponent();

    public bool isCastAbility {
        get { return HasComponent(RequestComponentsLookup.CastAbility); }
        set {
            if (value != isCastAbility) {
                var index = RequestComponentsLookup.CastAbility;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : castAbilityComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class RequestMatcher {

    static Entitas.IMatcher<RequestEntity> _matcherCastAbility;

    public static Entitas.IMatcher<RequestEntity> CastAbility {
        get {
            if (_matcherCastAbility == null) {
                var matcher = (Entitas.Matcher<RequestEntity>)Entitas.Matcher<RequestEntity>.AllOf(RequestComponentsLookup.CastAbility);
                matcher.componentNames = RequestComponentsLookup.componentNames;
                _matcherCastAbility = matcher;
            }

            return _matcherCastAbility;
        }
    }
}
