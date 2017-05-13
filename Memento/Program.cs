using System;
using System.Collections.Generic;

/*
СТРУКТУРНИЙ ПАТЕРН
ХРАНИТЕЛЬ (Behavioral pattern Memento)
Призначення:
Без порушення інкапсуляції зафіксувати та відокремети внутрішній стан об’єкта так,
що об’єкт потім зможе повернутися до цього стану.
*/
namespace Memento
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            PanzerCaretaker caretaker = new PanzerCaretaker();
            PanzerOriginator panzer = new PanzerOriginator();

            panzer.Battle();

            caretaker.F5(panzer.Save());

            panzer.Battle();

            panzer.Load(caretaker.F9());

            panzer.Battle();
        } 
    }

    //Об'єкт стан, якого будемо зберігати (originator)
    public class PanzerOriginator
    {
        private Random rand = new Random();
        private int lives = 100;
        private int shells = 46;

        public void Battle()
        {
            lives -= rand.Next(0, 25);
            shells -= rand.Next(1, 5);
            if (lives > 0)
            {
                Console.WriteLine("Your win: lives-{0}, shells-{1}", lives, shells);
            }
            else
            {
                Console.WriteLine("Game over");
            }
        }

        public PanzerMemento Save()
        {
            Console.WriteLine("SAVE (lives-{0}, shells-{1})", lives, shells);
            return new PanzerMemento(lives, shells);
        }

        public void Load(PanzerMemento memento)
        {
            lives = memento.Lives;
            shells = memento.Shells;
            Console.WriteLine("LOAD (lives-{0}, shells-{1})", lives, shells);
        }
    }
    
    //Хранитель, містить збережений стан об'єкта (memento) 
    public class PanzerMemento
    {
        public int Lives { get; set; }
        public int Shells { get; set; }

        public PanzerMemento(int lives, int shells)
        {
            Lives = lives;
            Shells = shells;
        }
    }

    //Опікун, який зберігає всіх "хранителів" (caretaker)
    public class PanzerCaretaker
    {
        private Stack<PanzerMemento> stack = new Stack<PanzerMemento>();

        public void F5(PanzerMemento memento)
        {
            stack.Push(memento);
        }

        public PanzerMemento F9()
        {
            return stack.Peek();
        }
    }
}
