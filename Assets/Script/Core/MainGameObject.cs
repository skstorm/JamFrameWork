using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Umber
{
    public class MainGameObject : MonoBehaviour
    {
        public static bool StaticInit = false;

        public void Init()
        {
            var singletonManager = SingletonManager.Instance;

            singletonManager.SoundManager.SetBgmVolume(0.3f);
            singletonManager.SoundManager.SetSeVolume(1f);
        }

        public async UniTask Run(StateMachine stateMachine, IBaseStateBehaviour startState)
        {
            //Localize.LanguageKind = ELanguageKind.En;
            Application.targetFrameRate = 60;

            DontDestroyOnLoad(this);

            await stateMachine.RunAsync(startState);
            stateMachine.Release();
        }
#if UMBER_DEBUG
        private void Update()
        {
            if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
            {
                if (Input.GetKeyDown(KeyCode.F1))
                {
                    PlayerPrefs.SetInt(PlayerPrefsConst.ClearLevel, 1);
                }
                else if (Input.GetKeyDown(KeyCode.F2))
                {
                    PlayerPrefs.SetInt(PlayerPrefsConst.ClearLevel, 2);
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerPrefs.DeleteAll();
                }
            }
        }
#endif // UMBER_DEBUG
    }
}