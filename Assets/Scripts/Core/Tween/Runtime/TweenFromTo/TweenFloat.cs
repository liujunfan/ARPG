using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UI;

#endif

namespace Nono
{
    public abstract class TweenFloat<TTarget> : TweenFromTo<float, TTarget> where TTarget : Object
    {
        public override void Interpolate(float factor)
        {
            current = (to - from) * factor + from;
        }

#if UNITY_EDITOR

        protected override void OnPropertiesGUI(TweenPlayer player, SerializedProperty property)
        {
            base.OnPropertiesGUI(player, property);
            var (fromProp, toProp) = GetFromToProperties(property);
            FromToFieldLayout("Value", fromProp, toProp);
        }

#endif

    } // class TweenFloat<TTarget>

} 