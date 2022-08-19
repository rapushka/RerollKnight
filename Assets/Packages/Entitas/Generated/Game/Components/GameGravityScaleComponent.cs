//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gravityScaleEntity { get { return GetGroup(GameMatcher.GravityScale).GetSingleEntity(); } }
    public Code.Ecs.Components.GravityScaleComponent gravityScale { get { return gravityScaleEntity.gravityScale; } }
    public bool hasGravityScale { get { return gravityScaleEntity != null; } }

    public GameEntity SetGravityScale(float newValue) {
        if (hasGravityScale) {
            throw new Entitas.EntitasException("Could not set GravityScale!\n" + this + " already has an entity with Code.Ecs.Components.GravityScaleComponent!",
                "You should check if the context already has a gravityScaleEntity before setting it or use context.ReplaceGravityScale().");
        }
        var entity = CreateEntity();
        entity.AddGravityScale(newValue);
        return entity;
    }

    public void ReplaceGravityScale(float newValue) {
        var entity = gravityScaleEntity;
        if (entity == null) {
            entity = SetGravityScale(newValue);
        } else {
            entity.ReplaceGravityScale(newValue);
        }
    }

    public void RemoveGravityScale() {
        gravityScaleEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Ecs.Components.GravityScaleComponent gravityScale { get { return (Code.Ecs.Components.GravityScaleComponent)GetComponent(GameComponentsLookup.GravityScale); } }
    public bool hasGravityScale { get { return HasComponent(GameComponentsLookup.GravityScale); } }

    public void AddGravityScale(float newValue) {
        var index = GameComponentsLookup.GravityScale;
        var component = (Code.Ecs.Components.GravityScaleComponent)CreateComponent(index, typeof(Code.Ecs.Components.GravityScaleComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGravityScale(float newValue) {
        var index = GameComponentsLookup.GravityScale;
        var component = (Code.Ecs.Components.GravityScaleComponent)CreateComponent(index, typeof(Code.Ecs.Components.GravityScaleComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGravityScale() {
        RemoveComponent(GameComponentsLookup.GravityScale);
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

    static Entitas.IMatcher<GameEntity> _matcherGravityScale;

    public static Entitas.IMatcher<GameEntity> GravityScale {
        get {
            if (_matcherGravityScale == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GravityScale);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGravityScale = matcher;
            }

            return _matcherGravityScale;
        }
    }
}
