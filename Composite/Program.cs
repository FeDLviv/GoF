using System;
using System.Collections.Generic;

/*
СТРУКТУРНИЙ ПАТЕРН
КОМПОНУВАЛЬНИК (Structural pattern Composite)
Призначення:
Компонує об’єкти в деревовидну структуру для представлення частково-цілої ієрархії. 
Компонувальник дозволяє розглядати окремі об’єкти і їхні композиції єдиним способом.
*/
namespace Composite
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Component lte = new ServiceComposite("Lvivteploenergo");

            ServiceComposite energy = new ServiceComposite("Energy service");
            lte.Add(energy);

            ServiceComposite lab = new ServiceComposite("Laboratory");
            energy.Add(lab);

            energy.Add(new PersonLeaf("Vlasov"));
            energy.Add(new PersonLeaf("Zakota"));

            lte.Print();
        }
    }

    //Інтерфейс для всіх компонентів в ієрархічній структурі
    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component)
        {
        }

        public virtual void Remove(Component component)
        {
        }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }

    //Клас, реалізація компонента, що містить інші компоненти (служба)
    public class ServiceComposite : Component
    {
        private List<Component> children = new List<Component>();

        public ServiceComposite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine("***CHILDREN:***");
            foreach (Component component in children)
            {
                component.Print();
            }
        }
    }

    //Клас, реалізація «листкового» компонента (працівник)
    public class PersonLeaf : Component
    {
        public PersonLeaf(string name)
            : base(name)
        {
        }
    }
}