using System;

/*
СТРУКТУРНИЙ ПАТЕРН
ДЕКОРАТОР (Structural pattern Decorator)
Призначення: 
Приєднує додаткові обов’язки до об’єкта динамічно. 
Декорування надає гнучку альтернативу наслідуванню в питання розширення функціональності.
Приклад:
java.io
*/
namespace Decorator
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Human ukr = new Ukrainian("Fedir");
            ukr.GetInfo();
            Console.WriteLine("***");    

            HumanDecorator decoratorHuman= new WorkHumanDecorator(new ArmiiHumanDecorator(ukr));
            decoratorHuman.GetInfo();
        }
    }

    //Абстрактний клас, основа для класів, які будуть декоруватися (людина)
    public abstract class Human
    {
        protected string Name { get; set; }

        public abstract void GetInfo();
    }

    //Конкретна реалізація класу, який буде декоруватися (людина)
    public class Ukrainian : Human
    {
        public Ukrainian(String name)
        {
            Name = name;
        }

        public override void GetInfo()
        {
            Console.WriteLine("My name is - {0}.", Name);
        }
    }
    
    //Абстрактний клас, основа для класів, які будуть декорувати (людину)
    public abstract class HumanDecorator : Human
    {
        protected Human Human { get; set; }

        public HumanDecorator (Human human)
        {
            Human = human;
        }

        public override void GetInfo()
        {
            Human.GetInfo();
        }
    }

    //Конкретна реалізація класу, який буде декорувати (людину - армія)
    public class ArmiiHumanDecorator : HumanDecorator 
    {
        public ArmiiHumanDecorator(Human human)
            : base(human)
        { 
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("I served in the army.");
        }
    }

    //Конкретна реалізація класу, який буде декорувати (людину - робота)
    public class WorkHumanDecorator : HumanDecorator
    {
        public WorkHumanDecorator(Human human)
            : base(human)
        {
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("I am worked.");
        }
    }
}