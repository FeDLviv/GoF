using System;

/*
ПАТЕРН ПОВЕДІНКИ
КОМАНДА (Behavioral pattern Command)
Призначення:
Інкапсулює запит в об’єкт, таким чином даючи можливість параметризувати клієнтський код різними запитами, 
залогувати або закинути в чергу чи підтримувати необроблювані операції.
Приклад:
команди в WPF 
*/
namespace Command
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto();
            RemoteControl control = new RemoteControl();
            control.SetCommand(new WarmUpCommand(auto));
            control.Click();
        }
    }

    //Інтерфейс команди 
    public interface ICommand
    {
         void Execute();
    }

    //Конкретна команда command (прогріти двигун авто)
    public class WarmUpCommand : ICommand 
    {
        private Auto receiver;

        public WarmUpCommand(Auto receiver)
        {
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.WarmUp();
        }
    }

    //Отримувач команди receiver (авто)
    public class Auto
    {
        public void WarmUp()
        {
            Console.WriteLine("The engine of the car is warming up.");
        }
    }

    //Ініціатор команди invoker (дистанційний пульт керування)
    public class RemoteControl 
    {
        protected ICommand Command { get; set; }
       
        public void SetCommand(ICommand command)
        {
            Command = command;
        }
        
        public void Click()
        {
            Command.Execute();
        }
    }
}