namespace TicTac;

public class ComputerPlayer
{
    private Board _board;

    public ComputerPlayer(Board board)
    {
        _board = board;
        
        
    }

    public char GetPlay()
    {
        var rnd = new Random();
        
        var plays = _board.GetAvailablePlays();
        

        var randIndex = rnd.Next(0, plays.Count);
        

        return plays[randIndex];
    }
}