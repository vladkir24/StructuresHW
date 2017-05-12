using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStructures.Exceptions
{
    public class HashTableElementAbsenceException : Exception
    {
        public HashTableElementAbsenceException(string message)
        {

        }

        public HashTableElementAbsenceException(object key) : 
            this($"Current HashTable doesn't contain object with key {key}")
        {

        }

        public HashTableElementAbsenceException():
            this("Current HashTable doesn't contains object")
        {

        }
    }
}
