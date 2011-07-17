namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerTypeValue : TypeValue
    {
        public override object ParseString(string text)
        {
            return Int32.Parse(text);
        }

        public override byte[] ToBytes(object obj)
        {
            int value = (int)obj;
            byte[] bytes = new byte[4];
            bytes[0] = (byte)((value >> 24) & 0xff);
            bytes[1] = (byte)((value >> 16) & 0xff);
            bytes[2] = (byte)((value >> 8) & 0xff);
            bytes[3] = (byte)(value & 0xff);
            return bytes;
        }

        public override object FromBytes(byte[] bytes)
        {
            int value = ((int)bytes[3]) | (((int)bytes[2]) << 8)
                | (((int)bytes[1]) << 16)
                | (((int)bytes[0]) << 24);

            return value;
        }
    }
}
