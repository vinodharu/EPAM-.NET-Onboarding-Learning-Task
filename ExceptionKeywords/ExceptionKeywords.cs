using System;

namespace ExceptionKeywords
{
    public static class TestConfig
    {
        public static readonly string TestEnvironment = "Staging";
    }

    public class TestCase
    {
        public int TestCaseId { get; set; }
        public string TestCaseName { get; set; }

        public TestCase(int id, string name)
        {
            TestCaseId = id;
            TestCaseName = name;
        }

        public void ExecuteTest()
        {
            try
            {
                Console.WriteLine($"\nExecuting test case: {TestCaseName}");

                for (int i = 1; i <= 5; i++)
                {
                    if (i == 3)
                    {
                        Console.WriteLine("\nSkipping iteration 3");
                        continue;
                    }
                    if (i == 5)
                    {
                        Console.WriteLine("Breaking at iteration 5");
                        break;
                    }
                    Console.WriteLine($"Iteration {i}");
                }

                throw new InvalidOperationException("Simulated test failure");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test failed: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Cleaning up test resources");
            }
        }
    }

    class ExceptionKeywords
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Test environment: {TestConfig.TestEnvironment}");

            TestCase test1 = new TestCase(101, "Login Test");
            TestCase test2 = new TestCase(102, "Checkout Test");

            test1.ExecuteTest();

            if (test1 is TestCase)
            {
                Console.WriteLine($"\n{test1.TestCaseName} is a valid TestCase object");
            }

            Console.ReadLine();
        }
    }
}