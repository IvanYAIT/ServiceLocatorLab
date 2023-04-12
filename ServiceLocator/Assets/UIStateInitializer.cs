using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateInitializer
{
    private ServiceLocator _locator;
    private MainMenuView _mainMenuView;
    private AdditionalMenuView _additionalMenuView;

    public UIStateInitializer(ServiceLocator locator, MainMenuView mainMenuView, AdditionalMenuView additionalMenuView)
    {
        _mainMenuView = mainMenuView;
        _additionalMenuView = additionalMenuView;
        _locator = locator;
    }

    public Dictionary<Type, IUIState> Init(UISwitcher uISwitcher)
    {
        Dictionary<Type, IUIState> states = new Dictionary<Type, IUIState>();
        states.Add(typeof(MainMenu), new MainMenu(_locator, _mainMenuView, uISwitcher));
        states.Add(typeof(AdditionalMenu), new AdditionalMenu(_locator, _additionalMenuView, uISwitcher));
        return states;
    }
}
