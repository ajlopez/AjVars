namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class TypeValue
    {
        public abstract object ParseString(string text);

        public abstract object FromMemory(ByteMemory memory, int address);

        public abstract void ToMemory(ByteMemory memory, int address, object obj);
    }
}
