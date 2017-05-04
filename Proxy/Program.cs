using System;
using System.Threading;

/*
СТРУКТУРНИЙ ПАТЕРН
ПРОКСІ
Призначення:
Надає замінника або утримувача для іншого об’єкту, щоб керувати ним.
Приклад:
Проксі класи в WCF
*/
namespace Proxy
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            ProxyDBConnect proxy = new ProxyDBConnect();
            Console.WriteLine("ProxyDBContext IS CREATED.");

            //not close DBConnect, becase DBConnect not created
            proxy.Close();
            
            Console.WriteLine(proxy.GetData());
            proxy.Close();
        }
    }

    //Інтерфейс для взаємодії з БД
    public interface IDBConnect
    {
        string GetData();
        void Close();
    }

    //Клас, який реалізує інтерфейс IDBConnect
    public class DBConnect : IDBConnect
    {
        public DBConnect()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Connection completed.");
        }

        public string GetData()
        {
            return "Data from database.";
        }

        public void Close()
        {
            Console.WriteLine("Close connect.");
        }
    }

    //Проксі (Structural pattern Proxy)
    //Відкладена (лінива) ініціалізація (Lazy initialization)
    public class ProxyDBConnect : IDBConnect
    {
        private DBConnect client;

        public string GetData()
        {
            if (client == null)
            {
                client = new DBConnect();
            }
            return client.GetData();
        }

        public void Close()
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }
    }
}