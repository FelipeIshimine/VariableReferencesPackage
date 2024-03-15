using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ProceduralAnimationCurveReference : AnimationCurveReference
	{
		[SerializeField] private ProceduralAnimationCurve proceduralVariable;
		protected override AnimationCurve GetValue() => proceduralVariable.Get();
		protected override void SetValue(AnimationCurve newValue) => proceduralVariable.Set(newValue);
	}
}