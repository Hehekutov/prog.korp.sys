using System;

class Program
{
    // Рекурсивный метод для переворота числа
    static int ReverseNumber(int n, int reversed = 0)
    {
        // Базовый случай: если число закончилось — вернуть результат
        if (n == 0)
            return reversed;

        // Берём последнюю цифру и добавляем её в "развёрнутое" число
        return ReverseNumber(n / 10, reversed * 10 + n % 10);
    }

    static void Main()
    {
        Console.Write("Введите число: ");
        int n = int.Parse(Console.ReadLine());

        int result = ReverseNumber(n);

        Console.WriteLine($"Развёрнутое число: {result}");
    }
}
