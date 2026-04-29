using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jam
{
    public class TitleSceneState : BaseStateBehaviour
    {
        [SerializeField] 
        private Button _gotoInGameBtn;
        
        protected override BaseStateBehaviour LoadScenePrefab()
        {
            return Util.LoadScenePrefab<TitleSceneState>(Const.PathTitleScene, _owner);
        }

        protected override void enterState()
        {
            base.enterState();
            
            _gotoInGameBtn.onClick.AddListener(gotoInGame);
            
            _soundManager.PlayBgm(_soundContainer.TitleBgm, true);
            Util.DebugLog("TITLE");
        }

        private void gotoInGame()
        {
            var state = Util.LoadScenePrefab<InGameSceneState>(Const.PathInGameScene, _owner);
            _owner.ChangeState(state);
        }

        protected override void exitState()
        {
            base.exitState();
            _gotoInGameBtn.onClick.RemoveAllListeners();
        }
    }
}