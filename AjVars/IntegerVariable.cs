﻿namespace AjVars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class IntegerVariable : Variable
    {
        public override object Value
        {
            get
            {
                return 0;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}