// namespace Gist;
//
// internal class Program
// {
//     public static void Mainn(string[] args)
//     {
//         var ticTacToe = new TicTacToe();
//     }
// }
//
// public class TicTacToe
// {
//     private readonly Board Board;
//     private bool[,] _plays = new bool[3, 3];
//     private State _state;
//
//     public TicTacToe()
//     {
//         Board = new Board();
//         _state = State.FirstPlay;
//         Board.Display("player 1 enter the number corresponding to your chosen play");
//         Advance();
//     }
//
//     private void Advance()
//     {
//         if (_state == State.FirstPlay)
//         {
//             var input = GetInput();
//             Board.UpdateBoard(input, Players.Player1);
//             _state = State.Player2;
//
//             Advance();
//         }
//
//         if (_state == State.Player1)
//         {
//             Board.Display("player 1 enter the number corresponding to your chosen play");
//             var input = GetInput();
//             Board.UpdateBoard(input, Players.Player1);
//             _state = State.Player2;
//             if (Board.CheckWin() != null) Win(Board.CheckWin());
//
//             Advance();
//         }
//
//         if (_state == State.Player2)
//         {
//             Board.Display("player 2 enter the number corresponding to your chosen play");
//             var input = GetInput();
//             Board.UpdateBoard(input, Players.Player2);
//             _state = State.Player1;
//             if (Board.CheckWin() != null) Win(Board.CheckWin());
//
//             Advance();
//         }
//     }
//
//     private void Win(Players? winner)
//     {
//         Board.Display("Winner is " + winner);
//         Environment.Exit(1);
//     }
//
//     private char GetInput()
//     {
//         var input = "";
//         while (true)
//         {
//             input = Console.ReadLine();
//
//             if (!ValidateInput(input))
//             {
//                 Board.Display("invalid input, please enter a number between 0 and 8");
//                 continue;
//             }
//
//             if (!Board.CheckExistingPlays(input[0]))
//             {
//                 Board.Display("play not available");
//                 continue;
//             }
//
//             break;
//         }
//
//         return input[0];
//     }
//
//     private bool ValidateInput(string input)
//     {
//         return input.Length == 1 && int.TryParse(input, out var result);
//     }
//
//     private enum State
//     {
//         FirstPlay,
//         Player1,
//         Player2
//     }
// }
//
// public enum Players
// {
//     Player1,
//     Player2
// }
//
// public class Board
// {
//     private readonly ConsolePrinter _consolePrinter;
//     private readonly string joiner = "  ";
//     private readonly char player1symbol = 'x';
//     private readonly char player2symbol = 'o';
//     private char[,] _boardArray;
//     private Dictionary<char, (int, int)> _indexes;
//
//     public Board()
//     {
//         _consolePrinter = new ConsolePrinter(this);
//         InitBoard();
//     }
//
//     private void InitBoard()
//     {
//         _boardArray = new char[3, 3]
//         {
//             { '0', '1', '2' },
//             { '3', '4', '5' },
//             { '6', '7', '8' }
//         };
//
//         _indexes = new Dictionary<char, (int, int)>
//         {
//             { '0', (0, 0) },
//             { '1', (0, 1) },
//             { '2', (0, 2) },
//             { '3', (1, 0) },
//             { '4', (1, 1) },
//             { '5', (1, 2) },
//             { '6', (2, 0) },
//             { '7', (2, 1) },
//             { '8', (2, 2) }
//         };
//     }
//
//     // If existing entry does not match the dictionary we know it has been already been played
//     public bool CheckExistingPlays(char play)
//     {
//         var i = _indexes[play];
//         var exists = _boardArray[i.Item1, i.Item2] == play;
//         return exists;
//     }
//
//     public void UpdateBoard(char play, Players player)
//     {
//         var index = _indexes[play];
//
//         if (player == Players.Player1) _boardArray[index.Item1, index.Item2] = player1symbol;
//         else if (player == Players.Player2) _boardArray[index.Item1, index.Item2] = player2symbol;
//     }
//
//     public void Display(string message)
//     {
//         _consolePrinter.Print(message);
//     }
//
//     public Players? CheckWin()
//     {
//         for (var i = 0; i < 3; i++)
//         {
//             // check hoizontal
//             if (_boardArray[i, 1] == _boardArray[i, 0] && _boardArray[i, 2] == _boardArray[i, 0])
//                 return _boardArray[i, 0] == player1symbol ? Players.Player1 : Players.Player2;
//
//             // check vertical 
//             if (_boardArray[1, i] == _boardArray[0, i] && _boardArray[2, i] == _boardArray[0, i])
//                 return _boardArray[0, i] == player1symbol ? Players.Player1 : Players.Player2;
//
//             // check diags
//             if (_boardArray[1, 1] == _boardArray[0, 0] && _boardArray[2, 2] == _boardArray[0, 0])
//                 return _boardArray[0, 0] == player1symbol ? Players.Player1 : Players.Player2;
//
//             if (_boardArray[0, 2] == _boardArray[1, 1] && _boardArray[1, 1] == _boardArray[2, 0])
//                 return _boardArray[0, 2] == player1symbol ? Players.Player1 : Players.Player2;
//         }
//
//         return null;
//     }
//
//     public override string ToString()
//     {
//         var returnString = "";
//         for (var i = 0; i < 3; i++)
//         {
//             for (var j = 0; j < 3; j++)
//             {
//                 returnString += _boardArray[i, j];
//                 returnString += joiner;
//             }
//
//             returnString += "\n";
//         }
//
//         return returnString;
//     }
// }
//
// public class ConsolePrinter
// {
//     private readonly Board Board;
//
//     public ConsolePrinter(Board board)
//     {
//         Board = board;
//     }
//
//     public void Print(string message)
//     {
//         Console.Clear();
//         Console.WriteLine(Board);
//         Console.WriteLine(message);
//     }
// }