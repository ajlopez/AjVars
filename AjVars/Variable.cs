namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Variable
    {
        private int address;
        private int count;
        private ByteMemory memory;

        public Variable(int address, int count, ByteMemory memory)
        {
            this.address = address;
            this.memory = memory;
            this.count = count;
        }

        public abstract object Value { get; set; }

        public int Size { get { return this.count; } }

        public delegate void NewValueHandler(object oldvalue, object newvalue);

        public event NewValueHandler NewValue;

        internal void RaiseNewValue(object oldvalue, object newvalue)
        {
            if (this.NewValue != null)
                this.NewValue(oldvalue, newvalue);
        }

        internal byte[] GetBytesFromMemory()
        {
            return this.memory.GetBytes(this.address, this.count);
        }

        internal void SetBytesToMemory(byte[] values)
        {
            this.memory.SetBytes(this.address, values);
        }
    }

    public abstract class Variable<T> : Variable 
    {
        public Variable(int address, int count, ByteMemory memory)
            : base(address, count, memory)
        {
        }

        public override object Value
        {
            get 
            { 
                return this.FromBytes(this.GetBytesFromMemory());
            }

            set
            {
                T newvalue;

                if (value is string)
                {
                    newvalue = (T)this.ParseString((string)value);
                }
                else
                {
                    newvalue = (T)value;
                }

                T oldvalue = (T)this.Value;

                if (!newvalue.Equals(oldvalue))
                {
                    this.SetBytesToMemory(this.ToBytes(newvalue));
                    this.RaiseNewValue(oldvalue, newvalue);
                }
            }
        }

        public abstract object ParseString(string text);

        internal abstract byte[] ToBytes(T value);

        internal abstract T FromBytes(byte[] values);
    }
}
