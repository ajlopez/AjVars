namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BitTypeValue : TypeValue
    {
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
