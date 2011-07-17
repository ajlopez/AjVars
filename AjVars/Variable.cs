namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Variable
    {
        private int address;
        private TypeValue typeValue;
        private ByteMemory memory;

        public Variable(int address, TypeValue typeValue, ByteMemory memory)
        {
            this.address = address;
            this.memory = memory;
            this.typeValue = typeValue;
        }

        public object Value
        {
            get
            {
                return this.typeValue.FromMemory(this.memory, this.address);
            }

            set
            {
                object newvalue;

                if (value is string)
                {
                    newvalue = this.typeValue.ParseString((string)value);
                }
                else
                {
                    newvalue = value;
                }

                object oldvalue = this.Value;

                if (!newvalue.Equals(oldvalue))
                {
                    this.typeValue.ToMemory(this.memory, this.address, newvalue);
                    this.RaiseNewValue(oldvalue, newvalue);
                }
            }
        }

        public delegate void NewValueHandler(object oldvalue, object newvalue);

        public event NewValueHandler NewValue;

        internal void RaiseNewValue(object oldvalue, object newvalue)
        {
            if (this.NewValue != null)
                this.NewValue(oldvalue, newvalue);
        }
    }
}
