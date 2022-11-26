using UnityEngine;

namespace Nono
{
    public static class ModelFactory
    {
        public static GameObject CreateModel(uint id)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            obj.AddComponent<CharacterController>();
            return obj;
        }
    }
}