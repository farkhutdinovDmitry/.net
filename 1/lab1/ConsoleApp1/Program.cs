using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = Console.ReadLine();
            if (!DateTime.TryParse(date, out var enteredDate))
            {
                Console.WriteLine("Bad input");
                return;
            } 
            var current = new DateTime(enteredDate.Year, enteredDate.Month, 1);
           
            var workingDays = 0;
            Console.WriteLine("Mon Tue Wed Thu Fri Sat Sun");
            if (current.DayOfWeek != DayOfWeek.Monday)
            {
                makeOffsets(current.DayOfWeek);
            }
            while (current.Month == enteredDate.Month)
            {
                if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
                Console.Write($"{current.Day, -4}");
                if (current.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine();
                }
                current = current.AddDays(1);
            }
            Console.WriteLine("\nWorking days: {0}", workingDays);
            Console.ReadKey();
        }

        static void makeOffsets(DayOfWeek dayOfWeek)
        {
            DayOfWeek day = DayOfWeek.Monday;
            while (day.GetHashCode() != dayOfWeek.GetHashCode())
            {
                Console.Write("    ");
                if (day == DayOfWeek.Saturday) break;
                day++;
            }
        }
    }
}
