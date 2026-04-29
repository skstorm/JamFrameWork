using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.Linq;

namespace Jam
{
    public class Util
    {
        public static T LoadScenePrefab<T>(string path, IStateMachine fsm) where T : BaseStateBehaviour
        {
            var origin = Resources.Load<T>(path);
            var obj = GameObject.Instantiate<T>(origin);
            obj.Init(fsm);
            return obj;
        }


        [Conditional("JAM_DEBUG")]
        public static void DebugLog(string log)
        {
#if JAM_DEBUG
            UnityEngine.Debug.Log(log);
#endif // JAM_DEBUG
        }

        public static float GetAnimationClipLength(Animator animator, string clipName)
        {
            IEnumerable<AnimationClip> animationClips = animator.runtimeAnimatorController.animationClips;

            return (from animationClip in animationClips
                    where animationClip.name == clipName
                    select animationClip.length).FirstOrDefault();
        }
    }
}