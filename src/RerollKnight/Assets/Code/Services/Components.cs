using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code
{
	public class Components
	{
		[Services] [Unique] public sealed class ResourcesComponent : IComponent { public IResourcesService Value; }

		[Services] [Unique] public sealed class AssetsComponent : IComponent { public IAssetsService Value; }
	}
}