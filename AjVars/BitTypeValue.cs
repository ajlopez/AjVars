namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BitTypeValue : TypeValue
    {
        public override short Size
        {
            get { throw new NotImplementedException(); }
        }

        public override object FromMemory(ByteMemory memory, int address)
        {
            throw new NotImplementedException();
        }

        public override void ToMemory(ByteMemory memory, int address, object obj)
        {
            throw new NotImplementedException();
        }

        public override object ParseString(string text)
        {
            if ("0".Equals(text))
                return false;

            if ("1".Equals(text))
                return true;

            return Boolean.Parse(text);
        }

        public override byte[] ToBytes(object obj)
        {
            throw new NotImplementedException();
        }

        public override object FromBytes(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
