using System;

namespace LoginTestExample
{
    // Base class demonstrating access modifiers in a login test scenario
    public class User
    {
        // Public member - accessible from anywhere
        public string Username { get; set; }

        // Protected member - accessible only within the class and derived classes
        protected string Password { get; set; }

        // Private member - accessible only within this class
        private bool IsLoggedIn { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            IsLoggedIn = false;
        }

        public void Login(string username, string password)
        {
            if (Username == username && Password == password)
            {
                IsLoggedIn = true;
                Console.WriteLine("Login successful!");
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
        }

        public void ShowLoginStatus()
        {
            Console.WriteLine(IsLoggedIn ? "User is logged in." : "User is not logged in.");
        }

        protected void ChangePassword(string newPassword)
        {
            Password = newPassword;
            Console.WriteLine("Password changed successfully.");
        }

        private void Logout()
        {
            IsLoggedIn = false;
            Console.WriteLine("User logged out.");
        }

        public void PerformLogout()
        {
            Logout(); // Accessible only within the class
        }
    }

    // Derived class inheriting from User
    public class Admin : User
    {
        public Admin(string username, string password) : base(username, password)
        {
        }

        public void ResetUserPassword(User user, string newPassword)
        {
           // user.ChangePassword(newPassword); // Compilation error: ChangePassword is protected
        }

        public void ChangeOwnPassword(string newPassword)
        {
            ChangePassword(newPassword); // Accessible because it's protected and Admin inherits User
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("testuser", "password123");
            user.Login("testuser", "password123");
            user.ShowLoginStatus();

            Admin admin = new Admin("admin", "adminpass");
            admin.ChangeOwnPassword("newadminpass");

            user.PerformLogout(); // Works fine, calls private method internally
            user.ShowLoginStatus();

            // user.ChangePassword("newpass"); // Compilation error: ChangePassword is protected
            // user.Logout(); // Compilation error: Logout is private
        }
    }
}