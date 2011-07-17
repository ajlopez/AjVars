namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Variable
    {
        private int address;
        private TypeValue typeValue;
        private ByteMemory memory;
        private object lastvalue;

        public static Variable MakeBitVariable(int address, ByteMemory memory)
        {
            return new Variable(address, BitTypeValue.Instance, memory);
        }

        public static Variable MakeShortVariable(int address, ByteMemory memory)
        {
            return new Variable(address, ShortTypeValue.Instance, memory);
        }

        public static Variable MakeIntegerVariable(int address, ByteMemory memory)
        {
            return new Variable(address, IntegerTypeValue.Instance, memory);
        }

        public Variable(int address, TypeValue typeValue, ByteMemory memory)
        {
            this.address = address;
            this.memory = memory;
            this.typeValue = typeValue;
            this.lastvalue = this.Value;
            this.memory.ChangedMemory += this.CheckNewValue;
        }

        public delegate void NewValueHandler(object oldvalue, object newvalue);

        public event NewValueHandler NewValue;

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

                this.lastvalue = newvalue;
            }
        }

        public TypeValue TypeValue
        {
            get
            {
                return this.typeValue;
            }

            set
            {
                this.typeValue = value;
                this.CheckNewValue();
            }
        }

        public int Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
                this.CheckNewValue();
            }
        }

        internal void RaiseNewValue(object oldvalue, object newvalue)
        {
            if (this.NewValue != null)
                this.NewValue(oldvalue, newvalue);
        }

        private void CheckNewValue()
        {
            object value = this.Value;

            if (!this.lastvalue.Equals(value))
            {
                this.RaiseNewValue(this.lastvalue, value);
                this.lastvalue = value;
            }
        }
    }
}
