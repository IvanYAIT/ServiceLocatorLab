using System;
using System.Collections.Generic;
using Zenject;

public class UISwitcher
{
    private Dictionary<Type, IUIState> _states;
    private IUIState _currentState;

    [Inject]
    public UISwitcher(UIStateInitializer initializer)
    {
        _states = initializer.States;
        ChageState(typeof(MainMenu));
    }

    public void ChageState(Type state)
    {
        _currentState?.Exit();
        _currentState = _states[state];
        _currentState.Enter();
    }
}
