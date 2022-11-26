using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Nono
{
    
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class BaseComponentAttribute : Attribute
    {
        public readonly bool single;

        public BaseComponentAttribute(bool single = false)
        {
            this.single = single;
        }
    }
}