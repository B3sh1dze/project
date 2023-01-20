using System.Drawing;

class TicTacToe
{
    char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    bool gameOngoing = true;
    void player(char[] board)
    {
        while (gameOngoing)
        {
            Console.WriteLine("Enter the number between (1-9): ");
            int playerInput = Convert.ToInt32(Console.ReadLine());
            int boardInput = playerInput - 1;
            if (board[boardInput] == ' ')
            {
                board[boardInput] = 'X';
                break;
            }
            else
            {
                Console.WriteLine("Entered place is already full.");
                
            }
        }
    }
    
    void computer(char[] board)
    {
        while (gameOngoing)
        {
            Random random = new Random();
            int computersMove = random.Next(1, 9);
            int arrayIndex = computersMove - 1;
            if (board[arrayIndex] == ' ')
            {
                board[arrayIndex] = 'O';
                break;
            }
        }
    }
    void drawboard()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  ");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("-----------------");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  ");
        Console.WriteLine("     |     |     ");
        Console.WriteLine("-----------------");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  ");
        Console.WriteLine("     |     |     ");
    }
    void checkWinner(char[] board)
    {
        if (board[0] != ' ' && board[0] == board[1] && board[1] == board[2])
        {
            if (board[0] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        else if (board[3] != ' ' && board[3] == board[4] && board[4] == board[5])
        {
            if (board[3] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        else if (board[6] != ' ' && board[6] == board[7] && board[7] == board[8])
        {
            if (board[6] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        else if (board[0] != ' ' && board[0] == board[3] && board[3] == board[6])
        {
            if (board[0] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        else if (board[1] != ' ' && board[1] == board[4] && board[4] == board[7])
        {
            if (board[1] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        else if (board[2] != ' ' && board[2] == board[5] && board[5] == board[8])
        {
            if (board[2] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        else if (board[0] != ' ' && board[0] == board[4] && board[4] == board[8])
        {
            if (board[0] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        else if (board[2] != ' ' && board[2] == board[4] && board[4] == board[6])
        {
            if (board[2] == 'X')
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("computer wins");
            }
        }
        
    }
    void tie(char[] board)
    {
        for(int i = 0; i < 9 ; i++)
        {
            if (board[0] != ' ' && board[1] != ' ' && board[2] != ' ' && board[3] != ' ' && board[4] != ' ' && board[5] != ' ' && board[6] != ' ' && board[7] != ' ' && board[8] != ' ')
            {
                Console.WriteLine("It's a tie!");
                break;
            }
            
        }
    }
    public TicTacToe()
    {
        while (true)
        {
            drawboard();
            player(board);
            computer(board);
            checkWinner(board);
            tie(board);
        }
    }


    static void Main(string[] args)
    {
        TicTacToe obj = new TicTacToe();
    }
}
