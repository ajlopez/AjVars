namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MinimumAlarm : Alarm
    {
        public MinimumAlarm(Variable variable, object value)
            : base(variable, (oldvalue, newvalue) => ((IComparable) newvalue).CompareTo(value) < 0)
        {
        }
    }
}
