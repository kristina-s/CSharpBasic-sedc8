using LibraryApp.Models.User;
using LibraryApp.Services;
using System;

namespace LibraryApp
{
    class Program
    {
        // 1. Folder structure for our app
        // 2. Create domain models for User and Book
        // 3. Create User and Book services
        // 4. Create methods in the coresponding services 
        // 5. Write the login or register flow (console questions)
        // 6. Add validation


        private static UserService _userService = new UserService();
        // book service instance
        // added
        private static BookService _bookService = new BookService();
        private static HelperService _helperService = new HelperService();

        private static User _loggedUser = null;

        static void Main(string[] args)
        {
            while (true)
            {
                // Main flow (questions) 
                Console.WriteLine("Do you want to login or register ? ");
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Register");
                int userChoice = _helperService.ValidatePositiveNumber(Console.ReadLine(), 2);

                // added validation

                // 1. Login flow
                if (userChoice == 1)
                {
                    //Console.WriteLine("Enter Username");
                    //string username = Console.ReadLine();
                    //Console.WriteLine("Enter Password");
                    //string password = Console.ReadLine();

                    //_loggedUser = _userService.LogIn(username, password);

                    //if (_loggedUser == null)
                    //{
                    //    Console.WriteLine("Wrong username or password");
                    //} 

                    // added
                    // new flow to login option
                    while (true)
                    {
                        Console.WriteLine("Enter username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string password = Console.ReadLine();
                        _loggedUser = _userService.LogIn(username, password);

                        if (_loggedUser == null)
                        {
                            _helperService.ErrorMessage("Wrong username or password");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }

                // 2. Register flow
                else if (userChoice == 2)
                {
                    while (true)
                    {
                        Console.WriteLine("Enter the first name:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter the last name:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter the username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string password = Console.ReadLine();

                        User newUser = new User(firstName, lastName, username, password);

                        _loggedUser = _userService.Register(newUser);

                        if (_loggedUser == null)
                        {
                            _helperService.ErrorMessage("Register not successfull! Please try again...");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            break;
                        }
                    }

                }
                else
                {
                    continue;
                }

                // Different flows for User and Admin
                // added initial flow
                if (_loggedUser.Role == Roles.User)
                {
                    _bookService.PrintAllBooks();

                    //Improve the logged user workflow
                    //Display message: Welcome #firstName #lastName. Please select an option:
                    //Give the user an option to: 
                    //1. Show my books
                    //2. Show all books
                    //3. Borrow book
                }
                else if (_loggedUser.Role == Roles.Admin)
                {
                    _userService.PrintUsers();
                }
                else
                {
                    _helperService.ErrorMessage("Something went wrong... Please try again!");
                }

                // Run again or end 
                // added
                if (_helperService.RunAgain() == false) break;
                Console.Clear();

                

            }
        }
    }
}
