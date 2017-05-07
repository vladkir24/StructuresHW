using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures
{
    interface ICustomLinkedList<T>
    {
        int Length { get; }
        void Add(T value);
        void AddAt(T value, int index);

        bool Remove(T value);
        bool RemoveAt(int index);
        T ElementAt(int index);
    }
}
