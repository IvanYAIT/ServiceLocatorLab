using System;
using System.Collections.Generic;
using Zenject;

public class UIStateInitializer
{
    private ISoundPlayer _soundPlayer;
    private MainMenuView _mainMenu;
    private AdditionalMenuView _additionalMenu;
    private JSONSaver _jSONSaver;
    private PlayerPrefsSaver _playerPrefsSaver;
    private Score _score;

    [Inject]
    public UIStateInitializer(ISoundPlayer soundPlayer, MainMenuView mainMenu, AdditionalMenuView additionalMenu, JSONSaver jSONSaver, PlayerPrefsSaver playerPrefsSaver, Score score)
    {
        _soundPlayer = soundPlayer;
        _mainMenu = mainMenu;
        _additionalMenu = additionalMenu;
        _jSONSaver = jSONSaver;
        _playerPrefsSaver = playerPrefsSaver;
        _score = score;
    }

    public Dictionary<Type, IUIState> Init(UISwitcher uISwitcher)
    {
        Dictionary<Type, IUIState> states = new Dictionary<Type, IUIState>();
        states.Add(typeof(MainMenu), new MainMenu(_soundPlayer, _mainMenu, uISwitcher));
        states.Add(typeof(AdditionalMenu), new AdditionalMenu(_playerPrefsSaver, _jSONSaver, _soundPlayer, _additionalMenu, uISwitcher, _score));
        return states;
    }
}
