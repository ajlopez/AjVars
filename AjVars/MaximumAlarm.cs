namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MaximumAlarm : Alarm 
    {
        public MaximumAlarm(Variable variable, object value)
            : base(variable, val => ((IComparable)val).CompareTo(value) > 0)
        {
        }
    }
}
