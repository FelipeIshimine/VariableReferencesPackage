using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ProceduralBounds : ProceduralVariable<Bounds, BoundsReference, BoundsDecorator>
	{
		public ProceduralBounds()
		{
			baseValue = new ConstantBoundsReference();
		}
	}
}
