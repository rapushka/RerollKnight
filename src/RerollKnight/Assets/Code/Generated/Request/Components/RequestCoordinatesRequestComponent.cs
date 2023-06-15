//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class RequestEntity {

    public Code.CoordinatesRequestComponent coordinatesRequest { get { return (Code.CoordinatesRequestComponent)GetComponent(RequestComponentsLookup.CoordinatesRequest); } }
    public bool hasCoordinatesRequest { get { return HasComponent(RequestComponentsLookup.CoordinatesRequest); } }

    public void AddCoordinatesRequest(Code.Coordinates newValue) {
        var index = RequestComponentsLookup.CoordinatesRequest;
        var component = (Code.CoordinatesRequestComponent)CreateComponent(index, typeof(Code.CoordinatesRequestComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCoordinatesRequest(Code.Coordinates newValue) {
        var index = RequestComponentsLookup.CoordinatesRequest;
        var component = (Code.CoordinatesRequestComponent)CreateComponent(index, typeof(Code.CoordinatesRequestComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCoordinatesRequest() {
        RemoveComponent(RequestComponentsLookup.CoordinatesRequest);
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
public sealed partial class RequestMatcher {

    static Entitas.IMatcher<RequestEntity> _matcherCoordinatesRequest;

    public static Entitas.IMatcher<RequestEntity> CoordinatesRequest {
        get {
            if (_matcherCoordinatesRequest == null) {
                var matcher = (Entitas.Matcher<RequestEntity>)Entitas.Matcher<RequestEntity>.AllOf(RequestComponentsLookup.CoordinatesRequest);
                matcher.componentNames = RequestComponentsLookup.componentNames;
                _matcherCoordinatesRequest = matcher;
            }

            return _matcherCoordinatesRequest;
        }
    }
}
