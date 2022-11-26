using System.Collections.Generic;
using UnityEngine;

namespace Nono
{
    public class GameObjectPool<T>
    {
        private Dictionary<T, List<GameObject>> pool = new Dictionary<T, List<GameObject>>();

        public int Count => pool.Count;

        public bool ContainsKey(T key) => pool.ContainsKey(key);

        public void Add(T key, GameObject gameObject)
        {
            if (ContainsKey(key))
                return;
            List<GameObject> list = new List<GameObject>();
            gameObject.SetActive(false);
            list.Add(gameObject);
            pool.Add(key, list);
        }

        public GameObject Get(T key)
        {
            if (!ContainsKey(key))
            {
                Debug.LogError("Not find Key" + key);
                return null;
            }

            List<GameObject> list = pool[key];
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].activeSelf == false)
                {
                    return list[i];
                }
            }

            GameObject newGameObject = GameObject.Instantiate(list[0]) as GameObject;
            list.Add(newGameObject);
            return newGameObject;
        }

        public void ClearAll()
        {
            foreach (List<GameObject> list in pool.Values)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Object.DestroyImmediate(list[i]);
                }
                list.Clear();
            }
            pool.Clear();
        }

        public void Clear(T key)
        {
            if (!ContainsKey(key))
            {
                return;
            }

            List<GameObject> list = pool[key];
            for (int i = 0; i < list.Count; i++)
            {
                Object.DestroyImmediate(list[i]);
            }
            list.Clear();
            pool.Remove(key);
        }
    }
}