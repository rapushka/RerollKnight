//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.DebugNameComponent debugName { get { return (Code.DebugNameComponent)GetComponent(GameComponentsLookup.DebugName); } }
    public bool hasDebugName { get { return HasComponent(GameComponentsLookup.DebugName); } }

    public void AddDebugName(string newValue) {
        var index = GameComponentsLookup.DebugName;
        var component = (Code.DebugNameComponent)CreateComponent(index, typeof(Code.DebugNameComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDebugName(string newValue) {
        var index = GameComponentsLookup.DebugName;
        var component = (Code.DebugNameComponent)CreateComponent(index, typeof(Code.DebugNameComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDebugName() {
        RemoveComponent(GameComponentsLookup.DebugName);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherDebugName;

    public static Entitas.IMatcher<GameEntity> DebugName {
        get {
            if (_matcherDebugName == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DebugName);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDebugName = matcher;
            }

            return _matcherDebugName;
        }
    }
}
