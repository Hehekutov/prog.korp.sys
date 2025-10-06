using System;

class CoffeeMachine
{
    static void Main()
    {
        // Ввод начальных ингредиентов
        Console.Write("Введите количество воды в мл: ");
        int water = int.Parse(Console.ReadLine());

        Console.Write("Введите количество молока в мл: ");
        int milk = int.Parse(Console.ReadLine());

        // Счетчики для отчетности
        int americanoCount = 0;
        int latteCount = 0;
        int totalRevenue = 0;

        // Константы для напитков
        const int AMERICANO_WATER = 300;
        const int AMERICANO_PRICE = 150;

        const int LATTE_WATER = 30;
        const int LATTE_MILK = 270;
        const int LATTE_PRICE = 170;

        Console.WriteLine("\nКофейный аппарат готов к работе!");
        Console.WriteLine("================================\n");

        // Основной цикл обслуживания
        while (true)
        {
            // Проверяем, можно ли приготовить хотя бы один напиток
            bool canMakeAmericano = water >= AMERICANO_WATER;
            bool canMakeLatte = water >= LATTE_WATER && milk >= LATTE_MILK;

            if (!canMakeAmericano && !canMakeLatte)
            {
                Console.WriteLine("\nИнгредиенты подошли к концу!");
                break;
            }

            // Запрос выбора напитка
            Console.Write("Выберите напиток (1 — американо, 2 — латте): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Американо
                    if (water >= AMERICANO_WATER)
                    {
                        water -= AMERICANO_WATER;
                        americanoCount++;
                        totalRevenue += AMERICANO_PRICE;
                        Console.WriteLine("Ваш напиток готов.\n");
                    }
                    else
                    {
                        Console.WriteLine("Не хватает воды.\n");
                    }
                    break;

                case "2": // Латте
                    if (water >= LATTE_WATER && milk >= LATTE_MILK)
                    {
                        water -= LATTE_WATER;
                        milk -= LATTE_MILK;
                        latteCount++;
                        totalRevenue += LATTE_PRICE;
                        Console.WriteLine("Ваш напиток готов.\n");
                    }
                    else if (water < LATTE_WATER)
                    {
                        Console.WriteLine("Не хватает воды.\n");
                    }
                    else
                    {
                        Console.WriteLine("Не хватает молока.\n");
                    }
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите 1 или 2.\n");
                    break;
            }
        }

        // Вывод отчета
        PrintReport(water, milk, americanoCount, latteCount, totalRevenue);
    }

    static void PrintReport(int waterLeft, int milkLeft, int americanoCount, int latteCount, int revenue)
    {
        Console.WriteLine("\n" + new string('*', 40));
        Console.WriteLine("ОТЧЕТ");
        Console.WriteLine(new string('*', 40));
        Console.WriteLine("Ингредиентов осталось:");
        Console.WriteLine($"Вода: {waterLeft} мл");
        Console.WriteLine($"Молоко: {milkLeft} мл");
        Console.WriteLine($"Кружек американо приготовлено: {americanoCount}");
        Console.WriteLine($"Кружек латте приготовлено: {latteCount}");
        Console.WriteLine($"Итого: {revenue} рублей.");
        Console.WriteLine(new string('*', 40));
    }
}