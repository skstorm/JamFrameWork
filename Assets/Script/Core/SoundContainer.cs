using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jam
{
    public class SoundContainer : MonoBehaviour
    {
        [field: SerializeField]
        public AudioClip OpeningBgm { get; private set; }

        [field: SerializeField]
        public AudioClip TitleBgm { get; private set; }

        [field: SerializeField]
        public AudioClip SeMessage { get; private set; }
    }
}