using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe_Game
{
    class Snake

    {

        static void Main(string[] args)

        {
            int gameStatus = 0;
            int CurrentPlayer = -1;
            char[] gameMarkers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            do
            {
                Console.Clear();
                CurrentPlayer = GetNextPlayer(CurrentPlayer);
                HeadUpDisplay(CurrentPlayer);
                DrawGameBoard(gameMarkers);

                GameEngine(gameMarkers, CurrentPlayer);
                gameStatus = CheckWinner(gameMarkers);



            } while (gameStatus.Equals(0));
            
            if (gameStatus.Equals(1))
            {
                Console.Clear();
                HeadUpDisplay(CurrentPlayer);
                DrawGameBoard(gameMarkers);
                Console.WriteLine($"Player {CurrentPlayer} is the winner!");
            }
            if (gameStatus.Equals(2))
            {

            }
        }

        private static int CheckWinner(char[] gameMarkers)
        {
            if (gameMarkers[0].Equals(gameMarkers[1]) && gameMarkers[1].Equals(gameMarkers[2]))
            {
                return 1;
            }
            return 0;
        }

        private static void GameEngine(char[] gameMarkers, int CurrentPlayer)
        {
            bool notValidMove = true;
            do
            {
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput) &&
                   (userInput.Equals("1") ||
                   userInput.Equals("2") ||
                   userInput.Equals("3") ||
                   userInput.Equals("4") ||
                   userInput.Equals("5") ||
                   userInput.Equals("6") ||
                   userInput.Equals("7") ||
                   userInput.Equals("8") ||
                   userInput.Equals("9")))



                {
                    Console.Clear();
                    int.TryParse(userInput, out var gamePlacementMarker);
                    char CurrentMarker = gameMarkers[gamePlacementMarker - 1];

                    if (CurrentPlayer.Equals('X') || CurrentPlayer.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select another placemente.");


                    }
                    else
                    {
                        gameMarkers[gamePlacementMarker - 1] = GetPlayerMarker(CurrentPlayer);
                        notValidMove = false;
                        
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select another placement.");
                    
                }

            } while (notValidMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if(player % 2 == 0)
            {
                return 'O';

            }
            return 'X';
        }

        static void HeadUpDisplay(int PlayerNumber)
        {
            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();
            Console.WriteLine($"Player {PlayerNumber} to move, select 1 through 9 from the game board.");
                                       
            Console.WriteLine();
        }

        static void DrawGameBoard(char[] gameMarkers)
        {

            Console.WriteLine($" { gameMarkers[0]} | { gameMarkers[1]} | { gameMarkers[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" { gameMarkers[3]} | { gameMarkers[4]} | { gameMarkers[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" { gameMarkers[6]} | { gameMarkers[7]} | { gameMarkers[8]} ");
            Console.WriteLine("Hola");
        }
        
        static int GetNextPlayer(int player)
        {
            if(player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
}
