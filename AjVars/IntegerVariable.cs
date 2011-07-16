namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerVariable : Variable<int>
    {
        public override object ParseString(string text)
        {
            return Int32.Parse(text);
        }
    }
}
