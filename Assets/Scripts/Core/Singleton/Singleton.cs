using System;

namespace Nono
{
    public interface ISingleton
    {
        void Register();
        void Destroy();
    }
    
    public abstract class Singleton<T>: IDisposable, ISingleton where T: Singleton<T>, new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        public void Register()
        {
            if (instance != null)
            {
                throw new Exception($"singleton register twice! {typeof (T).Name}");
            }
            instance = (T)this;
        }

        public void Destroy()
        {
            T t = instance;
            instance = null;
            t.Dispose();
        }

        public void Dispose()
        {
            
        }
    }
}