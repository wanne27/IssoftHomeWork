using System;
using System.Collections.Generic;
using System.Text;

namespace task3
{
    class Holiday
    {
        public readonly string name;
        public readonly DateTime firstDay;
        public readonly DateTime lastDay;

        public Holiday(string name, DateTime firstDay, DateTime lastDay)
        {
            if (name == null || name.Length == 0)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.name = name;
            this.firstDay = firstDay;
            this.lastDay = lastDay;
        }

    }
}
