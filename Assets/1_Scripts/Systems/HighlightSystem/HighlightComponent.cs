using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HighlightSystem
{
    public class HighlightComponent : MonoBehaviour
    {
        private Image image;
        private Tween tweenAnim;
        private bool isInit;

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            transform.GetChild(0).transform.TryGetComponent(out image);

            if (!image)
            {
                transform.GetChild(0).transform.TryGetComponent(out image);

                Debug.LogError("Not have image in highlight component");
            }

            isInit = true;
        }

        public void EnableHighlight()
        {
            if (!isInit)
            {
                Init();
            }
            
            if (image)
            {
                image.gameObject.SetActive(true);
                image.DOFade(0f, 0);
                tweenAnim = image.DOFade(1f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
            }
        }
        
        public void DisableHighlight()
        {
            if (image)
            {
                image.gameObject.SetActive(false);
                tweenAnim.Complete();
                tweenAnim.Kill();
                image.DOFade(1, 0);
            }
        }
    }
}
