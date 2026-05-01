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
}