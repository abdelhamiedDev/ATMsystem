using System;
using ATMsystem.Classes;
using ATMsystem.Interfaces;

// 23. Namespaces / Packages
namespace ATMsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|     Welcome to ATM System         |");
            Console.WriteLine("-------------------------------------\n");

            // Get Customer Information
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Customer ID: ");
            string customerId = Console.ReadLine();

            Console.Write("Enter your phone number: ");
            string phone = Console.ReadLine();

            // Create Customer
            Customer customer = new Customer(customerId, name, phone);

            // Account Setup
            Console.WriteLine("\n--- Account Setup ---");
            Console.Write("Choose Account Type (1-Savings / 2-Current): ");
            string accountType = Console.ReadLine();

            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());

            Console.Write("Create a 4-digit PIN: ");
            string pin = Console.ReadLine();

            // 4. Abstraction - using base class type
            Account account;
            if (accountType == "1")
            {
                account = new SavingsAccount(accountNumber, initialBalance, pin); // 2. Inheritance
                Console.WriteLine("Savings Account created!");
            }
            else
            {
                account = new CurrentAccount(accountNumber, initialBalance, pin); // 2. Inheritance
                Console.WriteLine("Current Account created!");
            }

            customer.AddAccount(account);

            // Create ATM
            ATM atm = new ATM("ATM001", 100000);

            // Display Customer Info
            customer.DisplayInfo();

            // ATM Operations
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n╔════════════════════════════════════╗");
                Console.WriteLine("║          ATM Main Menu             ║");
                Console.WriteLine("╠════════════════════════════════════╣");
                Console.WriteLine("║ 1. Check Balance                   ║");
                Console.WriteLine("║ 2. Withdraw Money                  ║");
                Console.WriteLine("║ 3. Deposit Money                   ║");
                Console.WriteLine("║ 4. Exit                            ║");
                Console.WriteLine("╚════════════════════════════════════╝");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Check Balance
                        Console.Write("Enter PIN: ");
                        string checkPin = Console.ReadLine();
                        if (atm.Authenticate(account, checkPin))
                        {
                             // 1. Encapsulation - accessing via property
                            Console.WriteLine($"\nCurrent Balance: {account.Balance:C}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid PIN!");
                        }
                        break;

                    case "2":
                        // Withdraw
                        Console.Write("Enter PIN: ");
                        string withdrawPin = Console.ReadLine();
                        if (atm.Authenticate(account, withdrawPin))
                        {
                            Console.Write("Enter amount to withdraw: ");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                            Classes.Transaction withdrawTrans = new Classes.Transaction(account, withdrawAmount, "Withdraw");
                            
                            // 3. Polymorphism (Execute calls specific Withdraw)
                            if (withdrawTrans.Execute() && atm.DispenseCash(withdrawAmount))
                            {
                                withdrawTrans.DisplayReceipt();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid PIN!");
                        }
                        break;

                    case "3":
                        // Deposit
                        Console.Write("Enter PIN: ");
                        string depositPin = Console.ReadLine();
                        if (atm.Authenticate(account, depositPin))
                        {
                            Console.Write("Enter amount to deposit: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());

                            Classes.Transaction depositTrans = new Classes.Transaction(account, depositAmount, "Deposit");
                            
                            // 3. Polymorphism
                            depositTrans.Execute();
                            depositTrans.DisplayReceipt();
                        }
                        else
                        {
                            Console.WriteLine("Invalid PIN!");
                        }
                        break;

                    case "4":
                        // Exit
                        Console.WriteLine("\nThank you for using our ATM!");
                        Console.WriteLine($"Customer: {customer.Name}");
                        Console.WriteLine($"Final Balance: {account.Balance:C}");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}