using System;
using System.Collections.Generic;
using System.Text;

namespace homework7
{
    [AttributeUsage(AttributeTargets.Property|
        AttributeTargets.Field)]
    public class TrackingPropertyAttribute : Attribute
    {
       public string PropertyName { get; set; }
    }
}
