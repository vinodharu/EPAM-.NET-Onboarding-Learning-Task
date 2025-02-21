using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_.NET_Onboarding_Learning_Task.OOPS
{
    abstract class Employee
    {
        public abstract void DisplayEmpID();
        public abstract void DisplayEmpDesignation();
    }


    class Organziation1 : Employee
    {
        public override void DisplayEmpID()
        {
            Console.WriteLine("211");
        }

        public override void DisplayEmpDesignation()
        {
            Console.WriteLine("Software Engineer");
        }
    }

    class Organization2 : Employee
    {
        public override void DisplayEmpID()
        {
            Console.WriteLine("212");
        }

        public override void DisplayEmpDesignation()
        {
            Console.WriteLine("Software Test Engineer");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Employee organization1 = new Organziation1();
            Employee organization2 = new Organization2();

            Console.WriteLine("Organization1:");
            organization1.DisplayEmpID();
            organization1.DisplayEmpDesignation();

            Console.WriteLine("\nOrganization2:");
            organization2.DisplayEmpID();
            organization2.DisplayEmpDesignation();
        }
    }
}