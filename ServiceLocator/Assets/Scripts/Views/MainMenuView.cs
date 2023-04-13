using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button openBtn;
    [SerializeField] private Image additionalPanel;
    [SerializeField] private float duration;

    private FadeService _fadeService;

    public void Construct(ServiceLocator locator)
    {
        locator.GetService(out _fadeService);
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