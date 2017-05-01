using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/*
ПОРОДЖУЮЧИЙ ПАТЕРН
ПРОТОТИП
Призначення:
Визначає різновиди об’єктів, щоб створити їх на основі прототипічного екземпляру, 
і створює нові об’єкти, копіюючи цей прототип.
Приклад:
ICloneable
*/
namespace Prototype
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            ReferencePrototype a = new ReferencePrototype();

            ReferencePrototype b = (ReferencePrototype) a.Clone();

            a.X = 10;
            a.Y.Z = 9;

            ReferencePrototype c = (ReferencePrototype) a.Clone();

            Console.WriteLine("a={0}; b={1}; c={2}", a, b, c);
        }
    }

    //Прототип (Creational pattern Prototype)
    public interface IPrototype
    {
        IPrototype Clone();
    }

    //Прототип для поверхневого копіювання
    //Поверхневе копіювання (Shallow copy) 
    //Копіює тільки прямі поля класу і залишає ті ж посилання, якщо поле було reference-типу, 
    //нова копія буде створена тільки якщо поле було value-типу.
    public class SimplePrototype : IPrototype
    {
        public int X { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", X);
        }

        public IPrototype Clone()
        {
            return this.MemberwiseClone() as SimplePrototype;
        }
    }

    //Прототип для глибокого копіювання
    //Глибоке копіювання (Deep copy) 
    //Копіює ціле дерево об'єктів, таким чином об'єкти отримають різні фізичні адреси в купі (heap).
    [Serializable]
    public class ReferencePrototype : IPrototype
    {
        public int X { get; set; }

        public Test Y { get; set; }

        public ReferencePrototype()
        {
            Y = new Test();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", X, Y);
        }

        public IPrototype Clone()
        {
            IPrototype copy = null;
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);

                stream.Seek(0, SeekOrigin.Begin);
                
                copy = formatter.Deserialize(stream) as IPrototype;
            }
            return copy;
        }
    }

    //Клас для тестування (клонування посиланнь)
    [Serializable]
    public class Test
    {
        public int Z { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Z);
        }
    }
}