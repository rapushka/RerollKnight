//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity pickedChipEntity { get { return GetGroup(GameMatcher.PickedChip).GetSingleEntity(); } }

    public bool isPickedChip {
        get { return pickedChipEntity != null; }
        set {
            var entity = pickedChipEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isPickedChip = true;
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

    static readonly Code.PickedChipComponent pickedChipComponent = new Code.PickedChipComponent();

    public bool isPickedChip {
        get { return HasComponent(GameComponentsLookup.PickedChip); }
        set {
            if (value != isPickedChip) {
                var index = GameComponentsLookup.PickedChip;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : pickedChipComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherPickedChip;

    public static Entitas.IMatcher<GameEntity> PickedChip {
        get {
            if (_matcherPickedChip == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PickedChip);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPickedChip = matcher;
            }

            return _matcherPickedChip;
        }
    }
}
