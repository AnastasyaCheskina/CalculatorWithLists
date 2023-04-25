using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorWithLists
{
    public class Calculator
    {
        public static int? getAnswer(string text)
        {
            int? sum = 0;
            try
            {
                string[] nums = text.Split('*', '/', '+', '-');
                List<string> symbols = new List<string>();
                Calculator.SymbolFinder(text, symbols);
                List<string> result = new List<string>();
                List<string> numbers = new List<string>();
                Calculator.Prioritets(symbols, nums, numbers, result);
                sum = Calculator.Calculation(result, numbers);
                Console.WriteLine("Ответ: " + sum);
            }
            catch (Exception ex)
            {
                sum = null;
                Console.WriteLine(ex.Message);
            }
            return sum;
        }
        public static int Calculation(List<string> res, List<string> nums) //подсчет суммы и разности (итоговый подсчет)
        {
            int sum = Convert.ToInt32(nums[0]);
            for (int i = 0; i < res.Count; i++)
            {
                switch (Convert.ToChar(res[i]))
                {
                    case '+':
                        sum += Convert.ToInt32(nums[i + 1]);
                        break;
                    case '-':
                        sum -= Convert.ToInt32(nums[i + 1]);
                        break;
                }
            }
            return sum;
        }
        public static List<string> Prioritets(List<string> symbols, string[] nums, List<string> numbers, List<string> result) //подсчет с учетом приоритета (умножение и деление)
        {
            for (int i = 0; i < symbols.Count; i++) //цикл по всем символам (знакам) в соответствующем листе
            {
                switch (Convert.ToChar(symbols[i])) //конвертируем из строк в символы
                {
                    case '*':
                        numbers.Add(Convert.ToString(Convert.ToInt32(nums[i]) * Convert.ToInt32(nums[i + 1])));
                        break;
                    case '/':
                        numbers.Add(Convert.ToString(Convert.ToInt32(nums[i]) / Convert.ToInt32(nums[i + 1])));
                        break;
                    case '+':
                        if (i != 0 && (symbols[i - 1] == "*" | symbols[i - 1] == "/"))
                        {
                            result.Add("+");
                            break;
                        }
                        else
                        {
                            numbers.Add(nums[i]);
                            result.Add("+");
                            break;
                        }
                    case '-':
                        if (i != 0 && (symbols[i - 1] == "*" | symbols[i - 1] == "/"))
                        {
                            result.Add("-");
                            break;
                        }
                        else
                        {
                            numbers.Add(nums[i]);
                            result.Add("-");
                            break;
                        }
                }
            }
            return result;
        }
        public static List<string> SymbolFinder(string text, List<string> symbols) //поиск символов в введенной строке, их передача в лист
        {
            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        symbols.Add(Convert.ToString(text[i]));
                        break;
                }
            }
            return symbols;
        }
    }
}
