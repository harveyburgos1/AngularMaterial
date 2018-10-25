using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Using List
            List<string> listOfStrings1 =
                new List<string>();
            listOfStrings1.Add("TOne");
            listOfStrings1.Add("Two");

            List<string> listOfStrings2 =
                new List<string>();
            listOfStrings2.AddRange(listOfStrings1);
            listOfStrings2.Add("Three");

            Console.WriteLine(listOfStrings1.Count);
            Console.WriteLine(listOfStrings2.Count);

            var allWithLetter = listOfStrings2.All(AllWithTheLetterO);
            allWithLetter = listOfStrings2.All((item) => item.Contains("T"));

            var containsAnyLetter = listOfStrings2
                    .Any((item) => item.Contains("o"));

            var firstItem = listOfStrings2.FirstOrDefault();
            var totalLengthOfStrings = 0;
            listOfStrings2.ForEach((item) => totalLengthOfStrings += item.Length);

            listOfStrings2.Insert(1, "five");



            #endregion

            #region Using Dictionary
            Dictionary<int, string> dictionary = 
                new Dictionary<int, string>();
            dictionary.Add(0, "Zero");
            dictionary.Add(1, "One");
            dictionary.Remove(0);

            Dictionary<string, Customer> customers = 
                new Dictionary<string, Customer>();
            customers.Add("2343-2344-2134-5654", new Customer());


            #endregion
            #region Using Ordered List
            HashSet<Customer> set = new HashSet<Customer>();
            SortedList<string, Customer> sortedList =
                new SortedList<string, Customer>();
            sortedList.Add("zero", new Customer());
            sortedList.Add("five", new Customer());

            #endregion

            Queue<string> queue = new Queue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");

            var one = queue.Dequeue();


            Stack<string> stack = new Stack<string>();
            stack.Push("one");
            stack.Push("two");
            stack.Push("three");
            one = stack.Pop();

            DateTime datetime = new DateTime(1988, 10, 30);
            Console.WriteLine(datetime.GetAge());

       

           
        }

        private static bool AllWithTheLetterO(string item)
        {
            return item.Contains("T");
        }
    }


    public class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
    }


    public class VIP : Customer
    {
        public decimal Discount { get; }
    }

}
