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
        ByteMemory memory;

        public Variable(int address, int count, ByteMemory memory)
        {
            this.address = address;
            this.memory = memory;
            this.count = count;
        }

        public abstract object Value { get; set; }

        protected byte[] GetBytesFromMemory()
        {
            return this.memory.GetBytes(this.address, this.count);
        }

        protected void SetBytesToMemory(byte[] values)
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
            get { return this.FromBytes(this.GetBytesFromMemory()); }
            set
            {
                T newvalue;

                if (value is string)
                {
                    newvalue = (T)ParseString((string)value);
                }
                else
                {
                    newvalue = (T)value;
                }

                this.SetBytesToMemory(this.ToBytes(newvalue));
            }
        }

        public abstract object ParseString(string text);

        protected abstract byte[] ToBytes(T value);

        protected abstract T FromBytes(byte[] values);
    }
}
