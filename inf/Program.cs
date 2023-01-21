using System.IO;
using System.Globalization;
using System.Drawing;


class Library
{
    string firstName;
    string lastName;
    string userName;
    void logIn()
    {
        Console.Write("Enter your first name: ");
        firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        lastName = Console.ReadLine();
        Console.Write("Enter your username: ");
        userName = Console.ReadLine();
        string log1 = $"User named: {firstName} {lastName} registered at {DateTime.Now.ToString()}  as {userName}. ";
        File.AppendAllText("login.txt", log1);
        File.AppendAllText("usernames.txt", userName + Environment.NewLine);
        Console.WriteLine($"To create an account {firstName} at first you must be over 16 years.");
        Console.WriteLine("Please enter your date of birth to check your adultness.");
        Console.WriteLine("Enter your date of birth (dd/MM/yyyy): ");
        string dobString = Console.ReadLine();
        DateTime dob = DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        string log2 = $"{firstName} {lastName}'s date of birth is: {dob}";
        File.AppendAllText("login.txt", log2 + Environment.NewLine);
        DateTime currentTime = DateTime.Now;
        DateTime validation = currentTime.AddYears(-16);
        if (validation > dob)
        {
            string information = File.ReadAllText("usernames.txt");
            Console.WriteLine("username succesfully logged in.");
        }
        else
        {
            Console.WriteLine("access denied");
            Console.WriteLine($"You must be under: {validation.Year}");
        }
    }
    static bool IsUserRegistered(string username)
    {

        using (StreamReader sr = new StreamReader("usernames.txt"))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(username))
                {
                    return true;
                }
            }
        }
        return false;
    }
    void introduction()
    {
        Console.WriteLine("Hello there if you want to get our service please log in first! \n To get logged in press 1. \n If you are already logged in please press 2");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            logIn();
            mainMenu();
        }
        else if (choice == 2)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            IsUserRegistered(username);
            Console.WriteLine("If you want to get information about your profile please press 1.");
            Console.WriteLine("If you want to continue session press 2.");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            if (choice1 == 1)
            {
                using (StreamReader sr = new StreamReader("login.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(username))
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            else if (choice == 2) 
            {
                mainMenu();
            }
            else if(choice == 3)
            {
                TicTacToe game = new TicTacToe();
                while (game.running)
                {
                    game.drawBoard();
                    game.playersMove();
                    game.drawBoard();
                    game.computersMove();
                    game.running = !game.checkWinner();
                }
                Console.WriteLine("Game over! Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
    void mainMenu()
    {
        Console.WriteLine($"Welcome {userName} to our platform!");
        Console.WriteLine("if you want to entertain there is some kind of games");
        Console.WriteLine("press 1 to play Rock-Paper-Scissors game.");
        Console.WriteLine("press 2 to play Number Guessing game.");
        Console.WriteLine("press 3 to play TicTacToe game.");
        Console.WriteLine("if you want to exit press 'q'.");
        int playersChoice = Convert.ToInt32(Console.ReadLine());
        if (playersChoice == 1)
        {
            int computerWins = 0;
            int playersWins = 0;
            string[] moves = { "rock", "paper", "scissors" };
            while (computerWins != 3 && playersWins != 3)
            {
                Console.Write("Please enter the character you want from('r','s','p'): ");
                char playersInput = Convert.ToChar(Console.ReadLine());
                if (playersInput != 'r' && playersInput != 's' && playersInput != 'p')
                {
                    Console.WriteLine("wrong input! please enter the correct character! ");
                    continue;
                }
                int playersMoveIndex = -1;
                if (playersInput == 'r') playersMoveIndex = 0;
                else if (playersInput == 'p') playersMoveIndex = 1;
                else if (playersInput == 's') playersMoveIndex = 2;
                string playerMove = moves[playersMoveIndex];
                Console.WriteLine($"Player's move is: {playerMove}");
                var random = new Random();
                int randomNumber = random.Next(0, 3);
                string computersMove = moves[randomNumber];
                Console.WriteLine($"computer's move: {computersMove}");
                if ((playersInput == 'r' && computersMove == "scissors") || (playersInput == 'p' && computersMove == "rock") || (playersInput == 's' && computersMove == "paper"))
                {
                    Console.WriteLine("player wins!");
                    playersWins++;
                }
                else if (playersMoveIndex == randomNumber)
                {
                    Console.WriteLine("It's a tie!");
                }
                else
                {
                    Console.WriteLine("computer wins!");
                    computerWins++;
                }
                Console.WriteLine($"computer's score: {computerWins}");
                Console.WriteLine($"player's score: {playersWins}");
            }
            Console.WriteLine(playersWins == 3 ? "player wins!" : "Computer wins!");
        }
        else if(playersChoice == 2)
        {
            void Game(int range, int guesses)
            {
                Console.WriteLine($"You have {guesses} guesses");
                Console.WriteLine("Good luck!!!");
                Random randNum = new Random();
                int computersChoice = randNum.Next(range);
                for (int i = 1; i <= guesses; i++)
                {
                    Console.WriteLine($" {i}) Enter the number: ");
                    int playerInput = Convert.ToInt32(Console.ReadLine());
                    if (playerInput == computersChoice)
                    {
                        Console.WriteLine("congratulations! You win.");
                        break;
                    }
                    else if (playerInput > computersChoice)
                    {
                        Console.WriteLine("generated number is smaller.");
                        Console.WriteLine();
                    }
                    else if (playerInput < computersChoice)
                    {
                        Console.WriteLine("generated number is higher.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("wrong answer. try again.");
                    }
                }

                Console.WriteLine($"generated number was: {computersChoice}");
            }

            void menu()
            {
                Console.WriteLine("                       _______________________________________________");
                Console.WriteLine("                                   NUMBER GUESSING GAME               ");
                Console.WriteLine("                           please select the difficulty level!");
                Console.WriteLine("1. easy  -- in this level you have to guess numbers between 0 to 30, in 10 guesses");
                Console.WriteLine("2. medium -- in this level you have to guess numbers between 0 to 50, in 7 guesses");
                Console.WriteLine("3. hard -- in this level you have to guess numbers between 0 to 70, in 6 guesses");
                Console.WriteLine("4. impossible -- in this level you have to guess numbers between 0 to 100, in 3 guesses");
                Console.WriteLine("5. if u want to exit press '5'.");
            }

            menu();
            int playerInput = Convert.ToInt32(Console.ReadLine());
            if (playerInput == 1)
            {
                Game(30, 10);
            }
            else if (playerInput == 2)
            {
                Game(50, 7);
            }
            else if (playerInput == 3)
            {
                Game(70, 6);
            }
            else if (playerInput == 4)
            {
                Game(100, 3);
            }
            else
            {
                Console.Clear();

            }
        }
        else if(playersChoice == 3)
        {

        }

    }


    class TicTacToe
    {
        char[] array = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static public int cCount = 0;
        static public int pCount = 0;
        public bool running = true;

       public void drawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array[0]}  |  {array[1]}  |  {array[2]}  ");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array[3]}  |  {array[4]}  |  {array[5]}  ");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array[6]}  |  {array[7]}  |  {array[8]}  ");
            Console.WriteLine("     |     |     ");
        }

        public void playersMove()
        {
            while (true)
            {
                Console.WriteLine("Enter the number between (1-9): ");
                int playerInput = Convert.ToInt32(Console.ReadLine());
                int arrayIndex = playerInput - 1;
                if (array[arrayIndex] == ' ')
                {
                    array[arrayIndex] = 'X';
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter different number this area is already full.");
                }
            }
        }

       public void computersMove()
        {
            Random randNum = new Random();
            int computersMove = randNum.Next(1, 9);
            int arrayIndex = computersMove - 1;

            while (true)
            {
                if (array[arrayIndex] == ' ')
                {
                    array[arrayIndex] = 'O';
                    break;
                }
                else
                {
                    computersMove = randNum.Next(1, 9);
                    arrayIndex = computersMove - 1;
                }
            }
        }

        public bool checkWinner()
        {
            if (array[0] != ' ' && array[0] == array[1] && array[1] == array[2])
            {
                if (array[0] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            else if (array[3] != ' ' && array[3] == array[4] && array[4] == array[5])
            {
                if (array[3] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            else if (array[6] != ' ' && array[6] == array[7] && array[7] == array[8])
            {
                if (array[6] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            else if (array[0] != ' ' && array[0] == array[3] && array[3] == array[6])
            {
                if (array[0] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            else if (array[1] != ' ' && array[1] == array[4] && array[4] == array[7])
            {
                if (array[1] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            else if (array[2] != ' ' && array[2] == array[5] && array[5] == array[8])
            {
                if (array[2] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            else if (array[0] != ' ' && array[0] == array[4] && array[4] == array[8])
            {
                if (array[0] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            else if (array[2] != ' ' && array[2] == array[4] && array[4] == array[6])
            {
                if (array[2] == 'X')
                {
                    Console.WriteLine("Player wins");
                    pCount++;
                    return true;
                }
                else
                {
                    Console.WriteLine("computer wins");
                    cCount++;
                    return true;
                }
            }
            return false;
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


