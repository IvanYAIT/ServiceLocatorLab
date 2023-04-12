using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private AdditionalMenuView additionalMenuView;

    private Dictionary<Type, IGameService> _services;

    void Start()
    {
        _services = new Dictionary<Type, IGameService>();
        _services.Add(typeof(FadeService), new FadeService());
        _services.Add(typeof(SoundPlayer), new SoundPlayer(openSound, closeSound));

        ServiceLocator serviceLocator = new ServiceLocator(_services);

        UIStateInitializer initializer = new UIStateInitializer(serviceLocator, mainMenuView, additionalMenuView);
        UISwitcher uISwitcher = new UISwitcher(initializer);


    }
}
