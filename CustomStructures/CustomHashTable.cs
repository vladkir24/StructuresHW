using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures.Exceptions;

namespace CustomStructures
{
    public class CustomHashTable : ICustomHashTable
    {
        private const int DefaultSize = 100;
        private int size;
        private CustomLinkedList<CustomHashTableItem>[] hashArray;

        #region Constructors

        public CustomHashTable(int arraySize)
        {
            size = arraySize;
            hashArray = new CustomLinkedList<CustomHashTableItem>[size];
        }

        public CustomHashTable() : this(DefaultSize)
        {
            
        }
        #endregion

        private int Hash(object key)
        {
            int magicNumber = 13;
            return Math.Abs(magicNumber*key.GetHashCode())%size;
        }


        private CustomLinkedListNode<CustomHashTableItem> GetPreviousLinkedListItem(object key)
        {
            int index = Hash(key);
            CustomHashTableItem currentItem;
            var linkedList = hashArray[index];
            if (linkedList == null)
            {
                return null;
            }

            if (linkedList.Length < 2)
            {
                return null;
            }

            CustomLinkedListNode<CustomHashTableItem> previousNode = null;
            CustomLinkedListNode<CustomHashTableItem> currentNode = linkedList.First;

            bool isExit = false;
            while (!isExit)
            {
                if (currentNode.Value.Key.Equals(key))
                {
                    isExit = true;
                }
            }

            return null;
        }


        public bool Remove(object key)
        {
            int index = Hash(key);
            var linkedList = hashArray[index];

            if (linkedList == null)
            {
                return false;
            }

            CustomLinkedListNode<CustomHashTableItem> previousNode = null;
            CustomLinkedListNode<CustomHashTableItem> currentNode = linkedList.First;
                
            while (currentNode != null)
            {
                if (currentNode.Value.Key.Equals(key))
                {
                    linkedList.Remove(currentNode.Value);
                    return true;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }


        public bool Contains(object key)
        {
            object value = null;
            return TryGet(key, out value);
        }

        public void Add(object key, object value)
        {
            if (Contains(key))
            {
                throw new HashTableElementPresenceException(key);
            }
            
            int index = Hash(key);
            if (hashArray[index] == null)
            {
                hashArray[index] = new CustomLinkedList<CustomHashTableItem>();
                hashArray[index].Add(new CustomHashTableItem(key, value));
            }
            else
            {
                hashArray[index].Add(new CustomHashTableItem(key,value));
            }

        }

        public object this[object key]
        {
            get
            {
                object value = null;
                if (TryGet(key, out value))
                {
                    return value;
                }

                throw new HashTableElementAbsenceException(key);
            }
            set
            {

                if (value == null)
                {
                    if (Contains(key))
                    {
                        Remove(key);
                    }
                }
                else
                {
                    if (Contains(key))
                    {
                        Remove(key);
                        Add(key,value);
                    }
                    else
                    {
                        throw new HashTableElementAbsenceException(key);
                    }
                }
            }
        }

        public bool TryGet(object key, out object value)
        {
            int index = Hash(key);
            if (hashArray[index] != null)
            {
                foreach (CustomHashTableItem item in hashArray[index])
                {
                    if (item.Key.Equals(key))
                    {
                        value = item.Value;
                        return true;
                    }
                }
            }

            value = null;
            return false;
        }
    }
}
