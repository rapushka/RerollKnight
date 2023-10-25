using System;
using System.Collections.Generic;

namespace Code
{
	public class TypeDictionary<TBase> : Dictionary<Type, TBase>
	{
		public void Add(TBase value) => this[value.GetType()] = value;

		public T Get<T>() where T : TBase => (T)this[typeof(T)];

		public void Set<T>(T value) where T : TBase => this[typeof(T)] = value;
	}
}