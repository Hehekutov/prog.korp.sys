using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер билета: ");
        int ticket = int.Parse(Console.ReadLine());

        // Проверка на шестизначность
        if (ticket < 100000 || ticket > 999999)
        {
            Console.WriteLine("Ошибка: номер билета должен быть шестизначным");
            return;
        }

        // Получаем цифры через деление и остаток от деления
        int firstHalf = ticket / 1000;    // первые три цифры
        int secondHalf = ticket % 1000;   // последние три цифры

        // Суммируем цифры каждой половины
        int sum1 = SumOfDigits(firstHalf);
        int sum2 = SumOfDigits(secondHalf);

        Console.WriteLine(sum1 == sum2);
    }

    // Функция для вычисления суммы цифр трехзначного числа
    static int SumOfDigits(int number)
    {
        int digit1 = number / 100;           // первая цифра
        int digit2 = (number / 10) % 10;     // вторая цифра  
        int digit3 = number % 10;            // третья цифра

        return digit1 + digit2 + digit3;
    }
}