namespace AjVars.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AlarmTests
    {
        private Variable integerVariable;

        [TestInitialize]
        public void Setup()
        {
            this.integerVariable = new IntegerVariable(0, new ByteMemory());
        }

        [TestMethod]
        public void TriggerStartAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 20;
            Alarm alarm = new Alarm(this.integerVariable, value => ((int) value) == 30);
            alarm.StartAlarm += (oldvalue, newvalue) => count++;
            this.integerVariable.Value = 30;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerNoStartAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 20;
            Alarm alarm = new Alarm(this.integerVariable, value => (int) value == 30);
            alarm.StartAlarm += (oldvalue, newvalue) => count++;

            for (int k = 1; k <= 100; k++)
                if (k != 30)
                    this.integerVariable.Value = k;

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void TriggerStartMinimumAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 20;
            
            MinimumAlarm alarm = new MinimumAlarm(this.integerVariable, 10);
            alarm.StartAlarm += (oldvalue, newvalue) => count++;

            this.integerVariable.Value = 5;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerStartAlarmOnlyWhenChangeCondition()
        {
            int count = 0;
            this.integerVariable.Value = 20;

            MinimumAlarm alarm = new MinimumAlarm(this.integerVariable, 10);
            alarm.StartAlarm += (oldvalue, newvalue) => count++;

            this.integerVariable.Value = 5;
            this.integerVariable.Value = 4;
            this.integerVariable.Value = 3;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerStartMaximumAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 20;

            MaximumAlarm alarm = new MaximumAlarm(this.integerVariable, 30);
            alarm.StartAlarm += (oldvalue, newvalue) => count++;

            this.integerVariable.Value = 45;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerStartMaximumAlarmOnlyOnce()
        {
            int count = 0;
            this.integerVariable.Value = 20;

            MaximumAlarm alarm = new MaximumAlarm(this.integerVariable, 40);
            alarm.StartAlarm += (oldvalue, newvalue) => count++;

            this.integerVariable.Value = 45;
            this.integerVariable.Value = 44;
            this.integerVariable.Value = 43;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerStopAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 30;
            Alarm alarm = new Alarm(this.integerVariable, value => ((int)value) == 30);
            alarm.StopAlarm += (oldvalue, newvalue) => count++;
            this.integerVariable.Value = 20;
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerNoStopAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 0;
            Alarm alarm = new Alarm(this.integerVariable, value => (int)value != 30);
            alarm.StopAlarm += (oldvalue, newvalue) => count++;

            for (int k = 1; k <= 100; k++)
                if (k != 30)
                    this.integerVariable.Value = k;

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void TriggerStopMinimumAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 10;

            MinimumAlarm alarm = new MinimumAlarm(this.integerVariable, 20);
            alarm.StopAlarm += (oldvalue, newvalue) => count++;

            this.integerVariable.Value = 25;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerStopAlarmOnlyWhenChangeCondition()
        {
            int count = 0;
            this.integerVariable.Value = 8;

            MinimumAlarm alarm = new MinimumAlarm(this.integerVariable, 10);
            alarm.StopAlarm += (oldvalue, newvalue) => count++;

            this.integerVariable.Value = 15;
            this.integerVariable.Value = 14;
            this.integerVariable.Value = 13;

            Assert.AreEqual(1, count);
        }
    }
}
