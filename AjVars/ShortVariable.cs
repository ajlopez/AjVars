namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ShortVariable : Variable<short>
    {
        public override object ParseString(string text)
        {
            return Int16.Parse(text);
        }
    }
}
