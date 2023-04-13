using DG.Tweening;
using UnityEngine.UI;

public interface IFadeService : IGameService
{
    void FadeIn(Image image, float duration);
    Tween FadeOut(Image image, float duration);
}
