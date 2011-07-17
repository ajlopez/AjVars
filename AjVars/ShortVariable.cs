namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class ShortVariable : Variable
    {
        public ShortVariable(int address, ByteMemory memory)
            : base(address, new ShortTypeValue(), memory)
        {
        }
    }
}
