using System;

/*
СТРУКТУРНИЙ ПАТЕРН
АДАПТЕР 
Призначення:
Конвертувати інтерфейс класу в інший інтерфейс, очікуваний клієнтами. 
Адаптер дозволяє класам працювати разом, що не могло б бути інакше через несумісність інтерфейсів.
Приклад:
SqlDataAdapter
*/
namespace Adapter
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Buy(new Hryvnia());
            shop.Buy(new ATMAdapter(new CreditCard()));
        }
    }

    //Клас, який буде адаптований (кредитна картка)
    public class CreditCard
    {
        public virtual void GiveCash()
        {
            Console.WriteLine("Your money (card)");
        }
    }

    //Інтерфейс грошей (готівка)
    public interface Money
    {
        void GiveMoney();
    }

    //Клас, до якого потрібно адаптувати інший клас (гривня)
    public class Hryvnia : Money
    {
        public void GiveMoney()
        {
            Console.WriteLine("Your money (cash)");
        }
    }
     
    //Адаптер (Structural pattern Adapter) (банкомат)
    public class ATMAdapter : Money
    {
        private CreditCard card;

        public ATMAdapter(CreditCard card)
        {
            this.card = card;
        }

        public void GiveMoney()
        {
            card.GiveCash();
        }
    }

    //Клас для тестування (магазин)
    public class Shop
    {
        public void Buy(Money cash)
        {
            cash.GiveMoney();
        }
    }
}