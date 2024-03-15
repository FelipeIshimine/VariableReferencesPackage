using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ProceduralTransformReference : TransformReference
	{
		[SerializeField] private ProceduralTransform proceduralVariable;
		protected override Transform GetValue() => proceduralVariable.Get();
		protected override void SetValue(Transform newValue) => proceduralVariable.Set(newValue);
	}
}