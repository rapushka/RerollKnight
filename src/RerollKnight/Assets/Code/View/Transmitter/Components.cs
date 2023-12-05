using System.Collections.Generic;
using Entitas.Generic;

namespace Code.Component
{
	[GameScope] public sealed class Transmitter : ValueComponent<List<ITransmitter>> { }
}