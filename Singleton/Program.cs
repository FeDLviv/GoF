using System;

/*
ПОРОДЖУЮЧИЙ ПАТЕРН
ОДИНАК (Creational pattern Singleton)
Призначення:
Забезпечує існування одного екземпляру класу і надає глобальну точку доступу до нього.
*/
namespace Singleton
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Singleton.GetInstance().GetConnect();

            //2
            ThreadSafeSingleton.GetInstance().GetConnect();
        }
    }

    //Синглтон
    public class Singleton
    {
        private static Singleton singleton;

        private Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if (singleton == null)
            {
                singleton = new Singleton();
            }
            return singleton;
        }

        public void GetConnect()
        {
            Console.WriteLine("Connect to DB.");
        }
    }

    //Потокобезпечний синглтон
    public class ThreadSafeSingleton
    {
        private static readonly object locker = new object();
        private static ThreadSafeSingleton singleton;

        private ThreadSafeSingleton()
        {
        }

        public static ThreadSafeSingleton GetInstance()
        {
            lock (locker)
            {
                if (singleton == null)
                {
                    singleton = new ThreadSafeSingleton();
                }
            }
            return singleton;
        }

        public void GetConnect()
        {
            Console.WriteLine("Connect to DB.");
        }
    }
}