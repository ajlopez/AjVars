namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class BytesTypeValue : TypeValue
    {
        public abstract short Size { get; }

        public override object FromMemory(ByteMemory memory, int address)
        {
            return this.FromBytes(memory.GetBytes(address, this.Size));
        }

        public override void ToMemory(ByteMemory memory, int address, object obj)
        {
            memory.SetBytes(address, this.ToBytes(obj));
        }

        public abstract byte[] ToBytes(object obj);

        public abstract object FromBytes(byte[] bytes);
    }
}
