namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Alarm
    {
        private Variable variable;
        private Func<object, object, bool> condition;

        public Alarm(Variable variable, Func<object, object, bool> condition)
        {
            this.variable = variable;
            this.condition = condition;

            this.variable.NewValue += this.NewValue;
        }

        public delegate void AlarmHandler(object oldvalue, object newvalue);

        public event AlarmHandler NewAlarm;

        public void RaiseNewAlarm(object oldvalue, object newvalue)
        {
            if (this.NewAlarm != null)
                this.NewAlarm(oldvalue, newvalue);
        }

        private void NewValue(object oldvalue, object newvalue)
        {
            if (this.condition(oldvalue, newvalue))
                this.RaiseNewAlarm(oldvalue, newvalue);
        }
    }
}
