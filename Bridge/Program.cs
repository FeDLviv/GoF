using System;

/*
СТРУКТУРНИЙ ПАТЕРН
МІСТ (Structural pattern Bridge)
Призначення:
Розділяє абстракцію від її імплементації таким чином, що і те, і інше може змінюватися незалежно.
*/
namespace Bridge
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            PanzerAbstraction panzer = new TigerPanzer();

            panzer.MainGun = new BestGun();
            panzer.Shoot();

            panzer.MainGun = new AircraftGun();
            panzer.Shoot();
        }
    }

    //Абстрактний клас (абстракція) 
    public abstract class PanzerAbstraction
    {
        public GunImplementor MainGun { get; set; }

        public virtual void Shoot()
        {
            MainGun.Info();
        }

        public abstract void Move();
    }

    //Інтерфейс (реалізація/імплементація)
    public interface GunImplementor
    {
        void Info();
    }

    //Клас (конкретна абстракція)
    public class TigerPanzer : PanzerAbstraction
    {
        public override void Move()
        {
            Console.WriteLine("Br-r-r... 60 km/h");
        }
    }

    //Клас (конкретна реалізація/імплементація)
    public class BestGun : GunImplementor
    {
        public void Info()
        {
            Console.WriteLine("8,8 cm KwK 36");
        }
    }

    //Клас (конкретна реалізація/імплементація)
    public class AircraftGun : GunImplementor
    {
        public void Info()
        {
            Console.WriteLine("FlaK 18/36");
        }
    }
}