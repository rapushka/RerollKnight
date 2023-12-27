using System.Collections.Generic;
using Entitas.Generic;

namespace Code.Component
{
    [GameScope] public sealed class Path : ValueComponent<List<Code.Coordinates>> { }
}