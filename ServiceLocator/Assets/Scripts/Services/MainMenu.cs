using deVoid.Utils;

public class MainMenu : IUIState
{
    private MainMenuView _view;
    private FadeService _fadeService;
    private SoundPlayer _soundPlayer;
    private MainMenuSignal signal;
    private UISwitcher _uISwitcher;

    public MainMenu(ServiceLocator locator, MainMenuView view, UISwitcher uISwitcher)
    {
        _view = view;
        _uISwitcher = uISwitcher;
        locator.GetService(out _fadeService);
        locator.GetService(out _soundPlayer);
        signal = Signals.Get<MainMenuSignal>();
    }

    public void Enter()
    {
        Signals.Get<MainMenuSignal>().AddListener(ChangeOnAdditionalMenu);
        _view.AddListener(signal.Dispatch);
    }

    public void Exit()
    {
        _view.GetAdditionalPanel().gameObject.SetActive(true);
        _fadeService.FadeIn(_view.GetAdditionalPanel(), _view.GetDuration());
        _soundPlayer.PlayOpenSound();
        _view.RemoveListener(signal.Dispatch);
        Signals.Get<MainMenuSignal>().RemoveListener(ChangeOnAdditionalMenu);
    }

    private void ChangeOnAdditionalMenu() => _uISwitcher.ChageState(typeof(AdditionalMenu));
}
