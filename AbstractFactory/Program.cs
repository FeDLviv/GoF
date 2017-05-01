using System;

/*
ПОРОДЖУЮЧИЙ ПАТЕРН
АБСТРАКТНА ФАБРИКА 
Призначення:
Надати інтерфейс для створення сімейств споріднених або залежних об’єктів 
без зазначення їхніх конкретних класів.
Приклад:
DbProviderFactory
*/
namespace AbstractFactory
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractFactory factoryUK = new UkraineFactory();
            IBeer beerUK = factoryUK.CreatBeer();
            IVodka vodkaUK = factoryUK.CreatVodka();
            beerUK.PrintInformation();
            vodkaUK.PrintInfo();

            IAbstractFactory factoryRUS = new RussianFactory();
            IBeer beerRUS = factoryRUS.CreatBeer();
            IVodka vodkaRUS = factoryRUS.CreatVodka();
            beerRUS.PrintInformation();
            vodkaRUS.PrintInfo();
        }
    }

    //Абстрактна Фабрика (Creational pattern Abstract Factory)
    public interface IAbstractFactory
    {
        IBeer CreatBeer();
        IVodka CreatVodka();
    }

    //Інтерфейс для пива
    public interface IBeer
    {
        void PrintInformation();
    }

    //Інтерфейс для горілки
    public interface IVodka
    {
        void PrintInfo();
    }

    //Українська фабрика
    public class UkraineFactory : IAbstractFactory
    {
        public IBeer CreatBeer()
        {
            return new Lvivske();
        }

        public IVodka CreatVodka()
        {
            return new Pervak();
        }
    }

    //Російська фабрика
    public class RussianFactory : IAbstractFactory
    {
        public IBeer CreatBeer()
        {
            return new Zhigulevskoe();
        }

        public IVodka CreatVodka()
        {
            return new Stolichna();
        }
    }

    //Львівське пиво
    public class Lvivske : IBeer
    {
        public void PrintInformation()
        {
            Console.WriteLine("This is ukrainian beer - Lvivske.");
        }
    }

    //Жигулівське пиво
    public class Zhigulevskoe : IBeer
    {
        public void PrintInformation()
        {
            Console.WriteLine("This is russian beer - Zhigulevskoe.");
        }
    }

    //Горілка Первак
    public class Pervak : IVodka
    {
        public void PrintInfo()
        {
            Console.WriteLine("This is ukrainian vodka - Pervak.");
        }
    }

    //Горілка Столична
    public class Stolichna : IVodka
    {
        public void PrintInfo()
        {
            Console.WriteLine("This is russian vodka - Stolichna.");
        }
    }
}