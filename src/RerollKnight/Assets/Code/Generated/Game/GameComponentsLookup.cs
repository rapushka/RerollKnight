//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int Chip = 0;
    public const int Clicked = 1;
    public const int Coordinates = 2;
    public const int Draggable = 3;
    public const int GameState = 4;
    public const int PickedChip = 5;
    public const int Player = 6;
    public const int CoordinatesListener = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "Chip",
        "Clicked",
        "Coordinates",
        "Draggable",
        "GameState",
        "PickedChip",
        "Player",
        "CoordinatesListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.ChipComponent),
        typeof(Code.ClickedComponent),
        typeof(Code.CoordinatesComponent),
        typeof(Code.DraggableComponent),
        typeof(Code.GameStateComponent),
        typeof(Code.PickedChipComponent),
        typeof(Code.PlayerComponent),
        typeof(CoordinatesListenerComponent)
    };
}
