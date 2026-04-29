namespace Jam
{
    public class TitleSceneState : BaseStateBehaviour
    {
        protected override BaseStateBehaviour LoadScenePrefab()
        {
            return Util.LoadScenePrefab<TitleSceneState>(Const.PathTitleScene, _owner);
        }

        protected override void enterState()
        {
            base.enterState();
            _soundManager.PlayBgm(_soundContainer.TitleBgm, true);
            Util.DebugLog("TITLE");
        }
    }
}