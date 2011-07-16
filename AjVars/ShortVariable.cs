namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShortVariable : Variable<short>
    {
        private short value;

        public override object Value
        {
            get { return this.value; }
            set
            {
                if (value is string)
                {
                    this.value = Int16.Parse((string) value);
                }
                else
                {
                    this.value = (short)value;
                }
            }
        }
    }
}
