using System;

/*
ПОРОДЖУЮЧИЙ ПАТЕРН
ФАБРИЧНИЙ МЕТОД
Призначення:
Визначити інтерфейс для створення об’єкта, але надати підкласам вирішувати, який клас інстанціювати. 
Фабричний Метод відделеговує інстанцювання своїм підкласам.
*/
namespace FactoryMethod
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            //1
            AbstractFactory factory = new XMLFileFactory();
            Console.WriteLine(factory.CreateFile().FileInfo());

            //2
            Console.WriteLine(FileFactory.CreateFile(FileExtension.xlsx).FileInfo());
        }
    }

    //Абстрактний клас, який містить Фабричний Метод (Creational pattern Factory Method)
    public abstract class AbstractFactory
    {
        public abstract IFile CreateFile();
    }

    //Клас файла XML, який реалізовує фабричний метод
    public class XMLFileFactory : AbstractFactory
    {
        public override IFile CreateFile()
        {
            return new XMLFile();
        }
    }

    //Клас файла Excel, який реалізовує фабричний метод
    public class ExcelFileFactory : AbstractFactory
    {
        public override IFile CreateFile()
        {
            return new ExcelFile();
        }
    }

    //Інтерфейс для файла
    public interface IFile
    {
        string FileInfo();
    }

    //XML файл
    public class XMLFile : IFile
    {
        public string FileInfo()
        {
            return "This is XMLFile. Extension = .xml";
        }
    }

    //Excel файл
    public class ExcelFile : IFile
    {
        public string FileInfo()
        {
            return "This is Excel. Extension = .xlsx";
        }
    }



    //Параметризований Фабричний Метод (Creational pattern Factory Method)
    public class FileFactory
    {
        public static IFile CreateFile(FileExtension ext)
        {
            switch (ext)
            {
                case FileExtension.xml:
                    return new XMLFile();
                case FileExtension.xlsx:
                    return new ExcelFile();
                default:
                    return new XMLFile();
            }
        }
    }

    //Перечислення розширень файлів
    public enum FileExtension
    {
        xml,
        xlsx
    }
}