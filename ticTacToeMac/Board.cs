using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTac
{
    public class Board
    {
        private readonly string joiner = "  ";
        private readonly char player1symbol = 'x';
        private readonly char player2symbol = 'o';
        private char[,] _boardArray;
        private readonly ConsolePrinter _consolePrinter;
        private Dictionary<char, (int, int)> _indexes;
        public Board()
        {
            _consolePrinter = new ConsolePrinter(this);
            InitBoard();
        } 

        private void InitBoard()
        {
            _boardArray = new char[3, 3]
            {
                { '0', '1', '2' },
                { '3', '4', '5' },
                { '6', '7', '8' }
            };
            
            _indexes = new Dictionary<char, (int, int)>
            {
                {'0', (0,0)},
                {'1', (0,1)},
                {'2', (0,2)},
                {'3', (1,0)},
                {'4', (1,1)},
                {'5', (1,2)},
                {'6', (2,0)},
                {'7', (2,1)},
                {'8', (2,2)},
            };
        }
        
        // If existing entry does not match the dictionary we know it has been already been played
        public bool CheckExistingPlays(char play)
        {
            var i = _indexes[play];
            var exists = _boardArray[i.Item1, i.Item2] == play;
            return exists;
        }
        
        public void UpdateBoard(char play, Players player)
        {
            var index = _indexes[play];
            
            if(player == Players.Player1) _boardArray[index.Item1, index.Item2] = player1symbol;
            else if (player == Players.Player2) _boardArray[index.Item1, index.Item2] = player2symbol;
        }
        
        public void Display(string message)
        {
            _consolePrinter.Print(message);
        }

        public Players? CheckWin()
        {
           for(int i = 0; i < 3; i++)
           {
               // check hoizontal
               if(_boardArray[i,1] == _boardArray[i,0] && _boardArray[i,2] == _boardArray[i,0])
                    return _boardArray[i,0] == player1symbol ? Players.Player1 : Players.Player2;
                
               // check vertical 
               if(_boardArray[1,i] == _boardArray[0,i] && _boardArray[2,i] == _boardArray[0,i])
                    return _boardArray[0,i] == player1symbol ? Players.Player1 : Players.Player2;

               // check diags
               if(_boardArray[1,1] == _boardArray[0,0] && _boardArray[2,2] == _boardArray[0,0])
                    return _boardArray[0,0] == player1symbol ? Players.Player1 : Players.Player2;
               
               if(_boardArray[0,2] == _boardArray[1,1] && _boardArray[1,1] == _boardArray[2,0])
                    return _boardArray[0,2] == player1symbol ? Players.Player1 : Players.Player2;
           }
           
           return null;
        }

        public override string ToString()
        {
            string returnString = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    returnString += _boardArray[i, j];
                    returnString += joiner;
                }
                returnString += "\n";
            }

            return returnString;
        }
    }
}