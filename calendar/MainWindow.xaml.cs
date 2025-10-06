using System;
using System.Collections.Generic;
using System.Globalization;

class UniversalCalendar
{
    // Словарь для хранения напоминаний (ключ – дата, значение – список напоминаний)
    static Dictionary<DateTime, List<string>> reminders = new Dictionary<DateTime, List<string>>();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // чтобы русские буквы отображались нормально

        while (true)
        {
            Console.WriteLine("\n===== ВЕЧНЫЙ КАЛЕНДАРЬ =====");
            Console.WriteLine("1. Определить день недели для введённой даты");
            Console.WriteLine("2. Показать календарь месяца");
            Console.WriteLine("3. Добавить напоминание к дате");
            Console.WriteLine("4. Вывести високосные года за период");
            Console.WriteLine("5. Найти количество дней между двумя датами");
            Console.WriteLine("0. Выйти");
            Console.Write("Выберите пункт меню: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DayOfWeekForDate();
                    break;
                case "2":
                    ShowMonthCalendar();
                    break;
                case "3":
                    AddReminder();
                    break;
                case "4":
                    ShowLeapYears();
                    break;
                case "5":
                    DaysBetweenDates();
                    break;
                case "0":
                    Console.WriteLine("Выход из программы...");
                    return;
                default:
                    Console.WriteLine("❌ Ошибка: введите число от 0 до 5!");
                    break;
            }
        }
    }

    // 1. Определение дня недели
    static void DayOfWeekForDate()
    {
        Console.Write("Введите дату (в формате дд.мм.гггг): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine($"📅 {date.ToShortDateString()} – это {date.ToString("dddd", new CultureInfo("ru-RU"))}");
        }
        else
        {
            Console.WriteLine("❌ Неверный формат даты!");
        }
    }

    // 2. Календарь месяца
    static void ShowMonthCalendar()
    {
        Console.Write("Введите год: ");
        int year = int.Parse(Console.ReadLine());

        Console.Write("Введите номер месяца (1-12): ");
        int month = int.Parse(Console.ReadLine());

        Console.WriteLine($"\nКалендарь: {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)} {year}");

        DateTime firstDay = new DateTime(year, month, 1);
        int daysInMonth = DateTime.DaysInMonth(year, month);

        // Вывод заголовков
        Console.WriteLine("Пн Вт Ср Чт Пт Сб Вс");

        int indent = ((int)firstDay.DayOfWeek + 6) % 7; // сдвиг (чтобы неделя начиналась с понедельника)

        for (int i = 0; i < indent; i++)
            Console.Write("   ");

        for (int day = 1; day <= daysInMonth; day++)
        {
            Console.Write($"{day,2} ");
            if ((day + indent) % 7 == 0)
                Console.WriteLine();
        }
        Console.WriteLine();
    }

    // 3. Добавить напоминание
    static void AddReminder()
    {
        Console.Write("Введите дату для напоминания (дд.мм.гггг): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.Write("Введите текст напоминания: ");
            string text = Console.ReadLine();

            if (!reminders.ContainsKey(date))
                reminders[date] = new List<string>();

            reminders[date].Add(text);

            Console.WriteLine($"✅ Напоминание добавлено на {date.ToShortDateString()}");

            // Вывод всех напоминаний для даты
            Console.WriteLine("Ваши напоминания:");
            foreach (var note in reminders[date])
                Console.WriteLine($" - {note}");
        }
        else
        {
            Console.WriteLine("❌ Неверный формат даты!");
        }
