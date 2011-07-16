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
        private Variable<int> integerVariable;

        [TestInitialize]
        public void Setup()
        {
            this.integerVariable = new IntegerVariable(0, new ByteMemory());
        }

        [TestMethod]
        public void RaiseAlarm()
        {
            int count = 0;
            this.integerVariable.Value = 20;
            Alarm alarm = new Alarm<int>(this.integerVariable, (oldvalue, newvalue) => newvalue == 30);
            alarm.NewAlarm += (oldvalue, newvalue) => count++;
            this.integerVariable.Value = 30;
            Assert.AreEqual(1, count);
        }
    }
}
