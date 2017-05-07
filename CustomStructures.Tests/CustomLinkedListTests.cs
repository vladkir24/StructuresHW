using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomStructures.Tests
{
    [TestFixture]
    public class CustomLinkedListTests
    {

        private bool CheckListAndArrayValues<T>(CustomLinkedList<T> testList, T[] testArray)
        {
            if (testList.Length != testArray.Length)
            {
                return false;
            }

            if (testList.Length == 0 && testArray.Length == 0)
            {
                return true;
            }

            int i = 0;
            foreach (var listItem in testList)
            {
                if (!listItem.Equals(testArray[i]))
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "1", "2", "3", "4", "5" })]
        public void TestCustomLinkedListAdd(string[] incomeArray, string[] resultArray)
        {
            var lList = new CustomLinkedList<string>();
            foreach (var item in incomeArray)
            {
                lList.Add(item);
            }

            Assert.IsTrue(CheckListAndArrayValues(lList, resultArray));
        }

        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "000", "1", "2", "3", "4", "5" }, 0, "000")] //Add to the head
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "1", "2", "3", "4", "5","000" }, 4, "000")] //Add to the middle
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "1", "2", "000", "3", "4", "5" }, 2, "000")] // Add to the tail
        public void TestCustomLinkedListAddAt(string[] incomeArray, string[] resultArray, int index, string value)
        {
            var lList = new CustomLinkedList<string>();
            foreach (var item in incomeArray)
            {
                lList.Add(item);
            }

            lList.AddAt(value, index);
            Assert.IsTrue(CheckListAndArrayValues(lList, resultArray));
        }



        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] {"2", "3", "4", "5" }, new string[] {"1"})]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] {"1","2", "3", "4" }, new string[] {"5"})]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] {"1", "4", "5" }, new string[] {"2", "3"})] 
        [TestCase(new string[] { "1", "2", "5", "3", "4", "5" }, new string[] { "1", "2", "3", "4", "5" }, new string[] {"5"})] 
        public void TestStringCustomLinkedListRemove(string[] incomeArray, string[] resultArray, string[] removingValues)
        {
            var lList = new CustomLinkedList<string>();
            foreach (var item in incomeArray)
            {
                lList.Add(item);
            }

            foreach (var rItem in removingValues)
            {
                lList.Remove(rItem);
            }

            Assert.IsTrue(CheckListAndArrayValues(lList, resultArray));
        }

        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "2", "3", "4", "5" }, 0)]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "1", "2", "3", "4" }, 4)]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "1", "2", "3", "4", "5" }, 5)]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, new string[] { "1", "2", "4", "5" }, 2)]
        [TestCase(new string[] { "1", "2", "5", "3", "4", "5" }, new string[] { "1", "2", "3", "4", "5" }, 2)]
        public void TestStringCustomLinkedListRemoveAt(string[] incomeArray, string[] resultArray, int index)
        {
            var lList = new CustomLinkedList<string>();
            foreach (var item in incomeArray)
            {
                lList.Add(item);
            }

            lList.RemoveAt(index);

            Assert.IsTrue(CheckListAndArrayValues(lList, resultArray));
        }

        [TestCase(new string[] { "1", "2", "3", "4", "5" }, 0 , "1")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, 2 , "3")]
        [TestCase(new string[] { "1", "2", "3", "4", "5" }, 4 , "5")]
        public void TestStringCustomListElementAt(string[] incomeArray, int index, string correctValue)
        {
            var lList = new CustomLinkedList<string>();
            foreach (var item in incomeArray)
            {
                lList.Add(item);
            }

            Assert.AreEqual(lList.ElementAt(index), correctValue);
        }

    }
}
