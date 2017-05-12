using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures.Exceptions
{
    public class HashTableElementPresenceException : Exception
    {
        public HashTableElementPresenceException(string message)
        {
            
        }

        public HashTableElementPresenceException(object key) : 
            this($"Current HashTable contains object with key {key}")
        {
            
        }

        public HashTableElementPresenceException():
            this("Current HashTable contains object")
        {
            
        }
    }
}
