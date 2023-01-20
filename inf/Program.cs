using System.Globalization;

class Library
{
    string firstName;
    string lastName;
    string userName;
    int day, month, year;
    void introduction()
    {
        Console.WriteLine("Hello there if you want to get our service please log in first! ");
        
        Console.Write("Enter your first name: ");
        firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        lastName = Console.ReadLine();
        Console.Write("Enter your username: ");
        userName = Console.ReadLine();
        string log1 = $"User named: {firstName} {lastName} registered at {DateTime.Now.ToString()}  as {userName}";
        File.WriteAllText("login.txt", log1);
        
        File.WriteAllText("usernames.txt", userName);
        Console.WriteLine($"To create an account {firstName} at first you must be over 16 years.");
        Console.WriteLine("Please enter your date of birth to check your adultness.");
        Console.WriteLine("Enter your date of birth (dd/MM/yyyy): ");
        string dobString = Console.ReadLine();
        DateTime dob = DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime currentTime = DateTime.Now;
        DateTime validation = currentTime.AddYears(-16);
        if(validation > dob)
        {
            string information = File.ReadAllText("usernames.txt");
            Console.WriteLine("access granted.");
            Console.WriteLine($"Welcome: {information}");
        }
        else
        {
            Console.WriteLine("access denied");
            Console.WriteLine($"You must be under: {validation.Year}");
        }
        
    }
    public Library()
    {
        introduction();
    }
    static void Main(string[] args)
    {
        Library obj = new Library();
    }
}

