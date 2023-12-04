using System.Collections.Generic;
using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class ViewOf : ValueComponent<List<GameComponentID>> { }
}