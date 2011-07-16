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
        private T value;

        public override object Value
        {
            get { return this.value; }
            set
            {
                if (value is string)
                {
                    this.value = (T) ParseString((string)value);
                }
                else
                {
                    this.value = (T)value;
                }
            }
        }

        public abstract object ParseString(string text);
    }
}
