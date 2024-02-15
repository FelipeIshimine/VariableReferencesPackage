using System.Collections.Generic;
using UnityEngine;

namespace VariableReferences
{
	/// <summary>
	/// Get Behaviour: Starts form the BaseValue, then applies each decorator in order. using the las result as the next input.
	/// Returns the end result
	/// Set Behaviour: Applies the value to the BaseValue
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="TB"></typeparam>
	/// <typeparam name="TC"></typeparam>
	public abstract class ProceduralVariable<T,TB, TC>  where TB : VariableReference<T> where TC: ProceduralDecorator<T>
	{
		[field:SerializeReference] protected TB BaseValue { get; set; }
		[SerializeReference] private List<TC> decorators = new List<TC>();

		public T Get()
		{
			T value = BaseValue.Value;
			foreach (var decorator in decorators)
			{
				value = decorator.Process(value);
			}
			return value;
		}

		public void Set(T value) => BaseValue.Value = value;
	}
}