using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    public class CustomLinkedListNode<T>
    {
        public T Value { get; set; }
        public CustomLinkedListNode<T> Next { get; set; }

        public CustomLinkedListNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
            Value = value;
        }

    }
}
