public interface ISaver : IGameService
{
    void SaveScore(int score ,string path = null);
}