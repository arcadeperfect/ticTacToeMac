namespace TicTac;

public class Board
{
    private readonly ConsolePrinter _consolePrinter;
    private readonly string joiner = "  ";
    private readonly char player1symbol = 'x';
    private readonly char player2symbol = 'o';
    private char[,] _boardArray;
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
            { '0', (0, 0) },
            { '1', (0, 1) },
            { '2', (0, 2) },
            { '3', (1, 0) },
            { '4', (1, 1) },
            { '5', (1, 2) },
            { '6', (2, 0) },
            { '7', (2, 1) },
            { '8', (2, 2) }
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

        if (player == Players.Player1) _boardArray[index.Item1, index.Item2] = player1symbol;
        else if (player == Players.Player2) _boardArray[index.Item1, index.Item2] = player2symbol;
    }

    public List<char> GetAvailablePlays()
    {
        var availablePlays = new List<char>();

        foreach (var play in _indexes)
        {
            var key = play.Key;
            var val = play.Value;
            var a = val.Item1;
            var b = val.Item2;
            var currentValue = _boardArray[a, b];
            
            if(currentValue == key) availablePlays.Add(key);
        }

        return availablePlays;
    }

    public void Display(string message)
    {
        _consolePrinter.Print(message);
    }

    public Players? CheckWin()
    {
        for (var i = 0; i < 3; i++)
        {
            // check hoizontal
            if (_boardArray[i, 1] == _boardArray[i, 0] && _boardArray[i, 2] == _boardArray[i, 0])
                return _boardArray[i, 0] == player1symbol ? Players.Player1 : Players.Player2;

            // check vertical 
            if (_boardArray[1, i] == _boardArray[0, i] && _boardArray[2, i] == _boardArray[0, i])
                return _boardArray[0, i] == player1symbol ? Players.Player1 : Players.Player2;

            // check diags
            if (_boardArray[1, 1] == _boardArray[0, 0] && _boardArray[2, 2] == _boardArray[0, 0])
                return _boardArray[0, 0] == player1symbol ? Players.Player1 : Players.Player2;

            if (_boardArray[0, 2] == _boardArray[1, 1] && _boardArray[1, 1] == _boardArray[2, 0])
                return _boardArray[0, 2] == player1symbol ? Players.Player1 : Players.Player2;
        }
        return null;
    }

    public override string ToString()
    {
        var returnString = "";
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                returnString += _boardArray[i, j];
                returnString += joiner;
            }

            returnString += "\n";
        }

        return returnString;
    }
}