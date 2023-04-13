using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private AdditionalMenuView additionalMenuView;
    [SerializeField] private ScoreView scoreView;

    private Score _score;
    private Dictionary<Type, IGameService> _services;

    void Start()
    {
        _score = new Score(scoreView);
        _services = new Dictionary<Type, IGameService>();
        _services.Add(typeof(FadeService), new FadeService());
        _services.Add(typeof(SoundPlayer), new SoundPlayer(openSound, closeSound));
        _services.Add(typeof(PlayerPrefsSaver), new PlayerPrefsSaver());
        _services.Add(typeof(JSONSaver), new JSONSaver());

        ServiceLocator serviceLocator = new ServiceLocator(_services);

        UIStateInitializer initializer = new UIStateInitializer(serviceLocator, mainMenuView, additionalMenuView, _score);
        UISwitcher uISwitcher = new UISwitcher(initializer);


    }
}
