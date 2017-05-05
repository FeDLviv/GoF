using System;

/*
ПАТЕРН ПОВЕДІНКИ
ЛАНЦЮГ ВІДПОВІДАЛЬНОСТЕЙ (Behavioral pattern Chain of Responsibility)
Призначення:
Уникає зв’язності відправника запиту із його адресатом шляхом надання іншим об’єктам можливості обробити запит. 
Передає отримані об’єкти вздовж ланцюжка допоки якась ланка не обробить об’єкт.
Приклад:
WPF bubbling events 
*/

namespace ChainOfResponsibility
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car() { Model = "Audi", Crash = TypeOfCrashing.PC };

            Electrician electrician = new Electrician();
            Engineer engineer = new Engineer();
            electrician.Helper = engineer;
            
            electrician.RepairCar(car);
        }
    }

    //Абстрактний клас для обробки запита (обробник)
    public abstract class AutoMechanicHandler
    {
        public AutoMechanicHandler Helper { get; set; }
        public abstract void RepairCar(Car car);
    }

    //Конкретний обробник запита (електрик)
    public class Electrician : AutoMechanicHandler
    {
        public override void RepairCar(Car car)
        {
            if (car.Crash == TypeOfCrashing.Motor || car.Crash == TypeOfCrashing.Wheel)
            {
                HardWork();
                return;
            }
            else if (Helper != null)
            {
                Helper.RepairCar(car);
            }
        }

        public void HardWork()
        {
            Console.WriteLine("Electrician repaired your car.");
        }
    }

    //Конкретний обробник запита (інженер)
    public class Engineer : AutoMechanicHandler
    {
        public override void RepairCar(Car car)
        {
            if (car.Crash == TypeOfCrashing.PC)
            {
                Work();
                return;
            }
            else if (Helper != null)
            {
                Helper.RepairCar(car);
            }
        }

        public void Work()
        {
            Console.WriteLine("Engineer repaired your car.");
        }
    }

    //Тестовий клас (авто)
    public class Car
    {
        public string Model { get; set; }
        public TypeOfCrashing Crash { get; set; }
    }

    //Тестове перечислення (типи пошкоджень автомобіля)
    public enum TypeOfCrashing
    {
        Motor, PC, Wheel, OK
    }
}