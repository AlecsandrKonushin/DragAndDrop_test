using System.Collections;
using Core.Controllers;
using Core.Main;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Managers
{
    public class ScenesManager : Singleton<ScenesManager>
    {
        [SerializeField] private GameObject loaderCanvas;

        private AsyncOperation operation;
        
        private bool sceneIsLoad = false, sliderIsLoad = false;

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(0);
        }
        
        public void LoadGameScene()
        {
            StartCoroutine(CoLoadScene(1));
        }
        
        private IEnumerator CoLoadScene(int number)
        {
            loaderCanvas.SetActive(true);

            operation = SceneManager.LoadSceneAsync(number);

            yield return operation;

            sceneIsLoad = true;
            operation = null;

            loaderCanvas.SetActive(false);
            SceneControllers.Instance.InitControllers();
        }
    }
}