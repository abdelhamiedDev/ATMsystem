using System;
using System.Text;
using ATMsystem.Interfaces;


namespace ATMsystem.Classes
{
    class DisplayMenu
    {
        static public void Display_Menu()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("|     Welcome to ATM System         |");
            Console.WriteLine("-------------------------------------\n");
            
            string name;
            // Get Customer Information
            do 
            {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
                if (Authenticattion.is_null_or_empty(name))
                    Console.WriteLine("❌ Invalid! Please Try Again");
            }
            while (Authenticattion.is_null_or_empty(name));
            
            
            string customerId;
            do
            {
            
            Console.Write("Enter your Customer ID: ");
            customerId = Console.ReadLine();
            if (Authenticattion.is_null_or_empty(customerId))
                Console.WriteLine("❌ Invalid! Please Try Again");
            }
            while (Authenticattion.is_null_or_empty(customerId));

            string phone;
            do
            {
                
            Console.Write("Enter your phone number: ");
            phone = Console.ReadLine();
                if (Authenticattion.is_null_or_empty(phone))
                    Console.WriteLine("❌ Invalid! Please Try Again");
            }
            while(Authenticattion.is_null_or_empty(phone));


            // Create Customer
            Customer customer = new Customer(customerId, name, phone);

            // Account Setup

            string accountType;
            do
            {
                Console.WriteLine("\n--- Account Setup ---");
                Console.Write("Choose Account Type (1-Savings / 2-Current): ");
                accountType = Console.ReadLine();
                if (!int.TryParse(accountType, out int accountTypeNum)
                ||(accountTypeNum !=1 && accountTypeNum != 2) 
                || string.IsNullOrWhiteSpace(accountType))
                    {
                    Console.WriteLine("❌ Invalid! Please Try again");
                        accountType = "";
                    }

            }
            while(!int.TryParse(accountType, out int result)
                || (result !=1 && result != 2) 
                || string.IsNullOrWhiteSpace(accountType));

            string accountNumber;
            while (true)
            {
                Console.Write("Enter Account Number: ");
                accountNumber = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(accountNumber) && accountNumber.Length >= 8 && 
                    accountNumber.Length <= 12 && accountNumber.All(char.IsDigit)) break;
                Console.WriteLine("❌ Invalid! Must be 8-12 digits (numbers only).");
            }


            decimal initialBalanceDec = 0;
            bool validBalance = false;

            do
            {
                Console.Write("Enter Initial Balance: $");
                string initialBalanceInput = Console.ReadLine();
                
                // Validate input
                if (string.IsNullOrWhiteSpace(initialBalanceInput))
                {
                    Console.WriteLine("❌ Invalid! Initial balance cannot be empty.");
                    continue;
                }
                
                // Try to parse as decimal
                if (!decimal.TryParse(initialBalanceInput, out decimal parsedBalance))
                {
                    Console.WriteLine("❌ Invalid! Please enter a valid number (e.g., 1000.50).");
                    continue;
                }
                
                // Validate business rules
                if (parsedBalance < 0)
                {
                    Console.WriteLine("❌ Invalid! Initial balance cannot be negative.");
                    continue;
                }
                
                if (parsedBalance > 1000000) // Reasonable limit
                {
                    Console.WriteLine("❌ Invalid! Initial balance cannot exceed $1,000,000.");
                    continue;
                }
                
                // Success - store the decimal value
                initialBalanceDec = parsedBalance;
                validBalance = true;
            }
            while (!validBalance);

            string pin;
            while (true)
            {
                Console.Write("Create a 4-digit PIN: ");
                pin = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(pin) && pin.Length == 4 && pin.All(char.IsDigit)) break;
                Console.WriteLine("❌ Invalid! Must be exactly 4 digits (numbers only).");
            }

            // 4. Abstraction - using base class type
            Account account;
            if (accountType == "1")
            {
                account = new SavingsAccount(accountNumber, initialBalanceDec, pin); // 2. Inheritance
                Console.WriteLine("Savings Account created!");
                ((SavingsAccount)account).ApplyInterest();
            }
            else
            {
                account = new CurrentAccount(accountNumber, initialBalanceDec, pin); // 2. Inheritance
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
                Console.WriteLine("\n------------------------------------");
                Console.WriteLine("|          ATM Main Menu             |");
                Console.WriteLine("|------------------------------------|");
                Console.WriteLine("| 1. Check Balance                   |");
                Console.WriteLine("| 2. Withdraw Money                  |");
                Console.WriteLine("| 3. Deposit Money                   |");
                Console.WriteLine("| 4. Exit                            |");
                Console.WriteLine("| 5. Display info                    |");
                Console.WriteLine("-------------------------------------|");
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
                             // Encapsulation - accessing via property
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

                            Transaction withdrawTrans = new Transaction(account, withdrawAmount, "Withdraw");
                            
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

                            Transaction depositTrans = new Transaction(account, depositAmount, "Deposit");
                            
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
                    case "5":
                    Console.Write("Enter PIN: ");
                        string displayPin = Console.ReadLine();
                        if (atm.Authenticate(account, displayPin))
                        {
                            customer.DisplayInfo();
                        }
                        else
                        {   
                            Console.WriteLine("Invalid PIN!");
                        }
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



