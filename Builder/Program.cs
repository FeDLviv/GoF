using System;
using System.Text;

/*
ПОРОДЖУЮЧИЙ ПАТЕРН
БУДІВЕЛЬНИК (Creational pattern Builder)
Призначення:
Відділити створення складного об’єкта від його представлення, 
щоб той же процес створення міг утворити різні представлення.
*/
namespace Builder
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            PizzaBuilder builderItali = new ItaliPizzaBuilder();
            PizzaBuilder builderCheap = new CheapPizzaBuilder();

            PizzaDirector director = new PizzaDirector();

            director.SetBuilder(builderItali);
            Console.WriteLine(director.BuildPizza());

            director.SetBuilder(builderCheap);
            Console.WriteLine(director.BuildPizza());
        }
    }

    //Абстрактний будівельник
    public abstract class PizzaBuilder
    {
        protected Pizza Pizza { get; private set; }

        public void CreatePizza()
        {
            Pizza = new Pizza();
        }

        public Pizza GetPizza()
        {
            return Pizza;
        }

        abstract public void SetChees();
        abstract public void SetMeat();
        abstract public void SetTomat();
    }

    //Директор
    public class PizzaDirector
    {
        public PizzaBuilder builder;

        public void SetBuilder(PizzaBuilder builder)
        {
            this.builder = builder;
        }

        public Pizza BuildPizza()
        {
            builder.CreatePizza();
            builder.SetChees();
            builder.SetMeat();
            builder.SetTomat();
            return builder.GetPizza();
        }
    }

    //Об'єкт, який повинен бути створений будівельником
    public class Pizza
    {
        public string Chees { get; set; }
        public string Meat { get; set; }
        public string Tomato { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if (Chees != null)
                builder.Append("CHEES - " + Chees + " ");
            if (Meat != null)
                builder.Append("MEAT - " + Meat + " ");
            if (Tomato != null)
                builder.Append("TOMAT - " + Tomato + " ");
            return builder.ToString();
        }
    }

    //Одна з реалізацій будівельника
    public class ItaliPizzaBuilder : PizzaBuilder
    {
        public override void SetChees()
        {
            Pizza.Chees = "Super chees";
        }

        public override void SetMeat()
        {
            Pizza.Meat = "Bacon";
        }

        public override void SetTomat()
        {
            Pizza.Tomato = "Cherry";
        }
    }

    //Одна з реалізацій будівельника
    public class CheapPizzaBuilder : PizzaBuilder
    {
        public override void SetChees()
        {
            Pizza.Chees = "Low chees";
        }

        public override void SetMeat()
        {
        }

        public override void SetTomat()
        {
        }
    }
}