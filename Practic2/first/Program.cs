using System;

namespace TaylorSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление функции e^x с помощью ряда Маклорена");
            Console.WriteLine("==============================================");

            while (true)
            {
                Console.WriteLine("\nВыберите операцию:");
                Console.WriteLine("1 - Вычисление с заданной точностью");
                Console.WriteLine("2 - Вычисление n-го члена ряда");
                Console.WriteLine("3 - Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculateWithPrecision();
                        break;
                    case "2":
                        CalculateNthTerm();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        // Вычисление e^x с заданной точностью
        static void CalculateWithPrecision()
        {
            try
            {
                Console.Write("Введите x: ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("Введите точность e (e < 0.01): ");
                double epsilon = double.Parse(Console.ReadLine());

                if (epsilon >= 0.01)
                {
                    Console.WriteLine("Ошибка: точность должна быть меньше 0.01");
                    return;
                }

                double result = 0;
                double term = 1; // первый член ряда (n=0)
                int n = 0;
                double factorial = 1;

                Console.WriteLine("\nВычисление с точностью:");
                Console.WriteLine($"n = {n}: член = {term:F6}, сумма = {result + term:F6}");

                // Суммируем члены ряда пока текущий член больше точности
                while (Math.Abs(term) >= epsilon)
                {
                    result += term;
                    n++;
                    factorial *= n; // вычисляем n!
                    term = Math.Pow(x, n) / factorial;

                    Console.WriteLine($"n = {n}: член = {term:F6}, сумма = {result + term:F6}");
                }

                result += term; // добавляем последний вычисленный член

                double exactValue = Math.Exp(x);
                double error = Math.Abs(exactValue - result);

                Console.WriteLine("\nРезультаты:");
                Console.WriteLine($"Вычисленное значение: {result:F10}");
                Console.WriteLine($"Точное значение (Math.Exp): {exactValue:F10}");
                Console.WriteLine($"Погрешность: {error:F10}");
                Console.WriteLine($"Количество итераций: {n + 1}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат ввода");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: слишком большое число");
            }
        }

        // Вычисление n-го члена ряда
        static void CalculateNthTerm()
        {
            try
            {
                Console.Write("Введите x: ");
                double x = double.Parse(Console.ReadLine());

                Console.Write("Введите n (номер члена ряда): ");
                int n = int.Parse(Console.ReadLine());

                if (n < 0)
                {
                    Console.WriteLine("Ошибка: n должен быть неотрицательным");
                    return;
                }

                // Вычисляем n-й член ряда: x^n / n!
                double term = CalculateTerm(x, n);

                Console.WriteLine($"\n{n}-й член ряда: {term:F10}");
                Console.WriteLine($"Формула: x^{n} / {n}! = {Math.Pow(x, n)} / {Factorial(n)}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: неверный формат ввода");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: слишком большое число");
            }
        }

        // Вычисление n-го члена ряда Маклорена для e^x
        static double CalculateTerm(double x, int n)
        {
            if (n == 0)
                return 1; // нулевой член всегда 1

            return Math.Pow(x, n) / Factorial(n);
        }

        // Вычисление факториала
        static double Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            double result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}