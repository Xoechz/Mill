namespace Mill
{
    public class Moves
    {
        public MoveType Move;
        public int Parameter1;
        public int Parameter2;
    }

    public enum MoveType
    {
        Set,
        Move,
        Take
    }
}