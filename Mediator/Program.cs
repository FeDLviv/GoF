using System;

/*
ПАТЕРН ПОВЕДІНКИ
ПОСЕРЕДНИК 
Призначення:
Визначає об’єкт, що інкапсулює взаємодію між множиною об’єктів.
Медіатор покращує слабкозв’язність шляхом утримання об’єктів від прямих посилань один на одного, 
а також дозволяє незалежно змінювати взаємодію.
 */
namespace Mediator
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();

            MedicDepartment medic = new MedicDepartment(dispatcher);
            FireDepartment fire = new FireDepartment(dispatcher);
            Police police = new Police(dispatcher);

            dispatcher.Medic = medic;
            dispatcher.Fire = fire;
            dispatcher.Police = police;

            fire.SendMessage("Address: str.Shevchenka, 22");
        }
    }

    //Посередник (Behavioral pattern Mediator)
    public interface IMediator
    {
        void SendMessage(string msg, Сolleague service);
    }

    //Конкретний посередник (диспетчер)
    public class Dispatcher : IMediator
    {
        public FireDepartment Fire { get; set; }
        public MedicDepartment Medic { get; set; }
        public Police Police { get; set; }

        public void SendMessage(string msg, Сolleague service)
        {
            if (service is FireDepartment)
            {
                Medic.Attention(service.GetType().Name.ToString().ToUpper() + " " + msg);
                Police.Attention(service.GetType().Name.ToString().ToUpper() + " " + msg);
            }
            else if (service is MedicDepartment && Medic.IsScope)
            {
                Police.Attention(service.GetType().Name.ToString().ToUpper() + " " + msg);
            }
            else if (service is Police && Police.IsMurder)
            {
                Medic.Attention(service.GetType().Name.ToString().ToUpper() + " " + msg);
            }
        }
    }

    //Абстрактний клас (колега)
    public abstract class Сolleague
    {
        protected IMediator dispatcher;

        public Сolleague(IMediator dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public void SendMessage(string message)
        {
            dispatcher.SendMessage(message, this);
        }

        public abstract void Attention(string msg);
    }

    //Конкретний колега (пожежники)
    public class FireDepartment : Сolleague
    {
        public FireDepartment(IMediator dispatcher)
            : base(dispatcher)
        { }

        public override void Attention(string msg)
        {
            Console.WriteLine("*** {0} ***", msg);
            Console.WriteLine("Fire department - READY");
        }
    }

    //Конкретний колега (швидка допомога)
    public class MedicDepartment : Сolleague
    {
        public bool IsScope { get; set; }

        public MedicDepartment(IMediator dispatcher)
            : base(dispatcher)
        { }

        public override void Attention(string msg)
        {
            Console.WriteLine("*** {0} ***", msg);
            Console.WriteLine("Medic department - READY");
        }
    }

    //Конкретний колега (поліція)
    public class Police : Сolleague
    {
        public bool IsMurder { get; set; }

        public Police(IMediator dispatcher)
            : base(dispatcher)
        { }

        public override void Attention(string msg)
        {
            Console.WriteLine("*** {0} ***", msg);
            Console.WriteLine("Police - READY");
        }
    }
}