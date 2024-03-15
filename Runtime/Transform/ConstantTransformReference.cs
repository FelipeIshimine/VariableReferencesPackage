using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ConstantTransformReference : TransformReference 
	{
		[SerializeField] private Transform target;
		protected override Transform GetValue() => target;
		protected override void SetValue(Transform newValue) => target = newValue;
	}
}
