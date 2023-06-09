using deVoid.Utils;
using System;

public class AdditionalMenu : IUIState
{
    private const string PATH = "/Assets/ScoreData.json";

    private AdditionalMenuView _view;
    private SoundPlayer _soundPlayer;
    private PlayerPrefsSaver _playerPrefsSaver;
    private JSONSaver _jSONSaver;
    private AdditionalMenuSignal signal;
    private UISwitcher _uISwitcher;
    private Score _score;

    public AdditionalMenu(ServiceLocator locator, AdditionalMenuView view, UISwitcher uISwitcher, Score score)
    {
        _view = view;
        _uISwitcher = uISwitcher;
        _score = score;
        locator.GetService(out _soundPlayer);
        locator.GetService(out _playerPrefsSaver);
        locator.GetService(out _jSONSaver);
        signal = Signals.Get<AdditionalMenuSignal>();
    }

    public void Enter()
    {
        Signals.Get<AdditionalMenuSignal>().AddListener(ChangeOnMainMenu);
        _view.AddListener(signal.Dispatch);
    }

    public void Exit()
    {
        _jSONSaver.SaveScore(_score.ScoreAmount, Environment.CurrentDirectory + PATH);
        //_playerPrefsSaver.SaveScore(_score.ScoreAmount);

        _view.FadeOut();

        _soundPlayer.PlayCloseSound();
        _view.RemoveListener(signal.Dispatch);
        Signals.Get<AdditionalMenuSignal>().RemoveListener(ChangeOnMainMenu);
    }

    private void ChangeOnMainMenu() => _uISwitcher.ChageState(typeof(MainMenu));
}
