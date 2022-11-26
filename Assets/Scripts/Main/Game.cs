using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nono
{
    public static class Game
    {
        public static void Main()
        {
            Debug.Log("哈哈哈，开始Demo");
            Scene scene = EntitySceneFactory.CreateScene(1, SceneType.Client, "Scene", null);
            NumericComponent numericComponent = scene.AddComponent<NumericComponent>();
        }
    }
}
