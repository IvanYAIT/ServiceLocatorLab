using DG.Tweening;
using UnityEngine.UI;

public class FadeService : IFadeService
{
    private const float _maxDuration = 1;
    private const float _minDuration = 0;

    public void FadeIn(Image image, float duration) =>
        Fade(image, _maxDuration, duration);

    public Tween FadeOut(Image image, float duration) =>
        Fade(image, _minDuration, duration);

    private Tween Fade(Image image, float endValue, float duration) =>
         image.DOFade(endValue, duration);
}