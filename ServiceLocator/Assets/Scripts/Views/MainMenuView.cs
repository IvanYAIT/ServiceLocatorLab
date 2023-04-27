using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button openBtn;
    [SerializeField] private Image additionalPanel;
    [SerializeField] private float duration;

    private IFadeService _fadeService;

    [Inject]
    public void Construct(IFadeService fadeService)
    {
        _fadeService = fadeService;
    }

    public void FadeIn() =>
        _fadeService.FadeIn(additionalPanel, duration);

    public void FadeOut()
    {
        Tween tween = _fadeService.FadeOut(additionalPanel, duration);
        tween.Play().OnComplete(() =>
        {
            SetActivePanel(false);
        });
    }

    public void SetActivePanel(bool value) =>
        additionalPanel.gameObject.SetActive(value);
    public void AddListener(UnityAction action) =>
        openBtn.onClick.AddListener(action);

    public void RemoveListener(UnityAction action)=>
        openBtn.onClick.RemoveListener(action);
}