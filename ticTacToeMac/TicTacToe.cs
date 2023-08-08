namespace TicTac;

public class TicTacToe
{
    private readonly Board Board;
    // private bool[,] _plays = new bool[3, 3];
    private State _state;

    private ComputerPlayer _computerPlayer;

    public TicTacToe()
    {
        Board = new Board();

        _computerPlayer = new ComputerPlayer(Board);
        _state = State.FirstPlay;
        Board.Display("player 1 enter the number corresponding to your chosen play");
        Advance();
    }

    private void Advance()
    {
        if (_state == State.FirstPlay)
        {
            var input = GetInput();
            Board.UpdateBoard(input, Players.Player1);
            _state = State.Player2;

            Advance();
        }

        if (_state == State.Player1)
        {
            Board.Display("player 1 enter the number corresponding to your chosen play");
            var input = GetInput();
            Board.UpdateBoard(input, Players.Player1);
            _state = State.Player2;
            if (Board.CheckWin() != null) Win(Board.CheckWin());

            Advance();
        }

        if (_state == State.Player2)
        {
            var input = _computerPlayer.GetPlay();

            // Board.Display("player 2 enter the number corresponding to your chosen play");
            // var input = GetInput();
            Board.UpdateBoard(input, Players.Player2);
            _state = State.Player1;
            if (Board.CheckWin() != null) Win(Board.CheckWin());

            Advance();
        }
    }

    private void Win(Players? winner)
    {
        Board.Display("Winner is " + winner);
        Environment.Exit(1);
    }

    private char GetInput()
    {
        var input = "";
        while (true)
        {
            input = Console.ReadLine();

            if (!ValidateInput(input))
            {
                Board.Display("invalid input, please enter a number between 0 and 8");
                continue;
            }

            if (!Board.CheckExistingPlays(input[0]))
            {
                Board.Display("play not available");
                continue;
            }

            break;
        }

        return input[0];
    }

    private bool ValidateInput(string input)
    {
        return input.Length == 1 
               && int.TryParse(input, out var result) 
               && result is >= 0 and < 9;
    }

    private enum State
    {
        FirstPlay,
        Player1,
        Player2
    }
}

public enum Players
{
    Player1,
    Player2
}