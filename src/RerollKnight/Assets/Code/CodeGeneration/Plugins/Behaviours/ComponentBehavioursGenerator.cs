using System.Linq;
using DesperateDevs.CodeGeneration;

namespace Code.CodeGeneration.Plugins
{
	public class ComponentBehavioursGenerator : ICodeGenerator
	{
		public string name         => "Behaviour";
		public int    priority     => 0;
		public bool   runInDryMode => true;

		public CodeGenFile[] Generate(CodeGeneratorData[] data)
			=> data
			   .OfType<BehaviourData>()
			   .Select(DataToSystem)
			   .ToArray();

		private CodeGenFile DataToSystem(BehaviourData data)
		{
			var template = new ComponentBehaviourTemplate(data);

			return new CodeGenFile(template.FileName, template.FileContent, GeneratorName);
		}

		private string GeneratorName => GetType().FullName;
	}
}