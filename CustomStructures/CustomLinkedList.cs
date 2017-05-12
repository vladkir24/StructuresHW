using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CustomStructures
{
    public class CustomLinkedList<T> : ICustomLinkedList<T>, IEnumerable
    {
        public CustomLinkedListNode<T> First { get; set; }
        public CustomLinkedListNode<T> Last { get; set; }

        public int Length { get; private set; }

        public void Add(T value)
        {
            var listNode = new CustomLinkedListNode<T>(value);

            if (First == null)
            {
                First = listNode;
                Last = listNode;
                Length = 1;
            }
            else  //add to end of list
            {
                Last.Next = listNode;
                Last = listNode;
                Length ++;
            }
        }

        public void AddAt(T value, int index)
        {
            if (index < 0 || (index + 1) > Length)
            {
                throw new ArgumentException("Incorrect index " + index);
            }

            var newNode = new CustomLinkedListNode<T>(value);

            if (index == 0)
            {
                newNode.Next = First;
                First = newNode;
                Length++;
                return;
            }

            if (index == (Length - 1))
            {
                Last.Next = newNode;
                Length++;
                return;
            }

            var previousNode = First;
            for (int i = 1; i < index; i++)
            {
                previousNode = previousNode.Next;
            }

            newNode.Next = previousNode.Next;
            previousNode.Next = newNode;
            Length++;
        }

        public bool Remove(T value)
        {
            bool result = false; 
            if (Length == 0)
            {
                return result;
            }

            if (Length == 1)
            {
                First = null;
                Length--;
                return true;
            }

            CustomLinkedListNode<T> previousNode = null;
            CustomLinkedListNode<T> currentNode = First;
            bool isExit = false;
            while (currentNode != null && !isExit)
            {
                if (currentNode.Value.Equals(value))
                {
                    if (previousNode != null)
                    {
                        previousNode.Next = currentNode.Next;
                        if (currentNode.Next == null)
                        {
                            Last = previousNode;
                        }

                    }
                    else
                    {
                        First = First.Next;
                        if (First.Next == null)
                        {
                            Last = First;
                        }
                    }
                    result = true;
                    Length--;
                    isExit = true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return result;
        }


        public bool RemoveAt(int index)
        {
            bool result = false;

            if (index < 0 || (index + 1) > Length)
            {
                return result;
            }

            if (index == 0)
            {
                First = First.Next;
                Length--;
                result = true;
                return result;
            }

            var previousNode = First;
            for (int i = 1; i < index; i++)
            {
                previousNode = previousNode.Next;
            }

            previousNode.Next = previousNode.Next.Next;
            Length--;

            result = true;
            return result;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || (index + 1) > Length)
            {
                throw new ArgumentException("Incorrect index " + index);
            }

            if (index == (Length - 1))
            {
                return Last.Value;
            }

            if (index == 0)
            {
                return First.Value;
            }

            var previousNode = First;
            for (int i = 1; i < index; i++)
            {
                previousNode = previousNode.Next;
            }

            return previousNode.Next.Value;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            CustomLinkedListNode<T> currentNode = First;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

    }
}
