//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class GameComponentsLookup {

    public const int InputReceiver = 0;
    public const int Player = 1;
    public const int Position = 2;
    public const int Rigidbody = 3;
    public const int ViewController = 4;
    public const int ViewToLoad = 5;
    public const int Weighty = 6;
    public const int PositionListener = 7;

    public const int TotalComponents = 8;

    public static readonly string[] componentNames = {
        "InputReceiver",
        "Player",
        "Position",
        "Rigidbody",
        "ViewController",
        "ViewToLoad",
        "Weighty",
        "PositionListener"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Ecs.Components.InputReceiverComponent),
        typeof(Code.Ecs.Components.PlayerComponent),
        typeof(Code.Ecs.Components.PositionComponent),
        typeof(Code.Ecs.Components.RigidbodyComponent),
        typeof(Code.Ecs.Components.ViewControllerComponent),
        typeof(Code.Ecs.Components.ViewToLoadComponent),
        typeof(Code.Ecs.Components.WeightyComponent),
        typeof(PositionListenerComponent)
    };
}
