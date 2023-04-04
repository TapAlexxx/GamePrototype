using PROJECT_NAME.Scripts.Infrastructure.Services.Factories.Game;
using PROJECT_NAME.Scripts.Infrastructure.Services.Factories.UIFactory;
using PROJECT_NAME.Scripts.Infrastructure.Services.PersistenceProgress;
using PROJECT_NAME.Scripts.Infrastructure.Services.StaticData;
using PROJECT_NAME.Scripts.Infrastructure.Services.Window;
using PROJECT_NAME.Scripts.Infrastructure.StateMachine;
using PROJECT_NAME.Scripts.Infrastructure.StateMachine.Game;
using PROJECT_NAME.Scripts.Infrastructure.StateMachine.Game.States;
using UnityEngine;
using Zenject;

namespace PROJECT_NAME.Scripts.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineRunner _coroutineRunner;
        [SerializeField] private LoadingCurtain _curtain;

        private RuntimePlatform Platform => Application.platform;

        public override void InstallBindings()
        {
            Debug.Log("Installer");

            BindMonoServices();
            BindServices();

            BindGameStateMachine();
            BindGameStates();

            BootstrapGame();
        }

        private void BindServices()
        {
            BindStaticDataService();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IPersistenceProgressService>().To<PersistenceProgressService>().AsSingle(); 
        }

        private void BindMonoServices()
        {
            Container.Bind<ICoroutineRunner>().FromMethod(() => Container.InstantiatePrefabForComponent<ICoroutineRunner>(_coroutineRunner)).AsSingle();
            Container.Bind<ILoadingCurtain>().FromMethod(() => Container.InstantiatePrefabForComponent<ILoadingCurtain>(_curtain)).AsSingle();

            BindSceneLoader();
        }

        private void BindSceneLoader()
        {
            ISceneLoader sceneLoader = new SceneLoader(Container.Resolve<ICoroutineRunner>());
            Container.Bind<ISceneLoader>().FromInstance(sceneLoader).AsSingle();
        }

        private void BindStaticDataService()
        {
            IStaticDataService staticDataService = new StaticDataService();
            staticDataService.LoadData();
            Container.Bind<IStaticDataService>().FromInstance(staticDataService).AsSingle();
        }

        private void BindGameStateMachine()
        {
            Container.Bind<GameStateFactory>().AsSingle();
            Container.BindInterfacesTo<GameStateMachine>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<LoadProgressState>().AsSingle();
            Container.Bind<LoadLevelState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
        }

        private void BootstrapGame() => 
            Container.Resolve<IStateMachine<IGameState>>().Enter<BootstrapState>();

        private TOut SelectImplementation<TOut, TAndroid, TIos, TEditor>() 
            where TAndroid: TOut 
            where TIos: TOut 
            where TEditor: TOut
        {
            TOut implementation = Platform switch
            {
                RuntimePlatform.Android => Container.Instantiate<TAndroid>(),
                RuntimePlatform.IPhonePlayer => Container.Instantiate<TIos>(),
                _ => Container.Instantiate<TEditor>()
            };

            return implementation;
        }
    }
}