using System;
using System.Collections.Generic;
using Zenject;

public class UIStateInitializer
{
    public Dictionary<Type, IUIState> States;

    [Inject]
    public void Init(MainMenu mainMenu, AdditionalMenu additionalMenu)
    {
        States = new Dictionary<Type, IUIState>();
        States.Add(typeof(MainMenu), mainMenu);
        States.Add(typeof(AdditionalMenu), additionalMenu);
    }
}
