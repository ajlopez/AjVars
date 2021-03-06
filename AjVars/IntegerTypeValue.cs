﻿namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerTypeValue : BytesTypeValue
    {
        private static IntegerTypeValue instance = new IntegerTypeValue();

        private IntegerTypeValue()
        {
        }

        public static IntegerTypeValue Instance { get { return instance; } }

        public override short Size { get { return 4; } }

        public override object ParseString(string text)
        {
            return Int32.Parse(text);
        }

        public override byte[] ToBytes(object obj)
        {
            int value = (int)obj;
            byte[] bytes = new byte[this.Size];
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
