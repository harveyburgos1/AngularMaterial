using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer regular = new Regular
            {
                CustomerId = 1,
                CustomerName = "Roy"
            };

            Customer vip = new VIP
            {
                CustomerId = 2,
                CustomerName = "John"
            };

            PrintCustomer(regular);
            PrintCustomer(vip);


        }

        public static void PrintCustomer(Customer customer)
        {
            customer.PrintCustomerInfo();

        }


    }

    public abstract class Customer
    {
        public int CustomerId { get; set; }
        public  string CustomerName { get; set; }
        public decimal CreditLimit { get; protected set; }

        public abstract void PrintCustomerInfo();
    }

    public class Regular : Customer
    {
        public Regular()
        {
            base.CreditLimit = 100000M;
        }

        public override void PrintCustomerInfo()
        {
            var printer = new RegularCustomerInfoPrinter();
            printer.PrintCustomerInfo(this);
        }

      
    }

    public class VIP : Customer
    {
        public VIP()
        {
            this.CreditLimit = 1000000M;
        }
        public decimal Discount { get; }

        public override void PrintCustomerInfo()
        {
            var printer = new VIPCustomerInfoPrinter();
            printer.PrintCustomerInfo(this);
           
        }
    }


    public interface ICustomerInfoPrinter
    {
        void PrintCustomerInfo(Customer customer);
       
    }

    public class RegularCustomerInfoPrinter
        : ICustomerInfoPrinter
    {
        public void PrintCustomerInfo(Customer customer)
        {
            Console.WriteLine("Regular Customer {0} - {1}",
             customer.CustomerName, customer.CreditLimit);
        }
    }

    public class VIPCustomerInfoPrinter
        : ICustomerInfoPrinter
    {
        public void PrintCustomerInfo(Customer customer)
        {
            Console.WriteLine("Star VIP Customer {0} - {1} /n Free coffee and lounge stay.",
               customer.CustomerName, customer.CreditLimit);
        }
    }
}
