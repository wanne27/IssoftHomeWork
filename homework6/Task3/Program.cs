using System;
using System.Collections.Generic;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Data> list = JsonHelper.UnloadJsonData();
            List<Data> list2 = JsonHelper.SelectVacation(list);
            JsonHelper.SaveJson(list2);
            foreach(var item in list2)
            {
                Console.WriteLine(item.Name);
                Console.Write(item.vacationList.Count);
            }
        }
    }
}
