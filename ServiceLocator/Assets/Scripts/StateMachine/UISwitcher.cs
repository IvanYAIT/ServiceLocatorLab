using System;
using System.Collections.Generic;

public class UISwitcher
{
    private Dictionary<Type, IUIState> _states;
    private IUIState _currentState;

    public UISwitcher(UIStateInitializer initializer)
    {
        _states = initializer.Init(this);
        ChageState(typeof(MainMenu));
    }

    public void ChageState(Type state)
    {
        //if (_currentState != null)
        _currentState?.Exit();
        _currentState = _states[state];
        _currentState.Enter();
    }
}
