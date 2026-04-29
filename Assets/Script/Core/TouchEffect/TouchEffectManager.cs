using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Umber
{
    public class TouchEffectManager : MonoBehaviour
    {
        [SerializeField]
        private TouchEffect _touchEffectPrefab;

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private List<TouchEffect> _touchEffectList = new();

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 clickPosition = Input.mousePosition;

                // スクリーン座標→ワールド座標
                RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, clickPosition, _canvas.worldCamera, out Vector2 worldPos);

                var touchEffect = getTouchEffect();
                touchEffect.gameObject.SetActive(true);
                touchEffect.RectTrans.anchoredPosition = worldPos;
            }
        }

        private TouchEffect getTouchEffect()
        {
            var eff = _touchEffectList.FirstOrDefault(x => x.IsActive == false);

            if (eff == null)
            {
                eff = GameObject.Instantiate(_touchEffectPrefab, transform);
                _touchEffectList.Add(eff);
            }
            return eff;
        }
    }
}