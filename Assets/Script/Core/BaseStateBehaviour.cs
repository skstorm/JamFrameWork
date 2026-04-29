using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jam
{
    public interface IBaseStateBehaviour : IBaseState
    {
    }

    /// <summary>
    /// 状態マシン用の状態クラス（ビヘイビア）
    /// </summary>
    public abstract class BaseStateBehaviour : MonoBehaviour, IBaseStateBehaviour
    {
        protected IStateMachine _owner;
        protected SoundManager _soundManager;
        protected SoundContainer _soundContainer;

        private void Awake()
        {
            if (MainGameObject.StaticInit)
            {
                return;
            }

            // 状態をロードする前に先にメインObjectのDiを初期化する必要がある
            var singletonManagerPrefab = ResourcesManager.Load<SingletonManager>(Const.PathSingletonManagerPrefab);
            var singletonManager = GameObject.Instantiate<SingletonManager>(singletonManagerPrefab);
            var origin = ResourcesManager.Load<MainGameObject>(Const.PathMainGameObjectPrefab);
            var mainGameObj = GameObject.Instantiate<MainGameObject>(origin);
            mainGameObj.Init();

            // 初期化プラグをおろす
            MainGameObject.StaticInit = true;

            // 状態マシン作成
            var gameStateMachine = new StateMachine();
            Init(gameStateMachine);

            // 状態ロード
            var startState = LoadScenePrefab();
            DontDestroyOnLoad(startState.gameObject);

            // メインObjectで状態を回す
            mainGameObj.Run(gameStateMachine, startState).Forget();

            SceneManager.LoadScene(Const.MainSceneName);
        }


        public void Init(IStateMachine stateMachine)
        {
            _owner = stateMachine;
            var singletonManager = SingletonManager.Instance;
            _soundManager = singletonManager.SoundManager;
            _soundContainer = singletonManager.SoundContainer;
        }

        public async UniTask Run()
        {
            enterState();

            do
            {
                await UniTask.DelayFrame(1);
                updateState();

            } while (!_owner.IsNewState);

            exitState();
        }

        protected abstract BaseStateBehaviour LoadScenePrefab();

        protected virtual void enterState() { }
        protected virtual void updateState() { }

        protected virtual void exitState()
        {
            Destroy(gameObject);
        }

        public virtual void Release()
        {
            Destroy(gameObject);
        }
    }
}