namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class BitVariable : Variable
    {
        public BitVariable(int address, ByteMemory memory)
            : base(address, BitTypeValue.Instance, memory)
        {
        }
    }
}
