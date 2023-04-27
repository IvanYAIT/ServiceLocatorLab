using UnityEngine;
using Zenject;

public class SoundPlayer : ISoundPlayer
{
    private AudioSource _openSound;
    private AudioSource _closeSound;

    [Inject]
    public SoundPlayer(AudioSourceSecneData audio)
    {
        _openSound = audio.OpenSound;
        _closeSound = audio.CloseSound;
    }

    public void PlayCloseSound() =>
        _openSound.Play();

    public void PlayOpenSound() =>
        _closeSound.Play();
}