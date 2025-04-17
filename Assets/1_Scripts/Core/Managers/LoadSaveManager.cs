using Core.Main;
using SaveSystem;
using UnityEngine;

namespace Core
{
    public class LoadSaveManager : Singleton<LoadSaveManager>
    {
        private SaveData saveData;

        public void Init()
        {
            saveData = new SaveData();
        }

        public static bool AudioIsEnable
        {
            get => Instance.saveData.AudioIsEnable;
            set => Instance.saveData.AudioIsEnable = value;
        }

        public static float SpeedRotate
        {
            get => Instance.saveData.SpeedRotate;
            set => Instance.saveData.SpeedRotate = value;
        }
        
        public static void Save()
        {
        }

        public static void DeleteAllSave()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}