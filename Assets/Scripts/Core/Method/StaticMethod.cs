using System.Reflection;

namespace Nono
{
    public class StaticMethod
    {
        private readonly MethodInfo methodInfo;

        private readonly object[] param;

        public StaticMethod(Assembly assembly, string typeName, string methodName)
        {
            methodInfo = assembly.GetType(typeName).GetMethod(methodName);
            param = new object[methodInfo.GetParameters().Length];
        }

        public void Run()
        {
            methodInfo.Invoke(null, param);
        }

        public void Run(object a)
        {
            param[0] = a;
            methodInfo.Invoke(null, param);
        }

        public void Run(object a, object b)
        {
            param[0] = a;
            param[1] = b;
            methodInfo.Invoke(null, param);
        }

        public void Run(object a, object b, object c)
        {
            param[0] = a;
            param[1] = b;
            param[2] = c;
            methodInfo.Invoke(null, param);
        }
    }
}