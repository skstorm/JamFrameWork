using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Jam
{
    public class InGameSceneState : BaseStateBehaviour
    {
        [SerializeField] 
        private Button _gotoTitleBtn;
        
        protected override BaseStateBehaviour LoadScenePrefab()
        {
            return Util.LoadScenePrefab<InGameSceneState>(Const.PathInGameScene, _owner);
        }

        protected override void enterState()
        {
            base.enterState();
            
            _gotoTitleBtn.onClick.AddListener(gotoTitle);
            
            _soundManager.PlayBgm(_soundContainer.OpeningBgm, true);
            Util.DebugLog("InGame");
        }

        private void gotoTitle()
        {
            var state = Util.LoadScenePrefab<TitleSceneState>(Const.PathTitleScene, _owner);
            _owner.ChangeState(state);
        }

        protected override void exitState()
        {
            base.exitState();
            _gotoTitleBtn.onClick.RemoveAllListeners();
        }
    }
}