using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ComponentTransformReference : TransformReference 
	{
		[SerializeField] private TransformComponent target;
    
		protected override Transform GetValue() => target.Value;
		protected override void SetValue(Transform newValue) => target.Value = newValue;
        
	}
}
