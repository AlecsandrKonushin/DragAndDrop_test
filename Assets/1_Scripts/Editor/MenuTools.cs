using Core;
using UnityEditor;

#if UNITY_EDITOR

namespace EditorTools
{
    public class MenuTools
    {
        [MenuItem("Tools/Delete Save")]
        private static void DeleteSave()
        {
            LoadSaveManager.DeleteAllSave();
        }
    }
}

#endif