namespace Domino.Logic.Intefaces
{
    public interface ITile
    {
        int Head { get; set; }

        int Tail { get; set; }

        int CompareTo(object obj);
        bool Equals(object obj);

        void Swap();
    }
}
