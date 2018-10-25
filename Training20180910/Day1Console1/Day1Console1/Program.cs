
using Day1Library1.Departments;
using Day1Library1.Customers;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Day1Console1
{
    // private
    // public
    // internal
    
    public class Program
    {
        Customer c = new Customer();
        Department d = new Department();

        int r = new Random().Next(75,
        long longNumber = 12;
        string lastName = "2343";

        
        static void Main(string[] args)
        {
            /*
             * This is a block comment spanning
             * multiple lines
             * ....
             */

            // This is a commenter
            long bigNumber = 324324344334;
            short anInt = 12;
            
            int age = 23; // This is a comment
            string firstName = "John";
            double salary = 1234.23D;
            decimal creditLimit = 123434.34M;
            bool isOverAge = true; 

             

            Console.WriteLine(age);

            Console.WriteLine("Hello World");
            Console.ReadLine();


            if (isOverAge == true)
            {
                Console.WriteLine("Overage");
            }
            else if (age > 14 && age < 21)
            {

            }
            else
            {
                Console.WriteLine("Okay");
            }

            int counter = 11;
            while (counter <= 10)
            {
                Console.WriteLine(counter);

                counter += 1;
            }

            do
            {
                counter += 1;
                Console.WriteLine(counter);
            }while (counter <= 10);

          
          
            for (int ctr = 0; ctr <= 10; ctr+=1)
            {
                Console.WriteLine(ctr);
            }

            int[] ages = new int[10];

            for (int ctr = 0; ctr < 10; ctr+=1)
            {
                ages[ctr] = ctr;
            }

            string[] employees = { "john", "paul",""};

            foreach( var emp in employees)
            {
                Console.WriteLine(emp);
            }

            List<int> listOfIntegers = new List<int>();

            listOfIntegers.Add(12);
            listOfIntegers.Add(345);

            List<string> listOfStrings = new List<string>();

            foreach (var item in listOfStrings)
            {

            }

            var emp1 = employees[0];
            var emp2 = listOfStrings[1];

        }
    }
}