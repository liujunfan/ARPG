using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

#endif

namespace Nono
{
    /// <summary>
    /// Show the int value as layer
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public sealed class LayerAttribute : PropertyAttribute
    {
#if UNITY_EDITOR

        [CustomPropertyDrawer(typeof(LayerAttribute))]
        class LayerDrawer : BasePropertyDrawer<LayerAttribute>
        {
            public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
            {
                if (property.propertyType == SerializedPropertyType.Integer)
                {
                    property.intValue = EditorGUI.LayerField(position, label, property.intValue);
                }
                else EditorGUI.LabelField(position, label, "Use LayerAttribute with int.");
            }

        } // class LayerDrawer

#endif // UNITY_EDITOR

    } // LayerAttribute

} 