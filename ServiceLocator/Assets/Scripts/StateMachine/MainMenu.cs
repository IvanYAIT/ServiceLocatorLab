using deVoid.Utils;
using Zenject;

public class MainMenu : IUIState
{
    private MainMenuView _view;
    private SoundPlayer _soundPlayer;
    private MainMenuSignal signal;
    private UISwitcher _uISwitcher;

    [Inject]
    public MainMenu(SoundPlayer soundPlayer, MainMenuView view, UISwitcher uISwitcher)
    {
        _view = view;
        _uISwitcher = uISwitcher;
        _soundPlayer = soundPlayer;
        signal = Signals.Get<MainMenuSignal>();
    }

    public void Enter()
    {
        Signals.Get<MainMenuSignal>().AddListener(ChangeOnAdditionalMenu);
        _view.AddListener(signal.Dispatch);
    }

    public void Exit()
    {
        _view.SetActivePanel(true);
        _view.FadeIn();

        _soundPlayer.PlayOpenSound();
        _view.RemoveListener(signal.Dispatch);
        Signals.Get<MainMenuSignal>().RemoveListener(ChangeOnAdditionalMenu);
    }

    private void ChangeOnAdditionalMenu() => _uISwitcher.ChageState(typeof(AdditionalMenu));
}
