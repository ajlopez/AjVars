namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerVariable : Variable<int>
    {
        private int value;

        public override object Value
        {
            get { return this.value; }
            set
            {
                if (value is string)
                {
                    this.value = Int32.Parse((string) value);
                }
                else
                {
                    this.value = (int)value;
                }
            }
        }
    }
}
