using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Toolbars;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using VariableReferences.Attributes;

namespace VariableReferences.Editor
{
	public class SerializeReferenceDropdownDrawer : PropertyDrawer 
	{
		public override VisualElement CreatePropertyGUI(SerializedProperty property)
		{
			if (SerializationUtility.HasManagedReferencesWithMissingTypes(property.serializedObject.targetObject))
			{
				SerializationUtility.ClearAllManagedReferencesWithMissingTypes(property.serializedObject.targetObject);
			}
			
			var container = new VisualElement()
			{
				style = { flexDirection = FlexDirection.Row}
			};
			CreatePropertyField(container,property);
			return container;
		}

		private void CreatePropertyField(VisualElement propertyContainer, SerializedProperty property)
		{
			PropertyField propertyField;

			/*
			Label label = new Label(property.displayName);
			label.AddToClassList("unity-base-field__label"); 
			label.AddToClassList("unity-base-text-field__label"); 
			label.AddToClassList("unity-base-field__label"); 
			label.AddToClassList("unity-float-field__label"); 
			label.AddToClassList("unity-base-field__label--with-dragger"); 
			label.AddToClassList("unity-property-field__label"); 
			*/
			
			/*propertyContainer.Add(label);
			propertyContainer.AddToClassList("unity-base-field");
			propertyContainer.AddToClassList("unity-base-text-field");
			propertyContainer.AddToClassList("unity-float-field");
			propertyContainer.AddToClassList("unity-base-field__aligned");
			propertyContainer.AddToClassList("unity-base-field__inspector-field");
			*/

			var prop = property.Copy();
			
			if (prop.NextVisible(true))
			{
				propertyField = new PropertyField(prop, property.displayName)
				{
					style = { flexGrow = 1}
				};
			}
			else
			{
				propertyField = new PropertyField(property, property.displayName)
				{
					style = { flexGrow = 1}
				};
			}

			propertyField.name = "Field";
			
			EditorToolbarDropdown typeBtn = null;
			typeBtn = new EditorToolbarDropdown(GetButtonLabel(property),() => TypeDropdownClicked(typeBtn, property))
			{
				style =
				{
					height = 14,
					//position = Position.Absolute,
					left = new StyleLength(StyleKeyword.Auto),
					right = 0
				}
			};
			propertyContainer.Add(propertyField);
			propertyContainer.Add(typeBtn);
		}


		private string GetButtonLabel(SerializedProperty p)
		{
			return p.managedReferenceValue != null
				? p.managedReferenceValue.GetType().Name.Replace(fieldInfo.FieldType.Name, string.Empty)
				: "-Select Type-";
		}

		private async void TypeDropdownClicked(EditorToolbarDropdown typeBtn, SerializedProperty property)
		{
			Type targetType;
			if (fieldInfo.FieldType.IsConstructedGenericType)
			{
				targetType=fieldInfo.FieldType.GetGenericArguments()[0];
			}
			else
			{
				targetType=fieldInfo.FieldType;
			}
			
			//Debug.LogWarning($"CLICK {typeof(prop.managedReferenceValue)}");

			var types = new List<Type>();
			foreach (var type in TypeCache.GetTypesDerivedFrom(targetType))
			{
				if (!type.IsAbstract)
				{
					types.Add(type);
				}
			}

			var baseTypeName = targetType.Name;
			var typesArray = types.ToArray();

			string[] labels = new string [typesArray.Length];

			for (int i = 0; i < labels.Length; i++)
			{
				var type = typesArray[i];

				string path = null;

				foreach (object customAttribute in type.GetCustomAttributes(typeof(DropdownPathAttribute), false))
				{
					if (customAttribute is DropdownPathAttribute dropdownPathAttribute)
					{
						path = dropdownPathAttribute.Path;
					}
				}

				if (string.IsNullOrEmpty(path))
				{
					labels[i] = type.Name.Replace(baseTypeName, string.Empty);
				}
				else
				{
					labels[i] = path;
				}
			}
			
			GenericAdvanceDropdown dropdown =
				new GenericAdvanceDropdown(
					labels,
					index=> OnTypeSelected(index,typeBtn, property, typesArray));

			dropdown.Show(typeBtn.worldBound);
		}

		void OnTypeSelected(int index, EditorToolbarDropdown typeBtn, SerializedProperty prop, Type[] typesArray)
		{
			prop.managedReferenceValue = Activator.CreateInstance(typesArray[index]);
			prop.serializedObject.ApplyModifiedProperties();
			typeBtn.text = GetButtonLabel(prop);
			
			typeBtn.parent.Q<PropertyField>().Bind(prop.serializedObject);
		}
	}
}