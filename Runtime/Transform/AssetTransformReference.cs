using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class AssetTransformReference : TransformReference
	{
		[SerializeField] private TransformAsset target;
		protected override Transform GetValue() => target.Value;
		protected override void SetValue(Transform newValue) => target.Value = newValue;
	}
}
