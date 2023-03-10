using System.Numerics;
using System.Security.Cryptography;
class TicTacToe
{
    char[] array = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    int computersMove;
    int playerInput;
    int playersInput;
    static public int cCount = 0;
    static public int pCount = 0;
    bool running = true;
    void drawBoard(int playerInput, int computersMove)
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
    void playersMove(int playerInput, char[] array)
    {
        while (true)
        {
            Console.WriteLine("Enter the number between (1-9): ");
            playerInput = Convert.ToInt32(Console.ReadLine());
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
    void ComputersMove(int computersMove, char[] array)
    {
        Random randNum = new Random();
        computersMove = randNum.Next(1, 9);
        int arrayIndex = computersMove - 1;

        while(true)
        {
            if (array[computersMove] == ' ')
            {
                array[computersMove] = 'O';
                break;
            }
        }
    }
    bool checkWinner(int computersMove, int playersInput, char[] array)
    {
        
        if (array[0] != ' ' && array[0] == array[1] && array[1] == array[2])
        {
            if (array[0] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else if (array[3] != ' ' && array[3] == array[4] && array[4] == array[5])
        {
            if (array[3] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else if (array[6] != ' ' && array[6] == array[7] && array[7] == array[8])
        {
            if (array[6] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else if (array[0] != ' ' && array[0] == array[3] && array[3] == array[6])
        {
            if (array[0] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else if (array[1] != ' ' && array[1] == array[4] && array[4] == array[7])
        {
            if (array[1] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else if (array[2] != ' ' && array[2] == array[5] && array[5] == array[8])
        {
            if (array[2] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else if (array[0] != ' ' && array[0] == array[4] && array[4] == array[8])
        {
            if (array[0] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else if (array[2] != ' ' && array[2] == array[4] && array[4] == array[6])
        {
            if (array[2] == 'X')
            {
                Console.WriteLine("Player wins");
                pCount++;
            }
            else
            {
                Console.WriteLine("computer wins");
                cCount++;
            }
        }
        else
        {
            return false;
        }
        return true;

    }
    bool checkTie(char[] array)
    {
        for (int i = 1; i <= 9; i++)
        {
            if (array[i] == ' ')
            {
                return false;
            }
        }
        Console.WriteLine("Its's a tie! ");
        return true;
    }
    public TicTacToe()
    {
            while (running)
            {
                playersMove(playerInput, array);
                drawBoard(playerInput, computersMove);
                if (checkWinner(computersMove, playersInput, array))
                {
                    running = false;
                    pCount++;
                    break;
                }
                else if (checkTie(array))
                {
                    running = false;
                    break;
                }
                Console.WriteLine("after computers move: ");
                ComputersMove(computersMove, array);
                drawBoard(playerInput, computersMove);
                if (checkWinner(computersMove, playersInput, array))
                {
                    running = false;
                    break;
                }
                else if (checkTie(array))
                {
                    running = false;
                    break;
                }
            }
    }
    static void Main(string[] args)
    {

        TicTacToe obj = new TicTacToe();
    }
}


