using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ProceduralTransform : ProceduralVariable<Transform, TransformReference, TransformDecorator>
	{
		public ProceduralTransform()
		{
			baseValue = new ConstantTransformReference();
		}
	}
}
