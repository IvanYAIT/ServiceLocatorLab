using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private AudioSourceSecneData audio;
    [SerializeField] private MainMenuView mainMenuView;
    [SerializeField] private AdditionalMenuView additionalMenuView;
    [SerializeField] private ScoreView scoreView;

    public override void InstallBindings()
    {
        Container.Bind<AudioSourceSecneData>().FromInstance(audio).AsSingle().NonLazy();

        Container.Bind<IFadeService>().To<FadeService>().AsSingle().NonLazy();
        Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle().NonLazy();
        Container.Bind<JSONSaver>().AsSingle().NonLazy();
        Container.Bind<PlayerPrefsSaver>().AsSingle().NonLazy();

        Container.Bind<AdditionalMenuView>().FromInstance(additionalMenuView).AsSingle().NonLazy();
        Container.Bind<MainMenuView>().FromInstance(mainMenuView).AsSingle().NonLazy();
        Container.Bind<ScoreView>().FromInstance(scoreView).AsSingle().NonLazy();

        Container.Bind<Score>().AsSingle().NonLazy();

        Container.Bind<UIStateInitializer>().AsSingle().NonLazy();

        Container.Bind<UISwitcher>().AsSingle().NonLazy();
        Container.Bind<IUIState>().WithId(0).To<MainMenu>().AsCached().NonLazy();
        Container.Bind<IUIState>().WithId(1).To<AdditionalMenu>().AsCached().NonLazy();
    }
}