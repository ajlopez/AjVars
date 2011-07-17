namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShortTypeValue : BytesTypeValue
    {
        private static ShortTypeValue instance = new ShortTypeValue();

        private ShortTypeValue()
        {
        }

        public static ShortTypeValue Instance { get { return instance; } }

        public override short Size { get { return 2; } }

        public override object ParseString(string text)
        {
            return Int16.Parse(text);
        }

        public override byte[] ToBytes(object obj)
        {
            short value = (short)obj;
            byte[] bytes = new byte[this.Size];
            bytes[0] = (byte)((value >> 8) & 0xff);
            bytes[1] = (byte)(value & 0xff);
            return bytes;
        }

        public override object FromBytes(byte[] bytes)
        {
            short value = (short)(((ushort)bytes[1]) | (((ushort)bytes[0]) << 8));
            return value;
        }
    }
}
