using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество бактерий: ");
        int bacteria = int.Parse(Console.ReadLine());

        Console.Write("Введите количество антибиотика: ");
        int antibiotic = int.Parse(Console.ReadLine());

        Console.WriteLine(new string('*', 40));

        int hour = 1;

        while (bacteria > 0 && antibiotic > 0)
        {
            // Увеличение бактерий в 2 раза
            bacteria *= 2;

            // Действие антибиотика (убивает от 10 до 1 бактерий в зависимости от часа)
            int killPower = Math.Max(11 - hour, 1); // 10, 9, 8, ..., 1
            int bacteriaKilled = Math.Min(bacteria, killPower * antibiotic);
            bacteria -= bacteriaKilled;

            Console.WriteLine($"После {hour} часа бактерий осталось {bacteria}");

            // Уменьшаем эффективность антибиотика
            antibiotic = Math.Max(0, antibiotic - (bacteriaKilled / killPower));

            hour++;

            // Проверяем условия завершения
            if (bacteria <= 0 || antibiotic <= 0)
                break;
        }

        Console.WriteLine(new string('*', 40));
    }
}
