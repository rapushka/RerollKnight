using UnityEngine;

public abstract class EntityBehaviourBase : MonoBehaviour
{
	public abstract void Register();
	public abstract void CollectComponentsFromGameObject();
}