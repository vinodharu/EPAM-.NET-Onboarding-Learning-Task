using System;

namespace CustomExceptions
{
    public static class BankConfig
    {
        public static readonly string BankName = "ICICI Bank";
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }

    public class BankAccount
    {
        public string AccountHolder { get; set; }
        public string AccountNumber { get; set; }
        public double Balance { get; private set; }

        public BankAccount(string accountHolder, string accountNumber, double initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountHolder))
            {
                throw new InvalidAccountException("Account holder name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(accountNumber) || accountNumber.Length != 10)
            {
                throw new InvalidAccountException("Invalid account number");
            }

            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Withdraw(double amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawl amount must be greater than zero");
                }

                if (amount > Balance)
                {
                    throw new InsufficientFundsException("Insufficient balance to complete the transaction");
                }

                Balance -= amount;
                Console.WriteLine($"\nWithdrawl successful. Remaining balance:{Balance:C}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"\nTransaction failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("End of withdrawl process");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to {BankConfig.BankName}");

            try
            {
                BankAccount account1 = new BankAccount("John Doe", "1234567890", 1000);
                account1.Withdraw(500);
                account1.Withdraw(700);
            }
            catch (InvalidAccountException ex)
            {
                Console.WriteLine($"Account creation failed: {ex.Message}");
            }
        }
    }
}
