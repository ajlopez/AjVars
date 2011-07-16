namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerVariable : Variable<int>
    {
        public IntegerVariable(int address, ByteMemory memory)
            : base(address, 4, memory)
        {
        }

        public override object ParseString(string text)
        {
            return Int32.Parse(text);
        }

        internal override byte[] ToBytes(int value)
        {
            byte[] bytes = new byte[4];
            bytes[0] = (byte)((value >> 24) & 0xff);
            bytes[1] = (byte)((value >> 16) & 0xff);
            bytes[2] = (byte)((value >> 8) & 0xff);
            bytes[3] = (byte)(value & 0xff);
            return bytes;
        }

        internal override int FromBytes(byte[] values)
        {
            int value = ((int)values[3]) | (((int)values[2]) << 8)
                | (((int)values[1]) << 16)
                | (((int)values[0]) << 24);

            return value;
        }
    }
}
