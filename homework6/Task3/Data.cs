using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Task3
{
    public class Data
    {
        private string name;
        private DateTime vacationsStart;
        private DateTime vacationsEnd;

        public string Name { get => name; set { name = value; } }       
        public List<(DateTime, DateTime)> vacationList  { get;set; }

        [JsonIgnore]
        public DateTime VacationsStart { get => vacationsStart; set { vacationsStart = value;} }
        [JsonIgnore]
        public DateTime VacationsEnd { get => vacationsEnd; set { vacationsEnd = value;} }
        
        
        public Data(string name, DateTime start, DateTime end)
        {
            Name = name;
            VacationsStart = start;
            VacationsEnd = end;
        }

        public Data(string name, (DateTime,DateTime) dateTimes)
        {
            Name = name;
            VacationsStart = dateTimes.Item1;
            VacationsEnd = dateTimes.Item2;
            vacationList =  new List<(DateTime, DateTime)>();
            vacationList.Add(dateTimes);
        }

        public Data(string name, List<(DateTime, DateTime)> vac)
        {
            Name = name;
            vacationList = vac;
        }
    }
}
