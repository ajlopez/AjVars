namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Alarm
    {
        public delegate void AlarmHandler(object oldvalue, object newvalue);

        public event AlarmHandler NewAlarm;

        public void RaiseNewAlarm(object oldvalue, object newvalue)
        {
            if (this.NewAlarm != null)
                this.NewAlarm(oldvalue, newvalue);
        }
    }

    public class Alarm<T> : Alarm
    {
        private Variable<T> variable;
        private Func<T, T, bool> condition;

        public Alarm(Variable<T> variable, Func<T, T, bool> condition)
        {
            this.variable = variable;
            this.condition = condition;

            this.variable.NewValue += this.NewValue;
        }

        private void NewValue(object oldvalue, object newvalue)
        {
            if (this.condition((T) oldvalue, (T) newvalue))
                this.RaiseNewAlarm(oldvalue, newvalue);
        }
    }
}
