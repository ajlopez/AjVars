namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ByteMemory
    {
        private const int defaultSize = 100;
        private byte[] bytes;

        public ByteMemory()
            : this(defaultSize)
        {
        }

        public ByteMemory(int size)
        {
            this.bytes = new byte[size];
        }

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
    }
}
