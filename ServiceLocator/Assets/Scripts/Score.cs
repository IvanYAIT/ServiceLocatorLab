public class Score
{
    private ScoreView _view;

    public int ScoreAmount { get; private set; }

    public Score(ScoreView view)
    {
        _view = view;
        ScoreAmount = 0;
        _view.ChangeScore(ScoreAmount);
        _view.AddListener(Collect);
    }

    private void Collect()
    {
        ScoreAmount += _view.GetScorePerClick();
        _view.ChangeScore(ScoreAmount);
    }
}