using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWithLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение:");
            string text = Console.ReadLine();
            Calculator.getAnswer(text);
            Console.ReadKey();
        }
    }
}
