using System;

class Calculator
{
    private double memory = 0;

    public double Add(double a, double b) => a + b;
    public double Sub(double a, double b) => a - b;
    public double Mul(double a, double b) => a * b;
    public double Div(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Деление на ноль невозможно!");
        return a / b;
    }
    public double Mod(double a, double b) => a % b;
    public double Reciprocal(double a)
    {
        if (a == 0)
            throw new DivideByZeroException("1/0 невозможно!");
        return 1 / a;
    }
    public double Square(double a) => Math.Pow(a, 2);
    public double Sqrt(double a)
    {
        if (a < 0)
            throw new ArgumentException("Квадратный корень из отрицательного числа невозможен!");
        return Math.Sqrt(a);
    }
    public void MPlus(double value) => memory += value;
    public void MMinus(double value) => memory -= value;
    public double MR() => memory;
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        try
        {
            Console.WriteLine("Введите первое число:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите операцию (+, -, *, /, %, 1/x, x^2, sqrt, M+, M-, MR):");
            string op = Console.ReadLine();

            double result = 0;

            switch (op)
            {
                case "+":
                    Console.WriteLine("Введите второе число:");
                    double b1 = Convert.ToDouble(Console.ReadLine());
                    result = calc.Add(a, b1);
                    break;

                case "-":
                    Console.WriteLine("Введите второе число:");
                    double b2 = Convert.ToDouble(Console.ReadLine());
                    result = calc.Sub(a, b2);
                    break;

                case "*":
                    Console.WriteLine("Введите второе число:");
                    double b3 = Convert.ToDouble(Console.ReadLine());
                    result = calc.Mul(a, b3);
                    break;

                case "/":
                    Console.WriteLine("Введите второе число:");
                    double b4 = Convert.ToDouble(Console.ReadLine());
                    result = calc.Div(a, b4);
                    break;

                case "%":
                    Console.WriteLine("Введите второе число:");
                    double b5 = Convert.ToDouble(Console.ReadLine());
                    result = calc.Mod(a, b5);
                    break;

                case "1/x":
                    result = calc.Reciprocal(a);
                    break;

                case "x^2":
                    result = calc.Square(a);
                    break;

                case "sqrt":
                    result = calc.Sqrt(a);
                    break;

                case "M+":
                    calc.MPlus(a);
                    Console.WriteLine("Значение добавлено в память.");
                    break;

                case "M-":
                    calc.MMinus(a);
                    Console.WriteLine("Значение вычтено из памяти.");
                    break;

                case "MR":
                    result = calc.MR();
                    break;

                default:
                    Console.WriteLine("Неизвестная операция!");
                    break;
            }

            if (op != "M+" && op != "M-")
                Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}