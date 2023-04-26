using UnityEngine;
using Zenject;

public class SoundPlayer : ISoundPlayer
{
    private AudioSource _openSound;
    private AudioSource _closeSound;

    public SoundPlayer([Inject(Id ="OpenSound")] AudioSource openSound, [Inject(Id = "CloseSound")] AudioSource closeSound)
    {
        _openSound = openSound;
        _closeSound = closeSound;
    }

    public void PlayCloseSound() =>
        _openSound.Play();

    public void PlayOpenSound() =>
        _closeSound.Play();
}