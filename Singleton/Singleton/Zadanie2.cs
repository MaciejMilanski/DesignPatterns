using System;

namespace Zadanie2
{
    public abstract class MySingleton1<T> where T : class, new()
    {
        private static T _instance;

        public static T GetInstance()
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
    public class MySingleton1A : MySingleton1<MySingleton1A>
    { }
    public class MySingleton1B : MySingleton1<MySingleton1B>
    { }


    public class MySingleton2
    {
        private static MySingleton2 _instance;

        public virtual MySingleton2 GetInstance()
        {
            if (_instance == null)
                _instance = new MySingleton2();
            return _instance;
        }
    }
    public class MySingleton2A : MySingleton2
    {
        private static MySingleton2A _instance;
        public static MySingleton2A GetInstance()
        {
            if (_instance == null)
                _instance = new MySingleton2A();
            return _instance;
        }
    }
}
