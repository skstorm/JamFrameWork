using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class LocalizeManager : MonoBehaviour
    {
        private static readonly IReadOnlyDictionary<eTextKind, LocalizeData> _localizeData =
            new Dictionary<eTextKind, LocalizeData>
            {
                { eTextKind.Test1, new LocalizeData(eTextKind.Test1, "テスト1", "Test1", "테스트1") },
                { eTextKind.Test2, new LocalizeData(eTextKind.Test2, "テスト2", "Test2", "테스트2") },
                { eTextKind.Test3, new LocalizeData(eTextKind.Test3, "テスト3", "Test3", "테스트3") },
            };

        private static eLanguageKind _languageKind;

        private static IReadOnlyDictionary<eTextKind, string> _dicJpText;
        private static IReadOnlyDictionary<eTextKind, string> _dicEnText;
        private static IReadOnlyDictionary<eTextKind, string> _dicKrText;

        public static void Init(eLanguageKind languageKind)
        {
            SetLanguageKind(languageKind);

            var dicJpText = new Dictionary<eTextKind, string>();
            var dicEnText = new Dictionary<eTextKind, string>();
            var dicKrText = new Dictionary<eTextKind, string>();
            foreach (var item in _localizeData)
            {
                dicJpText.Add(item.Key, item.Value.JpText);
                dicEnText.Add(item.Key, item.Value.EnText);
                dicKrText.Add(item.Key, item.Value.KrText);
            }

            _dicJpText = dicJpText;
            _dicEnText = dicEnText;
            _dicKrText = dicKrText;
        }

        public static void SetLanguageKind(eLanguageKind languageKind)
        {
            _languageKind = languageKind;
        }

        public static string Get(eTextKind textKind)
        {
            var dic = _languageKind switch
            {
                eLanguageKind.Jp => _dicJpText,
                eLanguageKind.En => _dicEnText,
                eLanguageKind.Kr => _dicKrText,
                _ => null
            };

            if (dic != null && dic.TryGetValue(textKind, out var text))
                return text;

            return string.Empty;
        }
        
        public static void Release()
        {
            _dicJpText = null;
            _dicEnText = null;
            _dicKrText = null;
        }
    }
}