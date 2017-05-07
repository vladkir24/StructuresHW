using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomStructures;

namespace StructuresHW
{
    class Program
    {
        static void Main(string[] args)
        {

            var dataArray = new int[] {1, 2, 3, 4, 5};
            var list = new CustomLinkedList<int>();

            foreach (var item in dataArray)
            {
                list.Add(item);
            }

             //list.AddAt(10,4);
            //list.Remove(5);


            foreach (var lItem in list)
            {
                Console.WriteLine(lItem);
            }

            Console.WriteLine();


            Console.WriteLine();


            Console.WriteLine(list.ElementAt(2));

            Console.WriteLine(list.Length);



            Console.ReadKey();
        }
    }
}
