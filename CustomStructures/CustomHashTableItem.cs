using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    class CustomHashTableItem
    {
        public object Key { get; private set; }
        public object Value { get; private set; }

        public CustomHashTableItem(object key, object value)
        {
            Key   = key;
            Value = value;
        }
    }
}
