using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ProceduralFloatReference : FloatReference
	{
		[SerializeField] private ProceduralFloat proceduralVariable;
		protected override float GetValue() => proceduralVariable.Get();
		protected override void SetValue(float newValue) => proceduralVariable.Set(newValue);
	}
}