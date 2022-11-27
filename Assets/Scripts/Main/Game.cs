using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Nino;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;


namespace Nono
{
    public static class Game
    {
        public static void Main()
        {
            MyStruct test = new MyStruct()
            {
                a = 1,
                b = new List<int>() { 4, 5, 6 },
            };
                
            Stopwatch sw = new Stopwatch();
            Debug.Log("哈哈哈，开始Demo");
            sw.Reset();
            sw.Start();
            var ninoBuffer = Nino.Serialization.Serializer.Serialize(test);
            sw.Stop();
            var m1 = sw.ElapsedTicks;
            sw.Reset();
            sw.Start();
            //as everything are same, buffer can be shared across two classes
            var dd2 = Nino.Serialization.Deserializer.Deserialize<MyStruct>(ninoBuffer);
            sw.Stop();
            var m2 = sw.ElapsedTicks;
            Debug.Log($"Deserialized BuildTestDataCodeGen in {((float)m1 / Stopwatch.Frequency) * 1000} ms: \n{ninoBuffer}\n" +
                        $"Deserialized BuildTestDataNoCodeGen in {((float)m2 / Stopwatch.Frequency) * 1000} ms:\n{dd2}");
            //Scene scene = EntitySceneFactory.CreateScene(1, SceneType.Client, "Scene", null);
            //NumericComponent numericComponent = scene.AddComponent<NumericComponent>();
        }
    }
}
