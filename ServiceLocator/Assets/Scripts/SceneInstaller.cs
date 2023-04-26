using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private AdditionalMenuView additionalMenuView;
    [SerializeField] private ScoreView scoreView;

    public override void InstallBindings()
    {
        Container.Bind<AudioSource>().WithId("OpenSound").FromInstance(openSound).AsSingle().NonLazy();
        Container.Bind<AudioSource>().WithId("CloseSound").FromInstance(closeSound).AsSingle().NonLazy();

        Container.Bind<IFadeService>().To<FadeService>().AsSingle().NonLazy();
        Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle().NonLazy();
        Container.Bind<ISaver>().To<JSONSaver>().AsSingle().NonLazy();
        Container.Bind<ISaver>().To<PlayerPrefsSaver>().AsSingle().NonLazy();

        Container.Bind<AdditionalMenuView>().FromInstance(additionalMenuView).AsSingle().NonLazy();
        Container.Bind<MainMenuView>().FromInstance(mainMenuView).AsSingle().NonLazy();
        Container.Bind<ScoreView>().FromInstance(scoreView).AsSingle().NonLazy();

        Container.Bind<Score>().AsSingle().NonLazy();

        Container.Bind<UIStateInitializer>().FromInstance(new UIStateInitializer()).AsSingle().NonLazy();

        Container.Bind<UISwitcher>().AsSingle().NonLazy();
        Container.Bind<IUIState>().To<MainMenu>().NonLazy();
        Container.Bind<IUIState>().To<AdditionalMenu>().NonLazy();
    }
}