using System;

public class cardHolder
{
    // defining the necessary variables for my ATM: cardnumber, pin, first name, last name and balance:
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    //creating a constructor object, as one set of identity, passing the variables in as parameters
     
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
    //instantiate the variables as new objects
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    // setting up getters for all variables
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getfirstName()
    {
        return firstName;
    }

    public String getlastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    //setting up setters for all variables (set functions)

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    //Main method

    public static void Main(string[] args)
    {
        // all functions are built in the main method, because that is where they will be called later
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        // passing in the cardholder object named currentUser
        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit:  ");
            /*Console.Readline takes input from the user, passes it as a string. We
             * declare new variable deposit and pass the input in it.
             * We need to parse it as a double because we declared the variable as a double
             */
            double deposit = Double.Parse(Console.ReadLine());
            /*setting the new balance of the cardholder object named currentuser as#
             * the balance fetched by the get function + the deposit
             */
  
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance);
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            // same operation as in function deposit
            double withdrawal = Double.Parse(Console.ReadLine());
            /*if the withdrawal is higher than the current user's balance,
             * an message will be given to user
             */
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(.");
            }
            //otherwise the balance is set to the balance - the withdrawal
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance (cardHolder currentUser)
        {
            // this is an output of the balance to the user
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        /* this list of cardholders is created. It adds and stores a set of cardholder instances with their 5 variables 
         */
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("4532772818527702", 4321, "Michael", "Rathje", 321.23));
        cardHolders.Add(new cardHolder("4532772818527976", 9999, "Liv", "Wijk", 12.41));
        cardHolders.Add(new cardHolder("4532772818527245", 1111, "Sebastian", "Muesch", 932.45));
        cardHolders.Add(new cardHolder("4532772818527675", 3456, "Christiano", "Ronaldo", 76.65));

        // prompt user

        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        //new variable is declared as an empty string:
        String debitCardNum = "";
        // cardholder oject current user is initialised:
        cardHolder currentUser;

        while(true)
        { 
            try
            {
                debitCardNum = Console.ReadLine();
                //check ag ainst list
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again."); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again."); }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                //user input needs to be parsed as int
                userPin = int.Parse(Console.ReadLine());
                //the pin of the currently identified user is correct, this loop ends
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again."); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again."); }
        }

        //das eigentliche Programm
        Console.WriteLine("Welcome " + currentUser.getfirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            // calling the functions according to displayed options
            if(option ==1) { deposit(currentUser); }
            else if(option ==2) { withdraw(currentUser); }
            else if(option ==3) { balance(currentUser);}
            else if(option ==4) { break; }
            else { option = 0; }

        }
        while (option != 4);
        Console.WriteLine("Thank you. Have a nice day :)");

    }
}

/*Verbesserung: Speichern der Balances so, dass sie beim nächsten Aufrauf noch korrekt sind
 * 
 * 
 */