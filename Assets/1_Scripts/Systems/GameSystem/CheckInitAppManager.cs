using Core.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystem
{
    public class CheckInitAppManager : MonoBehaviour
    {
        private void Awake()
        {
            if (AppManager.Instance == null)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}