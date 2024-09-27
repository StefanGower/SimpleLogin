using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; } 
}

public class UserManager
{
    private List<User> users = new List<User>();

    public void Register()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        // Check if the username already exists
        if (users.Exists(u => u.Username == username))
        {
            Console.WriteLine("Username already exists.");
            return; // Exit the method if the username is taken
        }

        // If the username is available, prompt for a password
        Console.Write("Enter password for registration: ");
        string password = Console.ReadLine();

        Console.Write("Confirm password: ");
        string confirmPassword = Console.ReadLine();

        // Check if the passwords match
        if (password != confirmPassword)
        {
            Console.WriteLine("Passwords do not match. Please try again.");
            return; // Exit the method if passwords do not match
        }

        // Create a new user and add to the list
        users.Add(new User { Username = username, Password = password });
        Console.WriteLine("Registration successful.");
    }

    public bool Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        // Check if the user exists
        var user = users.Find(u => u.Username == username);
        if (user == null)
        {
            Console.WriteLine("Username does not exist. Would you like to register? (yes/no)");
            string response = Console.ReadLine()?.ToLower();
            if (response == "yes")
            {
                Register(); // Call Register method to handle registration
                return false; // User is not logged in yet
            }
            return false; // User opted not to register
        }

        // Ask for the password now
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        // Check if the password matches
        if (user.Password == password)
        {
            Console.WriteLine("Login successful.");
            return true;
        }

        Console.WriteLine("Invalid username or password.");
        return false;
    }
}

class SimpleLogin
{
    static void Main(string[] args)
    {
        UserManager userManager = new UserManager();

        while (true)
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option (1,2 or 3): "); // Numbered options since we can't click
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    userManager.Register(); // Call Register method directly
                    break;

                case "2":
                    userManager.Login(); // Call Login method directly
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}