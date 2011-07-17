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
                return this.typeValue.FromBytes(this.GetBytesFromMemory());
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
                    this.SetBytesToMemory(this.typeValue.ToBytes(newvalue));
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

        internal byte[] GetBytesFromMemory()
        {
            return this.memory.GetBytes(this.address, this.typeValue.Size);
        }

        internal void SetBytesToMemory(byte[] values)
        {
            this.memory.SetBytes(this.address, values);
        }
    }
}
