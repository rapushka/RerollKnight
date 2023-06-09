namespace Code.CodeGeneration.Plugins.Behaviours.RegisterSystem
{
	public class RegisterSystemTemplate : TemplateBase
	{
		public RegisterSystemTemplate(string context) : base(context) { }
		protected override string DirectoryName => Constants.RegistrationSystem.DirectoryName;

		protected override string ClassName => "RegisterEntityBehavioursSystem";

		public override string FileContent => $@"
using Entitas;
	
public sealed class {ClassName} : IInitializeSystem
{{
	private readonly Contexts _contexts;

	public {ClassName}(Contexts contexts)
	{{
		_contexts = contexts;
	}}

	public void Initialize()
	{{
		foreach (var behaviour in _contexts.services.BehavioursService.AllBehaviours)
		{{
			behaviour.Register();
		}}
	}}
}}";
	}
}