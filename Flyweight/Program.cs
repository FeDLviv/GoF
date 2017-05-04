using System;
using System.Collections.Generic;
using System.Drawing;

/*
СТРУКТУРНИЙ ПАТЕРН
ЛЕГКОВАГОВИК (Structural pattern Flyweight)
Призначення:
Ефективна підтримка великої кількості об’єктів шляхом виділення спільної інформації.
*/
namespace Flyweight
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> list = new List<Car>();
            for (int i = 0; i < 500; i++)
            {
                list.Add(new PassengerCar("Audi", 220));
                list.Add(new FreightCar("Mersedes", 150));
            }
            Console.Write("Press \"ENTER\" to exit.");
            Console.Read();
        }
    }

    //Абстрактний клас, для реалізації автомобіля
    public abstract class Car
    {
        public string Model { get; protected set; }
        public int MaxSpeed { get; protected set; }
        public Image Picture { get; protected set; }
    }

    //Клас, являє собою легковий автомобіль
    public class PassengerCar : Car
    {
        public PassengerCar(string model, int maxSpeed)
        {
            Model = model;
            MaxSpeed = maxSpeed;
            Picture = CarPictureFactory.CreatePassengerCarImage();
        }
    }

    //Клас, являє собою вантажний автомобіль
    public class FreightCar : Car
    {
        public FreightCar(string model, int maxSpeed)
        {
            Model = model;
            MaxSpeed = maxSpeed;
            Picture = CarPictureFactory.CreateFreightCarImage();
        }
    }

    //Фабрика легковаговиків
    public class CarPictureFactory
    {
        private static Dictionary<Type, Image> dictionary = new Dictionary<Type, Image>();

        public static Image CreatePassengerCarImage()
        {
            if (!dictionary.ContainsKey(typeof(PassengerCar)))
            {
                dictionary.Add(typeof(PassengerCar), Image.FromFile(@"D:\PassengerCar.jpg"));
            }
            return dictionary[typeof(PassengerCar)];
        }

        public static Image CreateFreightCarImage()
        {
            if (!dictionary.ContainsKey(typeof(FreightCar)))
            {
                dictionary.Add(typeof(FreightCar), Image.FromFile(@"D:\FreightCar.jpg"));
            }
            return dictionary[typeof(FreightCar)];
        }
    }
}