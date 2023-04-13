using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : ISoundPlayer
{
    private AudioSource _openSound;
    private AudioSource _closeSound;

    public SoundPlayer(AudioSource openSound, AudioSource closeSound)
    {
        _openSound = openSound;
        _closeSound = closeSound;
    }

    public void PlayCloseSound() =>
        _openSound.Play();

    public void PlayOpenSound() =>
        _closeSound.Play();
}
