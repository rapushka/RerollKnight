//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class RequestComponentsLookup {

    public const int Click = 0;
    public const int ClickedEntity = 1;
    public const int CoordinatesRequest = 2;
    public const int Drag = 3;
    public const int Drop = 4;
    public const int SpawnPlayer = 5;

    public const int TotalComponents = 6;

    public static readonly string[] componentNames = {
        "Click",
        "ClickedEntity",
        "CoordinatesRequest",
        "Drag",
        "Drop",
        "SpawnPlayer"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.ClickComponent),
        typeof(Code.ClickedEntityComponent),
        typeof(Code.CoordinatesRequestComponent),
        typeof(Code.DragComponent),
        typeof(Code.DropComponent),
        typeof(Code.SpawnPlayerComponent)
    };
}
