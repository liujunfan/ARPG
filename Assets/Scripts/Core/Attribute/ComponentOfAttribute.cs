using System;

namespace Nono
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentOfAttribute : Attribute
    {
        public Type Type;

        public ComponentOfAttribute(Type type = null)
        {
            Type = type;
        }
    }
}