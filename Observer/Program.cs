using System;
using System.Collections.Generic;

/*
СТРУКТУРНИЙ ПАТЕРН
СПОСТЕРІГАЧ (Behavioral pattern Observer)
Призначення:
Визначає залежність один-до-багатьох між об’єктами так, що коли один змінює свій стан, 
усі залежні інформуються та оновлюються автоматично.
Приклад:
ObservableCollection
*/
namespace Observer
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            UAHSubject uah = new UAHSubject() { SaleUSA = 26.2M, BuyUSA = 27.3M };
            
            BankObserver pb = new BankObserver("PB");
            BankObserver oschad = new BankObserver("Oschadbank");

            uah.AddObserver(pb);
            uah.AddObserver(oschad);

            uah.SaleUSA = 25.7M;
        }
    }

    //Інтерфейс спостерігача
    public interface IObserver
    {
        void Update(decimal sale, decimal buy);
    }

    //Конкретний спостерігач (банк)
    class BankObserver : IObserver
    {
        private string name;

        public BankObserver(string name)
        {
            this.name = name;
        }

        public void Update(decimal sale, decimal buy)
        {
            Console.WriteLine("***{0} received a message***", name);
            Console.WriteLine("UAH change: sale USA: {0}, buy USA {1}", sale, buy);
        }
    }

    //Інтерфейс суб'єкта нагляду
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

    //Конкретний суб'єкт нагляду (гривня)
    public class UAHSubject : ISubject
    {
        private decimal saleUSA;

        public decimal SaleUSA
        {
            get { return saleUSA; }
            set
            {
                saleUSA = value;
                NotifyObservers();
            }
        }

        private decimal buyUSA;

        public decimal BuyUSA
        {
            get { return buyUSA; }
            set
            {
                buyUSA = value;
                NotifyObservers();
            }
        }

        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(SaleUSA, BuyUSA);
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
    }
}