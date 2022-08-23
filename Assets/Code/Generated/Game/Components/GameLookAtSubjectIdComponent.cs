//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Ecs.Components.LookAtSubjectIdComponent lookAtSubjectId { get { return (Code.Ecs.Components.LookAtSubjectIdComponent)GetComponent(GameComponentsLookup.LookAtSubjectId); } }
    public bool hasLookAtSubjectId { get { return HasComponent(GameComponentsLookup.LookAtSubjectId); } }

    public void AddLookAtSubjectId(int newValue) {
        var index = GameComponentsLookup.LookAtSubjectId;
        var component = (Code.Ecs.Components.LookAtSubjectIdComponent)CreateComponent(index, typeof(Code.Ecs.Components.LookAtSubjectIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLookAtSubjectId(int newValue) {
        var index = GameComponentsLookup.LookAtSubjectId;
        var component = (Code.Ecs.Components.LookAtSubjectIdComponent)CreateComponent(index, typeof(Code.Ecs.Components.LookAtSubjectIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLookAtSubjectId() {
        RemoveComponent(GameComponentsLookup.LookAtSubjectId);
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

    static Entitas.IMatcher<GameEntity> _matcherLookAtSubjectId;

    public static Entitas.IMatcher<GameEntity> LookAtSubjectId {
        get {
            if (_matcherLookAtSubjectId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LookAtSubjectId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLookAtSubjectId = matcher;
            }

            return _matcherLookAtSubjectId;
        }
    }
}
