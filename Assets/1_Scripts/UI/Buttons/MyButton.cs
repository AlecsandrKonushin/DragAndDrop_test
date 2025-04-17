using Core.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class MyButton : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(()=>
            {
                AudioManager.Instance.PlaySound(TypeSound.ClickButton);
            });
        }
    }
}