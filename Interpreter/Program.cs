using System;

/*
СТРУКТУРНИЙ ПАТЕРН
ІНТЕРПРЕТАТОР (Behavioral pattern Interpreter)
Призначення:
Маючи мову, визначає представлення її граматики та інтерпретарор, що
використовує це представлення, щоб інтерпретувати речення цієї мови.
*/
namespace Interpreter
{
    //ТЕСТ
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            IExpression expression = context.evaluate("10-9+0+2");
            Console.WriteLine(expression.Interpret());
        }
    }

    //Інтерфейс (вираз)
    public interface IExpression 
    {
        int Interpret();
    }

    //Термінальний вираз (число)
    public class NumberExpression : IExpression
    {
        private int number;

        public NumberExpression(int number)
        {
            this.number = number;
        }

        public int Interpret()
        {
            return number;
        }
    }

    //Нетермінальний вираз (віднімання)
    public class SubExpression : IExpression 
    {
        private IExpression left;
        private IExpression right;

        public SubExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret()
        {
            return left.Interpret() - right.Interpret();
        }
    }

    //Нетермінальний вираз (додавання)
    public class AddExpression : IExpression
    {
        private IExpression left;
        private IExpression right;

        public AddExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret()
        {
            return left.Interpret() + right.Interpret();
        }
    }

    //Контекст
    public class Context
    {
        public IExpression evaluate(String data)
        {
            int pos = data.Length - 1;
            while (pos > 0)
            {
                if (Char.IsDigit(data[pos]))
                {
                    pos--;
                }
                else 
                {
                    IExpression left = evaluate(data.Substring(0, pos));
                    IExpression right = new NumberExpression(int.Parse(data.Substring(pos + 1)));
                    char oper = data[pos];
                    switch (oper)
                    { 
                        case '-':
                            return new SubExpression(left, right);
                        case '+':
                            return new AddExpression(left, right);
                        default:
                            throw new Exception("Wrong expression");                       
                    }
                }
            }
            int result = int.Parse(data);
            return new NumberExpression(result);
        }
    }
}