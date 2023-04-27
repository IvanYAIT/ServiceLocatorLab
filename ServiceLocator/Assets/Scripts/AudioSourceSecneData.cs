using UnityEngine;

public class AudioSourceSecneData : MonoBehaviour
{
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;

    public AudioSource OpenSound => openSound;
    public AudioSource CloseSound => closeSound;
}
