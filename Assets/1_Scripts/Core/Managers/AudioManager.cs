using Core.Main;
using UnityEngine;
using NaughtyAttributes;

namespace Core.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [BoxGroup("Music source")] [SerializeField]
        private AudioSource musicSource;

        [BoxGroup("Sounds sources")] [SerializeField]
        private AudioSource[] soundsSources;

        [BoxGroup("Audio clips")] [SerializeField]
        private AudioClip clickButton, takeItem, rightItemMove, wrongItemMove, victory;

        public void Init()
        {
            ChangeAudioVolume(LoadSaveManager.AudioIsEnable);
            PlayMusic();
        }

        public void ChangeAudioVolume(bool isOn)
        {
            // runSource.volume = isOn ? 0.5f : 0;
            // musicSource.volume = isOn ? 1 : 0;
        }

        private void Update()
        {
            if (!musicSource.isPlaying)
            {
                PlayMusic();
            }
        }

        private void PlayMusic()
        {
            musicSource.Play();
        }

        public void PlaySound(TypeSound typeSound)
        {
            AudioSource source = null;

            foreach (var sourceAudio in soundsSources)
            {
                if (!sourceAudio.isPlaying)
                {
                    source = sourceAudio;
                }
            }

            if (source != null)
            {
                AudioClip clip = null;

                if (typeSound == TypeSound.ClickButton)
                {
                    clip = clickButton;
                }
                else if (typeSound == TypeSound.TakeItem)
                {
                    clip = takeItem;
                }
                else if (typeSound == TypeSound.RightItemMove)
                {
                    clip = rightItemMove;
                }
                else if (typeSound == TypeSound.WrongItemMove)
                {
                    clip = wrongItemMove;
                }
                else if (typeSound == TypeSound.Victory)
                {
                    clip = victory;
                }

                source.clip = clip;
                source.Play();
            }
        }
    }

    public enum TypeSound
    {
        ClickButton,
        TakeItem,
        RightItemMove,
        WrongItemMove,
        Victory
    }
}