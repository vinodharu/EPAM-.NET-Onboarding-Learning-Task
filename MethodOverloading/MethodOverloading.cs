using System;
using System.Collections.Generic;

namespace MethodOverloading
{
    public class TestReportGenerator
    {
        public void GenerateReport(string testName)
        {
            Console.WriteLine($"Generating report for test: {testName}");
        }

        public void GenerateReport(string testName, TimeSpan executionTime)
        {
            Console.WriteLine($"\nGenerating detailed report for test: {testName}");
            Console.WriteLine($"Execution time: {executionTime.TotalSeconds} seconds");
        }

        public void GenerateReport(string testName, TimeSpan executionTime, string status)
        {
            Console.WriteLine($"\nGenerating report for test: {testName}");
            Console.WriteLine($"Execution time: {executionTime.TotalSeconds} seconds");
            Console.WriteLine($"Test Status: {status}");
        }

        public void GenerateReport(List<string> testNames)
        {
            Console.WriteLine("\nGenerating summary report for tests:");
            foreach (var testName in testNames)
            {
                Console.WriteLine($"- {testName}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            TestReportGenerator reportGenerator = new TestReportGenerator();

            reportGenerator.GenerateReport("LoginTest");

            TimeSpan executionTime = TimeSpan.FromSeconds(5.34);
            reportGenerator.GenerateReport("LoginTest", executionTime);

            reportGenerator.GenerateReport("LoginTest", executionTime, "Pass");

            List<string> testNames = new List<string> { "LoginTest", "SignupTest", "CheckInTest" };
            reportGenerator.GenerateReport(testNames);

            Console.WriteLine("\nTest Report Generation Completed");
        }
    }
}