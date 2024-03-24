using System.Collections.Generic;
using Entitas.Generic;

namespace Code.Component
{
    [GameScope] public sealed class Path : ValueComponent<List<Code.Coordinates>> { }
    
    // ReSharper disable once IdentifierTypo
    [GameScope] public sealed class DontTranslateCoordinates : FlagComponent { }

}