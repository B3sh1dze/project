using System;
namespace hello;
class RockPaperScissors
{
    int computerWins = 0;
    int playersWins = 0;
    string[] moves = { "rock", "paper", "scissors" };
    void Game()
    {
        while (computerWins != 3 && playersWins != 3)
        {
            Console.Write("Please enter your move ('r' for rock, 'p' for paper, 's' for scissors): ");
            string playersInput = Console.ReadLine();
            if (playersInput != "r" && playersInput != "s" && playersInput != "p")
            {
                Console.WriteLine("Invalid input! Please enter a valid move.");
                continue;
            }
            int playersMoveIndex = -1;
            if (playersInput == "r")
            {
                playersMoveIndex = 0;
            }
            else if (playersInput == "p")
            {
                playersMoveIndex = 1;
            }
            else if (playersInput == "s")
            {
                playersMoveIndex = 2;
            }
            string playersMove = moves[playersMoveIndex];
            Console.WriteLine($"Player's move is: {playersMove}");
            var random = new Random();
            int computersMoveIndex = random.Next(0, 3);
            string computersMove = moves[computersMoveIndex];
            Console.WriteLine($"Computer's move is: {computersMove}");
            if (playersMove == computersMove)
            {
                Console.WriteLine("It's a tie!");
            }
            else if (playersMove == "rock" && computersMove == "scissors" ||
                     playersMove == "paper" && computersMove == "rock" ||
                     playersMove == "scissors" && computersMove == "paper")
            {
                Console.WriteLine("Player wins!");
                playersWins++;
            }
            else
            {
                Console.WriteLine("Computer wins!");
                computerWins++;
            }
            Console.WriteLine($"Computer's score: {computerWins}");
            Console.WriteLine($"Player's score: {playersWins}");
        }
        Console.WriteLine(playersWins == 3 ? "Player wins the game!" : "Computer wins the game!");
    }
    public RockPaperScissors()
    {
        int playersWins = 0;
        Game();
        
    }
}
class  NumGuessingGame
{
    public int playerCount = 0;
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
                playerCount++;
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
    public NumGuessingGame()
    {
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
}
class QuizzGame
{
    char playerInput;
    public int score = 0;
    string[] questions = new string[5] {
        "1. What does “www” stand for in a website browser?",
        "2. How long is an Olympic swimming pool (in meters)?",
         "3. What countries made up the original Axis powers in World War II?",
         "4. Who named the Pacific Ocean?",
        "5. Which animal can be seen on the Porsche logo?"
    };
    string[,] allAnswers = new string[5, 5] {
        {"A. World Wide Web", "B. World's widest widget", "C. Write with Wealth", "D. Wung's worst wrap", "E. world's wide web"},
        {"A. 50 meters", "B. 60 meters", "C. 100 meters", "D. 35 meters", "E. 70 meters"},
        {"A. Germany, Italy and Japan", "B. Soviet Union, Great Britain and USA", "C. Denmark, Luxemburg and France", "D. Germany, Soviet Union and France", "E. Italy, Cuba and Spain"},
        {"A. Ferdinand Magellan", "B. James cook", "C. Christopher columbus", "D. Amerigo Vespucci", "E. conquistadors"},
        {"A. Horse", "B. Bear", "C. Eagle", "D. Snake", "E. unicorn" } 
    };
    char[] correctAnswers = new char[5] { 'A', 'A', 'A', 'A', 'A' };

    public QuizzGame()
    {
        for(int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);
            for(int j = 0; j < questions.Length; j++)
            {
                Console.WriteLine(allAnswers[i, j]);
            }
            playerInput = Convert.ToChar(Console.ReadLine());
            Console.WriteLine();
            if(playerInput == correctAnswers[i])
            {
                Console.WriteLine("correct answer.");
                score++;
                Console.WriteLine($"Your score is: {score}");
            }
            else
            {
                Console.WriteLine("wrong answer.");
                Console.WriteLine($"correct answer is {correctAnswers[i]}");
                Console.WriteLine();
            }
        }
        Console.WriteLine($"your final score is: {score} from {questions.Length}");
    }
}
class program
{
    static void MainMenu(string userName)
    {

        Console.WriteLine("********************************************************");
        Console.WriteLine($"                  Hello {userName}                           ");
        Console.WriteLine("press 1 to play Rock Paper Scissors game.");
        Console.WriteLine("press 2 to play Number Guessing Game.");
        Console.WriteLine("press 3 to play Quizz Game.");
        Console.WriteLine("press 4 to show your profile.");
        Console.WriteLine("press 5 to leave the platform.");
    }
    static void Main(string[] args)
    {
        
        int playersCount = 0;
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Please sign in.");
        Console.WriteLine("Enter your first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter your last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter your username: ");
        string userName = Console.ReadLine();
        while (playersCount <= 3)
        {
            MainMenu(userName);

            int playersChoice = Convert.ToInt32(Console.ReadLine());

            if (playersChoice == 1)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                RockPaperScissors obj = new RockPaperScissors();
                
                
            }
            else if (playersChoice == 2)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                NumGuessingGame obj1 = new NumGuessingGame();
                playersCount = obj1.playerCount;
            }
            else if (playersChoice == 3)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                QuizzGame obj2 = new QuizzGame();
                playersCount = obj2.score;
            }
            else if (playersChoice == 4)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your name is: {firstName}");
                Console.WriteLine($"Your last name is: {lastName}");
                Console.WriteLine($"Your username is: {userName}");
            }
            else
            {
                Console.Clear();
            }
            Console.WriteLine($"Your score is: {playersCount}");
        }
    }
}
