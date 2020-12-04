using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Helper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IsViewable : Attribute
    {
        public bool Value { get; set; }
    }
}
