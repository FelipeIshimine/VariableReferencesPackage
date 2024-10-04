using Cartographer.Utilities.Attributes;
using UnityEngine;

namespace VariableReferences
{
	public class ScriptableVariable<T> : ScriptableObject, IVariableReference<T>
	{
		[field: SerializeField] private T defaultValue;
		[field: SerializeField] private T liveValue;
		
		public T Value
		{
			get => Application.isPlaying ? liveValue : defaultValue;
			set
			{
				if (Application.isPlaying)
					liveValue = value;
				else
					defaultValue = value;
			}
		}

		private void OnEnable()
		{
			liveValue = defaultValue;
		}

		private void OnDisable()
		{
			liveValue = default;
		}
	}
	
	
	public class ScriptableVariableReference<T> : ScriptableObject, IVariableReference<T>
	{
		[field: SerializeReference, TypeDropdown] private T defaultValue;
		[field: SerializeReference] private T liveValue;
		
		public T Value
		{
			get => Application.isPlaying ? liveValue : defaultValue;
			set
			{
				if (Application.isPlaying)
					liveValue = value;
				else
					defaultValue = value;
			}
		}

		private void OnEnable()
		{
			liveValue = defaultValue;
		}

		private void OnDisable()
		{
			liveValue = default;
		}
	}
}