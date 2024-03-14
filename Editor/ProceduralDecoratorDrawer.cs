using UnityEditor;
using VariableReferences;

[CustomPropertyDrawer(typeof(ProceduralDecorator<>), true)]
public class ProceduralDecoratorDrawer : SerializeReferenceDropdownDrawer 
{
}