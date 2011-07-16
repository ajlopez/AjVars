namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ByteMemory
    {
        private byte[] bytes;

        public ByteMemory()
        {
            this.bytes = new byte[100];
        }

        public byte[] GetBytes(int address, int count)
        {
            byte[] result = new byte[count];
            for (int k = 0; k < count; k++)
                result[k] = this.bytes[k + address];
            return result;
        }
    }
}
