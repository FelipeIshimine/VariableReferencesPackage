using UnityEditor;
using VariableReferences;

[CustomPropertyDrawer(typeof(VariableReference<>), true)]
public class VariableReferenceDrawer : SerializeReferenceDropdownDrawer
{
}