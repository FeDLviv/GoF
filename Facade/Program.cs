using System;

/*
СТРУКТУРНИЙ ПАТЕРН
ФАСАД
Призначення:
Надає єдиний інтерфейс до множини інших інтерфейсів у системі. 
Фасад визначає верхній інтерфейс, що робить систему легшою для використання.
*/
namespace Facade
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            HouseFacade facade = new HouseFacade();
            Console.WriteLine("BUILD HOUSE:");
            facade.Build();
            Console.WriteLine("DESTROY HOUSE:");
            facade.Destroy();
        }
    }

    //Фасад (Structural pattern Facade)
    public class HouseFacade
    {
        private Foundation foundation = new Foundation();
        private Frame frame = new Frame();
        private Roof roof = new Roof();

        public void Build()
        {
            foundation.FillFoundation();
            frame.CreateFrame(foundation);
            roof.CreateRoof();
            roof.PaintRoof();
        }

        public void Destroy()
        {
            roof.DestroyRoof();
            frame.DismantleFrame();
            foundation.DestroyFoundation();
        }
    }

    //Фундамент будівлі
    public class Foundation
    {
        public bool IsStiffened {private set; get; }

        public Foundation()
        {
            IsStiffened = false;
        }

        public void FillFoundation()
        {
            Console.WriteLine("Fill foundation.");
            IsStiffened = true;
        }

        public void DestroyFoundation()
        {
            Console.WriteLine("Destroy foundation.");
        }
    }

    //Каркас будівлі
    public class Frame
    {
        public void CreateFrame(Foundation foundation)
        {
            if (foundation.IsStiffened)
            {
                Console.WriteLine("Create frame.");
            }
            else
            {
                throw new Exception("Foundation is not stiffened!!!");
            }
        }

        public void DismantleFrame()
        {
            Console.WriteLine("Dismantle frame.");
        }
    }

    //Криша будівлі
    public class Roof
    {
        public void CreateRoof()
        {
            Console.WriteLine("Create roof.");
        }

        public void PaintRoof()
        {
            Console.WriteLine("Paint roof.");
        }

        public void DestroyRoof()
        {
            Console.WriteLine("Destroy roof.");
        }
    }
}