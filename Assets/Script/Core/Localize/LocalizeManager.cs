using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class LocalizeData
    {
        public eTextKind TextKind { get; }
        public string JpText { get; }
        public string EnText { get; }
        public string KrText { get; }

        public LocalizeData(eTextKind textKind, string jpText, string enText, string krText)
        {
            TextKind = textKind;
            JpText = jpText;
            EnText = enText;
            KrText = krText;
        }
    }

    public class LocalizeManager : MonoBehaviour
    {
        private static Dictionary<eTextKind, LocalizeData> _localizeData = new Dictionary<eTextKind, LocalizeData>()
        {
            { eTextKind.Test, new LocalizeData(eTextKind.Test, "テスト", "Test", "") }
        };
        
        private static eLanguageKind _languageKind;

        private static Dictionary<eTextKind, string> _dicJpText = new();
        
        public static void Init()
        {
            foreach (var item in _localizeData)
            {
                _dicJpText.Add(item.Key, item.Value.JpText);
            }
        }

        public static string Get(eTextKind textKind)
        {
            var text = _languageKind switch
            {
                eLanguageKind.Jp => _dicJpText[textKind],
                _ => string.Empty
            };
            return text;
        }
    }
}