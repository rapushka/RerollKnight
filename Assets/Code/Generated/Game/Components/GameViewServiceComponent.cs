//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity viewServiceEntity { get { return GetGroup(GameMatcher.ViewService).GetSingleEntity(); } }
    public Code.Ecs.Components.ViewService viewService { get { return viewServiceEntity.viewService; } }
    public bool hasViewService { get { return viewServiceEntity != null; } }

    public GameEntity SetViewService(Code.Unity.Services.Interfaces.IViewsService newValue) {
        if (hasViewService) {
            throw new Entitas.EntitasException("Could not set ViewService!\n" + this + " already has an entity with Code.Ecs.Components.ViewService!",
                "You should check if the context already has a viewServiceEntity before setting it or use context.ReplaceViewService().");
        }
        var entity = CreateEntity();
        entity.AddViewService(newValue);
        return entity;
    }

    public void ReplaceViewService(Code.Unity.Services.Interfaces.IViewsService newValue) {
        var entity = viewServiceEntity;
        if (entity == null) {
            entity = SetViewService(newValue);
        } else {
            entity.ReplaceViewService(newValue);
        }
    }

    public void RemoveViewService() {
        viewServiceEntity.Destroy();
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

    public Code.Ecs.Components.ViewService viewService { get { return (Code.Ecs.Components.ViewService)GetComponent(GameComponentsLookup.ViewService); } }
    public bool hasViewService { get { return HasComponent(GameComponentsLookup.ViewService); } }

    public void AddViewService(Code.Unity.Services.Interfaces.IViewsService newValue) {
        var index = GameComponentsLookup.ViewService;
        var component = (Code.Ecs.Components.ViewService)CreateComponent(index, typeof(Code.Ecs.Components.ViewService));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceViewService(Code.Unity.Services.Interfaces.IViewsService newValue) {
        var index = GameComponentsLookup.ViewService;
        var component = (Code.Ecs.Components.ViewService)CreateComponent(index, typeof(Code.Ecs.Components.ViewService));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveViewService() {
        RemoveComponent(GameComponentsLookup.ViewService);
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

    static Entitas.IMatcher<GameEntity> _matcherViewService;

    public static Entitas.IMatcher<GameEntity> ViewService {
        get {
            if (_matcherViewService == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ViewService);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherViewService = matcher;
            }

            return _matcherViewService;
        }
    }
}
