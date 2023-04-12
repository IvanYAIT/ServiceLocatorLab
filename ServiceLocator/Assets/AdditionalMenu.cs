using deVoid.Utils;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdditionalMenu : IUIState
{
    private AdditionalMenuView _view;
    private FadeService _fadeService;
    private SoundPlayer _soundPlayer;
    private AdditionalMenuSignal signal;
    private UISwitcher _uISwitcher;

    public AdditionalMenu(ServiceLocator locator, AdditionalMenuView view, UISwitcher uISwitcher)
    {
        _view = view;
        _uISwitcher = uISwitcher;
        locator.GetService(out _fadeService);
        locator.GetService(out _soundPlayer);
        signal = Signals.Get<AdditionalMenuSignal>();
    }

    public void Enter()
    {
        Signals.Get<AdditionalMenuSignal>().AddListener(ChangeOnMainMenu);
        _view.AddListener(signal.Dispatch);
    }

    public void Exit()
    {
        Tween tween = _fadeService.FadeOut(_view.GetAdditionalPanel(), _view.GetDuration());
        tween.Play().OnComplete(() =>
        {
            _view.GetAdditionalPanel().gameObject.SetActive(false);
        });
        _soundPlayer.PlayCloseSound();
        _view.RemoveListener(signal.Dispatch);
        Signals.Get<AdditionalMenuSignal>().RemoveListener(ChangeOnMainMenu);
    }

    private void ChangeOnMainMenu() => _uISwitcher.ChageState(typeof(MainMenu));
}
