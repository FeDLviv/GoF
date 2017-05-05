using System;

/*
ПАТЕРН ПОВЕДІНКИ
СТАН
Призначення:
Дозволяє об’єкту змінити свою поведінку тоді, коли внутрішній стан змінюється. 
Буде здаватися, що об’єкт змінив свій клас.
 */
namespace State
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Weather weather = new Weather(new Summer());
            weather.BeginSummer();
            weather.BeginAutumn();
            weather.BeginWinter();
            weather.BeginSpring();

            weather.BeginWinter();
        }
    }

    //Клас для тестування зміни стану (погода)
    public class Weather
    {
        private State state;

        public Weather(State state)
        {
            this.state = state;
        }

        public void SetState(State state)
        {
            this.state = state;
        }

        public void BeginSummer()
        {
            state.BeginSummer(this);
        }

        public void BeginAutumn()
        {
            state.BeginAutumn(this);
        }

        public void BeginWinter()
        {
            state.BeginWinter(this);
        }

        public void BeginSpring()
        {
            state.BeginSpring(this);
        }
    }

    //Стан (Behavioral pattern State)
    public abstract class State
    {
        public virtual void BeginSummer(Weather weather)
        {
            Console.WriteLine("IS NOT ALLOWED.");
        }

        public virtual void BeginAutumn(Weather weather)
        {
            Console.WriteLine("IS NOT ALLOWED.");
        }

        public virtual void BeginWinter(Weather weather)
        {
            Console.WriteLine("IS NOT ALLOWED.");
        }

        public virtual void BeginSpring(Weather weather)
        {
            Console.WriteLine("IS NOT ALLOWED.");
        }
    }

    //Конкретний стан (літо)
    public class Summer : State
    {
        public override void BeginSummer(Weather weather)
        {
            Console.WriteLine("Big heat...");
        }

        public override void BeginAutumn(Weather weather)
        {
            Console.WriteLine("AUTUMN start...");
            weather.SetState(new Autumn());
        }
    }

    //Конкретний стан (осінь)
    public class Autumn : State
    {
        public override void BeginAutumn(Weather weather)
        {
            Console.WriteLine("Heavy rain...");
        }

        public override void BeginWinter(Weather weather)
        {
            Console.WriteLine("WINTER start...");
            weather.SetState(new Winter());
        }
    }

    //Конкретний стан (зима)
    public class Winter : State
    {
        public override void BeginWinter(Weather weather)
        {
            Console.WriteLine("Very cold...");
        }

        public override void BeginSpring(Weather weather)
        {
            Console.WriteLine("SPRING start...");
            weather.SetState(new Spring());
        }
    }

    //Конкретний стан (весна)
    public class Spring : State
    {
        public override void BeginSpring(Weather weather)
        {
            Console.WriteLine("Skies are clear...");
        }

        public override void BeginSummer(Weather weather)
        {
            Console.WriteLine("SUMMER start...");
            weather.SetState(new Summer());
        }
    }
}