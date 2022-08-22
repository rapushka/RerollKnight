//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity lookReceiveEntity { get { return GetGroup(InputMatcher.LookReceive).GetSingleEntity(); } }
    public Code.Ecs.Components.LookReceiveComponent lookReceive { get { return lookReceiveEntity.lookReceive; } }
    public bool hasLookReceive { get { return lookReceiveEntity != null; } }

    public InputEntity SetLookReceive(UnityEngine.Vector2 newValue) {
        if (hasLookReceive) {
            throw new Entitas.EntitasException("Could not set LookReceive!\n" + this + " already has an entity with Code.Ecs.Components.LookReceiveComponent!",
                "You should check if the context already has a lookReceiveEntity before setting it or use context.ReplaceLookReceive().");
        }
        var entity = CreateEntity();
        entity.AddLookReceive(newValue);
        return entity;
    }

    public void ReplaceLookReceive(UnityEngine.Vector2 newValue) {
        var entity = lookReceiveEntity;
        if (entity == null) {
            entity = SetLookReceive(newValue);
        } else {
            entity.ReplaceLookReceive(newValue);
        }
    }

    public void RemoveLookReceive() {
        lookReceiveEntity.Destroy();
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
public partial class InputEntity {

    public Code.Ecs.Components.LookReceiveComponent lookReceive { get { return (Code.Ecs.Components.LookReceiveComponent)GetComponent(InputComponentsLookup.LookReceive); } }
    public bool hasLookReceive { get { return HasComponent(InputComponentsLookup.LookReceive); } }

    public void AddLookReceive(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.LookReceive;
        var component = (Code.Ecs.Components.LookReceiveComponent)CreateComponent(index, typeof(Code.Ecs.Components.LookReceiveComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLookReceive(UnityEngine.Vector2 newValue) {
        var index = InputComponentsLookup.LookReceive;
        var component = (Code.Ecs.Components.LookReceiveComponent)CreateComponent(index, typeof(Code.Ecs.Components.LookReceiveComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLookReceive() {
        RemoveComponent(InputComponentsLookup.LookReceive);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherLookReceive;

    public static Entitas.IMatcher<InputEntity> LookReceive {
        get {
            if (_matcherLookReceive == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.LookReceive);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherLookReceive = matcher;
            }

            return _matcherLookReceive;
        }
    }
}
