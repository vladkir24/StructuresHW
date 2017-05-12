using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomStructures.Exceptions;

namespace CustomStructures.Tests
{
    [TestFixture]
    public class CustomHashTableTests
    {
        private int TestSize = 5;

        private bool CheckHashTableContainsDict(CustomHashTable hashTable, Dictionary<string, int> dict)
        {
            foreach (var dictItem in dict)
            {
                try
                {
                    if ((int) hashTable[dictItem.Key] != dictItem.Value)
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        private Dictionary<string, int> GetDictionaryFromString(string rawDict)
        {
            var dict = new Dictionary<string, int>();
            var stringArray = rawDict.Split(',');
            for (int i = 0; i < stringArray.Length; i += 2)
            {
                int intValue = 0;
                int.TryParse(stringArray[i + 1], out intValue);
                dict.Add(stringArray[i], intValue);
            }
            return dict;
        }



        [TestCase("a,1,b,2,c,3,d,4,e,5,f,6,g,7,h,8,i,9,j,10")]
        public void TestCustomHashTableAdd(string rawTestDict)
        {
            var hashTable = new CustomHashTable(TestSize);
            var testDict = GetDictionaryFromString(rawTestDict);
            foreach (var dicItem in testDict)
            {
                hashTable.Add(dicItem.Key, dicItem.Value);
            }

            Assert.IsTrue(CheckHashTableContainsDict(hashTable, testDict));
        }

        [TestCase("a,1,b,2,c,3,d,4,e,5,f,6,g,7,h,8,i,9,j,10")]
        public void TestCustomHashTableAddExistingKey(string rawTestDict)
        {
            var hashTable = new CustomHashTable(TestSize);
            var testDict = GetDictionaryFromString(rawTestDict);
            foreach (var dicItem in testDict)
            {
                hashTable.Add(dicItem.Key, dicItem.Value);
            }

            try
            {
                hashTable.Add(testDict.First().Key, new Random().Next());
            }

            catch (HashTableElementPresenceException ex)
            {
               return;
            }

            catch (Exception ex)
            {
                Assert.Fail("Method Add doesn't work correctly");
            }

            Assert.Fail("Method Add doesn't work correctly");
        }

        [TestCase("a,1,b,2,c,3,d,4,e,5,f,6,g,7,h,8,i,9,j,10")]
        public void TestCustomHashTableRemove(string rawTestDict)
        {
            var hashTable = new CustomHashTable(TestSize);
            var testDict = GetDictionaryFromString(rawTestDict);
            foreach (var dicItem in testDict)
            {
                hashTable.Add(dicItem.Key, dicItem.Value);
            }

            foreach (var dictItem in testDict)
            {
                hashTable.Remove(dictItem.Key);

                try
                {
                    var dummy = hashTable[dictItem.Key];
                }
                catch (HashTableElementAbsenceException ex)
                {
                   continue;
                }

                catch (Exception ex)
                {
                    Assert.Fail("Method Remove doesn't remove hashteble item correctly");
                }

                Assert.Fail("Method Remove doesn't remove hashteble item correctly");

             }
        }
        [TestCase("a,1,b,2,c,3,d,4,e,5,f,6,g,7,h,8,i,9,j,10")]
        public void TestCustomHashTableCheckSetNull(string rawTestDict)
        {
            var hashTable = new CustomHashTable(TestSize);
            var testDict = GetDictionaryFromString(rawTestDict);
            foreach (var dicItem in testDict)
            {
                hashTable.Add(dicItem.Key, dicItem.Value);
            }

            foreach (var dictItem in testDict)
            {
                hashTable[dictItem.Key] = null;

                try
                {
                    var dummy = hashTable[dictItem.Key];
                }
                catch (HashTableElementAbsenceException ex)
                {
                    continue;
                }

                catch (Exception ex)
                {
                    Assert.Fail("Method Remove doesn't remove hashteble item correctly");
                }

                Assert.Fail("Method Remove doesn't remove hashteble item correctly");
            }
        }

        [TestCase("a,1,b,2,c,3,d,4,e,5,f,6,g,7,h,8,i,9,j,10")]
        public void TestCustomHashTableCheckSet(string rawTestDict)
        {
            int random = new Random().Next();
            var hashTable = new CustomHashTable(TestSize);
            var testDict = GetDictionaryFromString(rawTestDict);
            foreach (var dicItem in testDict)
            {
                hashTable.Add(dicItem.Key, dicItem.Value);
            }

            var newTestDict = new Dictionary<string, int>();

            foreach (var dictItem in testDict)
            {
                newTestDict[dictItem.Key] = random;
                hashTable[dictItem.Key] = random;
            }

            Assert.IsTrue(CheckHashTableContainsDict(hashTable, newTestDict));
        }

    }
}
