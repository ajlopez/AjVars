namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ShortVariable : Variable<short>
    {
        public ShortVariable(int address, ByteMemory memory)
            : base(address, 2, memory)
        {
        }

        public override object ParseString(string text)
        {
            return Int16.Parse(text);
        }

        protected override byte[] ToBytes(short value)
        {
            byte[] bytes = new byte[2];
            bytes[0] = (byte)((value >> 8) & 0xff);
            bytes[1] = (byte)(value & 0xff);
            return bytes;
        }

        protected override short FromBytes(byte[] values)
        {
            short value = (short)(((ushort)values[1]) | (((ushort)values[0]) << 8));
            return value;
        }
    }
}
