using System;
using System.Collections.Generic;

namespace Code
{
	public class TypeDictionary<TBase> : Dictionary<Type, TBase>
	{
		public void Add(TBase value)
		{
			var type = value.GetType();

			if (ContainsKey(type))
				throw new Exception($"Dictionary already have value of the type {type.Name}!");

			this[type] = value;
		}

		public T Get<T>() where T : TBase => (T)this[typeof(T)];

		public void Set<T>(T value) where T : TBase => this[typeof(T)] = value;

		public static TypeDictionary<TBase> FromIEnumerable(IEnumerable<TBase> source)
		{
			var dictionary = new TypeDictionary<TBase>();
			foreach (var item in source)
				dictionary.Add(item);

			return dictionary;
		}
	}
}