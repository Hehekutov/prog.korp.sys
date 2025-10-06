using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Введите a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите b: ");
        int b = int.Parse(Console.ReadLine());

        Console.Write("Введите w: ");
        int w = int.Parse(Console.ReadLine());

        Console.Write("Введите h: ");
        int h = int.Parse(Console.ReadLine());

        int maxD = FindMaxProtectionThickness(n, a, b, w, h);

        Console.WriteLine($"Ответ d = {maxD}");
    }

    static int FindMaxProtectionThickness(int n, int a, int b, int w, int h)
    {
        int left = 0;
        int right = Math.Min(w, h); // Максимально возможная толщина защиты

        int maxD = 0;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            // Размер модуля с защитой
            int moduleWidth = a + 2 * mid;
            int moduleHeight = b + 2 * mid;

            // Проверяем, помещаются ли модули на поле в двух ориентациях
            int count1 = CalculateMaxModules(w, h, moduleWidth, moduleHeight);
            int count2 = CalculateMaxModules(w, h, moduleHeight, moduleWidth);

            if (count1 >= n || count2 >= n)
            {
                // Модули помещаются, пробуем увеличить толщину защиты
                maxD = mid;
                left = mid + 1;
            }
            else
            {
                // Модули не помещаются, уменьшаем толщину защиты
                right = mid - 1;
            }
        }

        return maxD;
    }

    static int CalculateMaxModules(int fieldWidth, int fieldHeight, int moduleWidth, int moduleHeight)
    {
        if (moduleWidth > fieldWidth || moduleHeight > fieldHeight)
            return 0;

        int modulesInRow = fieldWidth / moduleWidth;
        int modulesInColumn = fieldHeight / moduleHeight;

        return modulesInRow * modulesInColumn;
    }
}