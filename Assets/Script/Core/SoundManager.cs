using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Umber
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bgmSorceRoot;

        [SerializeField]
        private GameObject _seSorceRoot;

        private AudioSource _bgmSource = null;
        private readonly List<AudioSource> _seSourceList = new();

        public float BgmVolume { get; private set; }
        public float SeVolume { get; private set; }


        private void Awake()
        {
            _bgmSource = addSorceComponent(_bgmSorceRoot);
            _seSourceList.Add(addSorceComponent(_seSorceRoot));
            _seSourceList.Add(addSorceComponent(_seSorceRoot));
        }

        private static AudioSource addSorceComponent(GameObject rootObj)
        {
            var source = rootObj.AddComponent<AudioSource>();
            source.playOnAwake = false;
            source.loop = false;
            return source;
        }

        private void Update()
        {
            /*
            if (Input.GetKeyDown(KeyCode.A))
            {
                PlaySeAsync(SoundContainer.Instance.Se1).Forget();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                PlayBgm(SoundContainer.Instance.TitleBgm, true);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                StopBgm();
            }
            */
        }

        public async UniTask PlaySeAsync(AudioClip audioClip, bool isLoop)
        {
            var canPlaySource = _seSourceList.FirstOrDefault(x => x.isPlaying == false);
            if (canPlaySource == null)
            {
                Util.DebugLog("no source");
                canPlaySource = addSorceComponent(_seSorceRoot);
                _seSourceList.Add(canPlaySource);
            }
            canPlaySource.volume = SeVolume;
            canPlaySource.clip = audioClip;
            canPlaySource.loop = isLoop;
            canPlaySource.Play();
            await UniTask.WaitUntil(() => canPlaySource.isPlaying == false);
            Util.DebugLog("se finish");
        }

        public void PlaySe(AudioClip audioClip, bool isLoop)
        {
            PlaySeAsync(audioClip, isLoop).Forget();
        }

        public void StopSe(AudioClip audioClip)
        {
            var playingSource = _seSourceList.Where(x => x.isPlaying == true && x.clip == audioClip).ToList();

            for (int i = 0; i < playingSource.Count; i++)
            {
                playingSource[i].Stop();
            }
        }

        public void PlayBgm(AudioClip audioClip, bool isLoop)
        {
            _bgmSource.clip = audioClip;
            _bgmSource.loop = isLoop;
            _bgmSource.Play();
        }

        public void SetBgmVolume(float volume)
        {
            BgmVolume = volume;
            _bgmSource.volume = volume;
        }

        public void SetSeVolume(float volume)
        {
            SeVolume = volume;
        }

        public void PlayBgmWhenDifferent(AudioClip audioClip, bool isLoop)
        {
            if(SameBgm(audioClip))
            {
                return;
            }
            PlayBgm(audioClip, isLoop);
        }

        public bool SameBgm(AudioClip clip)
        {
            return _bgmSource.clip == clip;
        }

        public void StopBgm()
        {
            _bgmSource.Stop();
        }
    }

}