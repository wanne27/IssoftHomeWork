using System;
using System.Collections.Generic;
using System.Text;

namespace homework7
{
    [AttributeUsage(AttributeTargets.Class |
        AttributeTargets.Struct)]
    public class TrackingEntityAttribute : Attribute
    {
    }
}
