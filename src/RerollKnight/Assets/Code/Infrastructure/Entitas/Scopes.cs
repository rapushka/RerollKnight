using System;
using Entitas.Generic;

namespace Code
{
	public class GameScope : Attribute, IScope { }

	public class InputScope : Attribute, IScope { }

	public class PlayerScope : Attribute, IScope { }

	public class RequestScope : Attribute, IScope { }

	public class ChipsScope : Attribute, IScope { }

	public class InfrastructureScope : Attribute, IScope { }
}