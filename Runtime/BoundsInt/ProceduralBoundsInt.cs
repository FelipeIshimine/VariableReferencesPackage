using UnityEngine;

namespace VariableReferences
{
	[System.Serializable]
	public class ProceduralBoundsInt : ProceduralVariable<BoundsInt, BoundsIntReference, BoundsIntDecorator>
	{
		public ProceduralBoundsInt()
		{
			baseValue = new ConstantBoundsIntReference();
		}
	}
}
