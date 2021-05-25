using System;
using System.Collections.Generic;
using System.Text;

namespace homework7
{
    [TrackingEntity]
    class Test
    {
        [TrackingProperty(PropertyName = "Feild name")]
        public string _name;
        [TrackingProperty(PropertyName = "Feild age")]
        public int _age;

        [TrackingProperty()]
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        [TrackingProperty(PropertyName = "Property Age")]
        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public Test(string name, int age)
        {
            Age = age;
            Name = name;
        }

        public Test()
        {
            Age = 0;
            Name = "";
        }
    }
}
