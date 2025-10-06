using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Загадайте число от 0 до 63.");
        Console.WriteLine("На вопросы отвечайте: 1 - да, 0 - нет");
        Console.WriteLine("======================================");

        int low = 0;
        int high = 63;
        int attempts = 0;

        while (low <= high && attempts < 7)
        {
            int mid = (low + high) / 2;
            attempts++;

            if (low == high)
            {
                Console.WriteLine($"\nВаше число: {low}!");
                return;
            }

            Console.Write($"\nВопрос {attempts}: Ваше число больше {mid}? (1-да, 0-нет): ");

            int answer;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out answer) && (answer == 0 || answer == 1))
                    break;
                Console.Write("Пожалуйста, введите 1 (да) или 0 (нет): ");
            }

            if (answer == 1)
            {
                low = mid + 1; // Число больше mid
            }
            else
            {
                high = mid; // Число меньше или равно mid
            }
        }

        // После 7 вопросов у нас должен остаться 1 вариант
        Console.WriteLine($"\nВаше число: {low}!");
    }
}