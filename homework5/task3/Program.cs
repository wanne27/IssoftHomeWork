using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Holiday holiday = new Holiday("Ilya", new DateTime(year: 2020, month: 3, day: 2), new DateTime(year: 2020, month: 3, day: 4));
            Holiday holiday1 = new Holiday("Misha", new DateTime(year: 2020, month: 3, day: 2), new DateTime(year: 2020, month: 3, day: 6));
            Holiday holiday2 = new Holiday("Misha", new DateTime(year: 2020, month: 8, day: 1), new DateTime(year: 2020, month: 8, day: 14));
            Holiday holiday3 = new Holiday("Ignar", new DateTime(year: 2020, month: 1, day: 4), new DateTime(year: 2020, month: 2, day: 5));
            Holiday holiday4 = new Holiday("Alex", new DateTime(year: 2020, month: 9, day: 8), new DateTime(year: 2020, month: 11, day: 1));
            List<Holiday> list = new List<Holiday>();
            list.Add(holiday);
            list.Add(holiday1);
            list.Add(holiday2);
            list.Add(holiday3);
            list.Add(holiday4);

            Console.WriteLine(AverageHoliday(list));
            Console.WriteLine(IsCorrect(list));

            foreach (var item in AveragePersonHoliday(list))
            {
                Console.WriteLine(item);
            }

            foreach (var item in CountPersonInMonth(list))
            {
                Console.WriteLine(item);
            }

            foreach (var item in DaysWithOutHoliday(list))
            {
                Console.WriteLine(item);
            }

            int AverageHoliday(List<Holiday> list)
            {
                var avg = list.Select(x => (x.lastDay - x.firstDay).Days).Average();

                return (int)avg;
            }

            IEnumerable AveragePersonHoliday(List<Holiday> list)
            {
                var avg = list.GroupBy(names => names.name)
                    .Select(x => new { name = x.Key, avg = x.Select(p => (p.lastDay - p.firstDay).Days).Average() });

                return avg;
            }

            IEnumerable CountPersonInMonth(List<Holiday> list)
            {
                List<(int, int)> countInMonth = new List<(int, int)>();

                for (int i = 0; i < 12; i++)
                {
                    var buf = list.Where(x => x.firstDay.Month == i || x.lastDay.Month == i);

                    foreach (var k in buf)
                    {
                        countInMonth.Add((i, buf.Count()));
                    }
                }

                return countInMonth;
            }

            IEnumerable DaysWithOutHoliday(List<Holiday> list)
            {
                List<DateTime> dates = new List<DateTime>();
                DateTime start = new DateTime(2020, 1, 1);
                DateTime fin = new DateTime(2020, 12, 31);

                for (; start < fin; start = start.AddDays(1))
                {
                    var withHolidaysDates = list.Where(x => x.firstDay <= start && x.lastDay >= start).Select(x => x);

                    if (withHolidaysDates.Count() == 0)
                        dates.Add(start); 
                }

                return dates;
            }

            bool IsCorrect(List<Holiday> list)
            {
                var all = list.Select(x => x);
                foreach (var item in all)
                {
                    var correct = list.Where(t => t.name == item.name && (t.firstDay >= item.firstDay && t.firstDay <= item.lastDay)
                    || t.lastDay <= item.lastDay && t.lastDay >= item.firstDay
                    || (t.firstDay <= item.firstDay && t.lastDay >= item.lastDay));
                    if (correct.Count() == 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }           
        
    }
}
