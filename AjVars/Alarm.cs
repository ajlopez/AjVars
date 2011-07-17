namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Alarm
    {
        private Variable variable;
        private Func<object, bool> condition;

        public Alarm(Variable variable, Func<object, bool> condition)
        {
            this.variable = variable;
            this.condition = condition;

            this.variable.NewValue += this.NewValue;
        }

        public delegate void AlarmHandler(object oldvalue, object newvalue);

        public event AlarmHandler StartAlarm;

        public event AlarmHandler StopAlarm;

        public void RaiseStartAlarm(object oldvalue, object newvalue)
        {
            if (this.StartAlarm != null)
                this.StartAlarm(oldvalue, newvalue);
        }

        public void RaiseStopAlarm(object oldvalue, object newvalue)
        {
            if (this.StopAlarm != null)
                this.StopAlarm(oldvalue, newvalue);
        }

        private void NewValue(object oldvalue, object newvalue)
        {
            if (!this.condition(oldvalue) && this.condition(newvalue))
                this.RaiseStartAlarm(oldvalue, newvalue);
            else if (this.condition(oldvalue) && !this.condition(newvalue))
                this.RaiseStopAlarm(oldvalue, newvalue);
        }
    }
}
