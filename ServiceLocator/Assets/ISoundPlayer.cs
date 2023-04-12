using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundPlayer : IGameService
{
    void PlayOpenSound();
    void PlayCloseSound();
}