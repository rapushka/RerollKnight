//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.HelloComponent hello { get { return (Code.HelloComponent)GetComponent(GameComponentsLookup.Hello); } }
    public bool hasHello { get { return HasComponent(GameComponentsLookup.Hello); } }

    public void AddHello(string newValue) {
        var index = GameComponentsLookup.Hello;
        var component = (Code.HelloComponent)CreateComponent(index, typeof(Code.HelloComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHello(string newValue) {
        var index = GameComponentsLookup.Hello;
        var component = (Code.HelloComponent)CreateComponent(index, typeof(Code.HelloComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHello() {
        RemoveComponent(GameComponentsLookup.Hello);
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

    static Entitas.IMatcher<GameEntity> _matcherHello;

    public static Entitas.IMatcher<GameEntity> Hello {
        get {
            if (_matcherHello == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Hello);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHello = matcher;
            }

            return _matcherHello;
        }
    }
}
