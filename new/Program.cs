class TicTacToe
{
    char[] array = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static public int cCount = 0;
    static public int pCount = 0;
    bool running = true;

    void drawBoard()
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

    void playersMove()
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

    void computersMove()
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

    bool checkWinner()
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

        static void Main(string[] args)
            {
                TicTacToe game = new TicTacToe();
                while (game.running)
                {
                    game.drawBoard();
                    game.playersMove();
                    game.drawBoard();
                    game.computersMove();
                    game.running = !game.checkWinner();
                    Console.WriteLine($"Computer wins: {cCount}  Player wins: {pCount}");
                }
                Console.WriteLine("Game over! Press any key to exit...");
                Console.ReadKey();
            }
        }
