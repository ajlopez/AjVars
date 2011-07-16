namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Variable
    {
        public abstract object Value { get; set; }
    }

    public abstract class Variable<T> : Variable
    {
    }
}
