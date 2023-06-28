//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CoordinatesUnderFieldListenerComponent coordinatesUnderFieldListener { get { return (CoordinatesUnderFieldListenerComponent)GetComponent(GameComponentsLookup.CoordinatesUnderFieldListener); } }
    public bool hasCoordinatesUnderFieldListener { get { return HasComponent(GameComponentsLookup.CoordinatesUnderFieldListener); } }

    public void AddCoordinatesUnderFieldListener(System.Collections.Generic.List<ICoordinatesUnderFieldListener> newValue) {
        var index = GameComponentsLookup.CoordinatesUnderFieldListener;
        var component = (CoordinatesUnderFieldListenerComponent)CreateComponent(index, typeof(CoordinatesUnderFieldListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCoordinatesUnderFieldListener(System.Collections.Generic.List<ICoordinatesUnderFieldListener> newValue) {
        var index = GameComponentsLookup.CoordinatesUnderFieldListener;
        var component = (CoordinatesUnderFieldListenerComponent)CreateComponent(index, typeof(CoordinatesUnderFieldListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCoordinatesUnderFieldListener() {
        RemoveComponent(GameComponentsLookup.CoordinatesUnderFieldListener);
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

    static Entitas.IMatcher<GameEntity> _matcherCoordinatesUnderFieldListener;

    public static Entitas.IMatcher<GameEntity> CoordinatesUnderFieldListener {
        get {
            if (_matcherCoordinatesUnderFieldListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CoordinatesUnderFieldListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCoordinatesUnderFieldListener = matcher;
            }

            return _matcherCoordinatesUnderFieldListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddCoordinatesUnderFieldListener(ICoordinatesUnderFieldListener value) {
        var listeners = hasCoordinatesUnderFieldListener
            ? coordinatesUnderFieldListener.value
            : new System.Collections.Generic.List<ICoordinatesUnderFieldListener>();
        listeners.Add(value);
        ReplaceCoordinatesUnderFieldListener(listeners);
    }

    public void RemoveCoordinatesUnderFieldListener(ICoordinatesUnderFieldListener value, bool removeComponentWhenEmpty = true) {
        var listeners = coordinatesUnderFieldListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCoordinatesUnderFieldListener();
        } else {
            ReplaceCoordinatesUnderFieldListener(listeners);
        }
    }
}
