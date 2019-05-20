namespace BoggleScore
{
    public interface IWord
    {
        string WrittenWord { get; set; }
        char[] Letters { get; set; }
        int CalculateScore();
    }
}