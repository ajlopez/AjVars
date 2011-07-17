namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ByteMemory
    {
        private const int DefaultSize = 100;
        private byte[] bytes;

        public ByteMemory()
            : this(DefaultSize)
        {
        }

        public ByteMemory(int size)
        {
            this.bytes = new byte[size];
        }

        public delegate void MemoryHandler();

        public event MemoryHandler ChangedMemory;

        public byte[] GetBytes(int address, int count)
        {
            byte[] result = new byte[count];

            for (int k = 0; k < count; k++)
                result[k] = this.bytes[k + address];

            return result;
        }

        public void SetBytes(int address, byte[] values)
        {
            for (int k = 0; k < values.Length; k++)
                this.bytes[address + k] = values[k];
        }

        public void NewValues(int address, byte[] newvalues)
        {
            bool changed = false;

            for (int k = 0; k < newvalues.Length; k++)
                if (this.bytes[address + k] != newvalues[k])
                {
                    this.bytes[address + k] = newvalues[k];
                    changed = true;
                }

            if (changed && this.ChangedMemory != null)
                this.ChangedMemory();
        }
    }
}
