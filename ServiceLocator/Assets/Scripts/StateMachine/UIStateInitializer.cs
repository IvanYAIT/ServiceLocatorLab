using System;
using System.Collections.Generic;

public class UIStateInitializer
{
    private ServiceLocator _locator;
    private MainMenuView _mainMenuView;
    private AdditionalMenuView _additionalMenuView;
    private Score _score;

    public UIStateInitializer(ServiceLocator locator, MainMenuView mainMenuView, AdditionalMenuView additionalMenuView, Score score)
    {
        _mainMenuView = mainMenuView;
        _additionalMenuView = additionalMenuView;
        _locator = locator;
        _score = score;
    }

    public Dictionary<Type, IUIState> Init(UISwitcher uISwitcher)
    {
        Dictionary<Type, IUIState> states = new Dictionary<Type, IUIState>();
        states.Add(typeof(MainMenu), new MainMenu(_locator, _mainMenuView, uISwitcher));
        states.Add(typeof(AdditionalMenu), new AdditionalMenu(_locator, _additionalMenuView, uISwitcher, _score));
        return states;
    }
}
