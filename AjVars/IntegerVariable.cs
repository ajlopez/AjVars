namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerVariable : Variable
    {
        public IntegerVariable(int address, ByteMemory memory)
            : base(address, IntegerTypeValue.Instance, memory)
        {
        }
    }
}
