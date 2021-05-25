using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Task3
{
    public static class JsonHelper
    {
        public static List<Data> UnloadJsonData()
        {
            List<Data> listOfdata = new List<Data>();

            using (var reader = new StreamReader(@"D:\issoft\homework6\Task3\data.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    Data data = new Data(values[0], (DateTime.ParseExact(values[1], "M/d/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(values[2], "M/d/yyyy", CultureInfo.InvariantCulture)));
                    listOfdata.Add(data);
                }
            }

            return listOfdata;
        }

        public static List<Data> SelectVacation(List<Data> listOfData)
        {
            DateTime startSecondHalfYear = new DateTime(2016, 7, 1);
            DateTime finishSecondHalfYear = new DateTime(2016, 12, 31);

            List<Data> datas = new List<Data>();

            var myList = listOfData
                .Where(d => d.VacationsStart >= startSecondHalfYear && d.VacationsEnd <= finishSecondHalfYear)
                .GroupBy(n => n.Name)
                .Select(n => new
                {
                    Name = n.Key,
                    VacationList = n.ToList()
                });
            
            foreach (var item in myList)
            {
                List<(DateTime, DateTime)> turpl = new List<(DateTime, DateTime)>();

                foreach (var a in item.VacationList)
                {
                    foreach(var x in a.vacationList)
                    {
                        turpl.Add(x);
                    }
                }

                datas.Add(new Data(item.Name, turpl));
            }

            return datas;
        }

        public static void SaveJson(List<Data> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(@"D:\issoft\homework6\Task3\person.json", json);
        }
    }
}
