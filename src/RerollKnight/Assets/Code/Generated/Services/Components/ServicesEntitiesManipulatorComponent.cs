//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServicesContext {

    public ServicesEntity entitiesManipulatorEntity { get { return GetGroup(ServicesMatcher.EntitiesManipulator).GetSingleEntity(); } }
    public Code.EntitiesManipulatorComponent entitiesManipulator { get { return entitiesManipulatorEntity.entitiesManipulator; } }
    public bool hasEntitiesManipulator { get { return entitiesManipulatorEntity != null; } }

    public ServicesEntity SetEntitiesManipulator(Code.IEntitiesManipulatorService newValue) {
        if (hasEntitiesManipulator) {
            throw new Entitas.EntitasException("Could not set EntitiesManipulator!\n" + this + " already has an entity with Code.EntitiesManipulatorComponent!",
                "You should check if the context already has a entitiesManipulatorEntity before setting it or use context.ReplaceEntitiesManipulator().");
        }
        var entity = CreateEntity();
        entity.AddEntitiesManipulator(newValue);
        return entity;
    }

    public void ReplaceEntitiesManipulator(Code.IEntitiesManipulatorService newValue) {
        var entity = entitiesManipulatorEntity;
        if (entity == null) {
            entity = SetEntitiesManipulator(newValue);
        } else {
            entity.ReplaceEntitiesManipulator(newValue);
        }
    }

    public void RemoveEntitiesManipulator() {
        entitiesManipulatorEntity.Destroy();
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
public partial class ServicesEntity {

    public Code.EntitiesManipulatorComponent entitiesManipulator { get { return (Code.EntitiesManipulatorComponent)GetComponent(ServicesComponentsLookup.EntitiesManipulator); } }
    public bool hasEntitiesManipulator { get { return HasComponent(ServicesComponentsLookup.EntitiesManipulator); } }

    public void AddEntitiesManipulator(Code.IEntitiesManipulatorService newValue) {
        var index = ServicesComponentsLookup.EntitiesManipulator;
        var component = (Code.EntitiesManipulatorComponent)CreateComponent(index, typeof(Code.EntitiesManipulatorComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEntitiesManipulator(Code.IEntitiesManipulatorService newValue) {
        var index = ServicesComponentsLookup.EntitiesManipulator;
        var component = (Code.EntitiesManipulatorComponent)CreateComponent(index, typeof(Code.EntitiesManipulatorComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEntitiesManipulator() {
        RemoveComponent(ServicesComponentsLookup.EntitiesManipulator);
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
public sealed partial class ServicesMatcher {

    static Entitas.IMatcher<ServicesEntity> _matcherEntitiesManipulator;

    public static Entitas.IMatcher<ServicesEntity> EntitiesManipulator {
        get {
            if (_matcherEntitiesManipulator == null) {
                var matcher = (Entitas.Matcher<ServicesEntity>)Entitas.Matcher<ServicesEntity>.AllOf(ServicesComponentsLookup.EntitiesManipulator);
                matcher.componentNames = ServicesComponentsLookup.componentNames;
                _matcherEntitiesManipulator = matcher;
            }

            return _matcherEntitiesManipulator;
        }
    }
}
