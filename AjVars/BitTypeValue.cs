namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BitTypeValue : TypeValue
    {
        private static BitTypeValue instance = new BitTypeValue();

        private BitTypeValue()
        {
        }

        public static BitTypeValue Instance { get { return instance; } }

        public override object FromMemory(ByteMemory memory, int address)
        {
            return memory.GetBit(address);
        }

        public override void ToMemory(ByteMemory memory, int address, object obj)
        {
            memory.SetBit(address, (bool)obj);
        }

        public override object ParseString(string text)
        {
            if ("0".Equals(text))
                return false;

            if ("1".Equals(text))
                return true;

            return Boolean.Parse(text);
        }
    }
}
