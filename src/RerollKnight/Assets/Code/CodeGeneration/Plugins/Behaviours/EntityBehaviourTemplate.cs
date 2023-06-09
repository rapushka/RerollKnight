using static Code.CodeGeneration.Plugins.Behaviours.Constants;

namespace Code.CodeGeneration.Plugins.Behaviours
{
	public class EntityBehaviourTemplate : TemplateBase
	{
		public EntityBehaviourTemplate(string context) : base(context) { }

		protected override string DirectoryName => EntityBehaviour.DirectoryName;

		protected override string ClassName => Context + EntityBehaviour.GeneratorClassPostfix;

		public override string FileContent => $@"
using UnityEngine;

public class {Context}{EntityBehaviour.GeneratorClassPostfix} : {EntityBehaviour.BaseClassName}
{{
	[SerializeField] private {Context}{ComponentBehaviour.BaseClassPostfix}[] {ComponentsCollection};
	private {Context}Entity _entity;

	public {Context}Entity Entity => _entity;

#if DEBUG
	private void Awake()
	{{
		var actual{ComponentBehaviour.GeneratorClassPostfix}s = GetComponents<{Context}{ComponentBehaviour.BaseClassPostfix}>();
		if (actual{ComponentBehaviour.GeneratorClassPostfix}s.Length != {ComponentsCollection}.Length)
		{{
			Debug.LogError(""Not all component are added to the entity!"");
		}}
	}}
#endif

	public override void Register()
	{{
		_entity = Contexts.sharedInstance.{Context.ToCamelCase()}.CreateEntity();
		foreach (var component in {ComponentsCollection})
		{{
			component.{MethodName.AddToEntity}(ref _entity);
		}}
	}}

	public override void CollectComponentsFromGameObject()
	{{
		{ComponentsCollection} = GetComponents<{Context}{ComponentBehaviour.BaseClassPostfix}>();
	}}
}}
";

		private static string ComponentsCollection => $"_{ComponentBehaviour.GeneratorClassPostfix.ToCamelCase()}s";
	}
}