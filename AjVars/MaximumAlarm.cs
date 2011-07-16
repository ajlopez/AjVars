namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MaximumAlarm<T> : Alarm<T> where T : IComparable
    {
        public MaximumAlarm(Variable<T> variable, T value)
            : base(variable, (oldvalue, newvalue) => newvalue.CompareTo(value) > 0)
        {
        }
    }
}
