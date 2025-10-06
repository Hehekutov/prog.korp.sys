using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числитель: ");
        int numerator = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите знаменатель: ");
        int denominator = int.Parse(Console.ReadLine());

        if (denominator == 0)
        {
            Console.WriteLine("Ошибка: знаменатель не может быть равен 0");
            return;
        }

        // Сокращаем дробь
        (int reducedNumerator, int reducedDenominator) = ReduceFraction(numerator, denominator);

        // Форматируем вывод
        string result = FormatFraction(reducedNumerator, reducedDenominator);

        Console.WriteLine($"Результат: {result}");
    }

    // Функция для сокращения дроби
    static (int, int) ReduceFraction(int numerator, int denominator)
    {
        // Находим наибольший общий делитель
        int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));

        // Сокращаем дробь
        int reducedNum = numerator / gcd;
        int reducedDen = denominator / gcd;

        // Убеждаемся, что знаменатель всегда положительный
        if (reducedDen < 0)
        {
            reducedNum = -reducedNum;
            reducedDen = -reducedDen;
        }

        return (reducedNum, reducedDen);
    }

    // Функция для нахождения наибольшего общего делителя (НОД)
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Функция для форматирования дроби
    static string FormatFraction(int numerator, int denominator)
    {
        if (denominator == 1)
        {
            return numerator.ToString(); // Если знаменатель 1, выводим только числитель
        }
        else
        {
            return $"{numerator} / {denominator}";
        }
    }
}