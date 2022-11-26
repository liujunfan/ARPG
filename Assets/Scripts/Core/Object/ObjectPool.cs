using System;
using System.Collections.Generic;

namespace Nono
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        private readonly Dictionary<Type, Queue<object>> pool = new Dictionary<Type, Queue<object>>();

        public T Fetch<T>() where T : class
        {
            return Fetch(typeof(T)) as T;
        }

        public object Fetch(Type type)
        {
            if (!pool.TryGetValue(type, out Queue<object> queue))
            {
                return Activator.CreateInstance(type);
            }

            if (queue.Count == 0)
            {
                return Activator.CreateInstance(type);
            }

            return queue.Dequeue();
        }

        public void Recycle(object obj)
        {
            Type type = obj.GetType();
            if (!pool.TryGetValue(type, out Queue<object> queue))
            {
                queue = new Queue<object>();
                pool.Add(type, queue);
            }
            queue.Enqueue(obj);
        }
    }
}