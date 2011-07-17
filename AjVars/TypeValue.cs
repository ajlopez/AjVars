namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class TypeValue
    {
        public abstract object ParseString(string text);

        public abstract byte[] ToBytes(object obj);

        public abstract object FromBytes(byte[] obj);
    }
}
