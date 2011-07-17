namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerTypeValue : TypeValue
    {
        public override object ParseString(string text)
        {
            throw new NotImplementedException();
        }

        public override byte[] ToBytes(object value)
        {
            throw new NotImplementedException();
        }

        public override object FromBytes(byte[] values)
        {
            throw new NotImplementedException();
        }
    }
}
