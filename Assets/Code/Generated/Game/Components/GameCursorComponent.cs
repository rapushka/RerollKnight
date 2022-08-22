//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity cursorEntity { get { return GetGroup(GameMatcher.Cursor).GetSingleEntity(); } }

    public bool isCursor {
        get { return cursorEntity != null; }
        set {
            var entity = cursorEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isCursor = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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

    static readonly Code.Ecs.Components.CursorComponent cursorComponent = new Code.Ecs.Components.CursorComponent();

    public bool isCursor {
        get { return HasComponent(GameComponentsLookup.Cursor); }
        set {
            if (value != isCursor) {
                var index = GameComponentsLookup.Cursor;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : cursorComponent;

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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCursor;

    public static Entitas.IMatcher<GameEntity> Cursor {
        get {
            if (_matcherCursor == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Cursor);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCursor = matcher;
            }

            return _matcherCursor;
        }
    }
}
