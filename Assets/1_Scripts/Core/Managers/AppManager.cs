using Core.Main;
using UnityEngine;

namespace Core.Managers
{
    public class AppManager : Singleton<AppManager>
    {
        private void Start()
        {
            StartApp();
        }

        private void StartApp()
        {
            LoadSaveManager.Instance.Init();
            Localizator.Instance.Init();

            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            AudioManager.Instance.ChangeAudioVolume(LoadSaveManager.AudioIsEnable);
            ScenesManager.Instance.LoadGameScene();
        }
    }
}