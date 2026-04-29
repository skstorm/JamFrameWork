using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Jam;

namespace Jam
{
    public class TitleSceneState : BaseStateBehaviour
    {
        protected override BaseStateBehaviour LoadScenePrefab()
        {
            return Util.LoadScenePrefab<TitleSceneState>(Const.PathTitleScene, _owner);
        }
    }
}