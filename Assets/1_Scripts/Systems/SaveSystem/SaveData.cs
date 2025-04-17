using System;
using Core.Main;

namespace SaveSystem
{
    [Serializable]
    public class SaveData
    {
        public bool AudioIsEnable = true;
        public TypeLanguage Language = TypeLanguage.EN;
        public float SpeedRotate;
    }
}