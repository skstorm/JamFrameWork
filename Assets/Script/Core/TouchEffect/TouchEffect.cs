using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class TouchEffect : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private RectTransform _rectTrans;
        public RectTransform RectTrans => _rectTrans;

        public bool IsActive { get; private set; }

        private void OnEnable()
        {
            IsActive = true;
        }

        private void Update()
        {
            if (IsActive == false)
            {
                gameObject.SetActive(false);
                return;
            }

            var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.normalizedTime >= 1.0f)
            {
                IsActive = false;
            }
        }
    }
}