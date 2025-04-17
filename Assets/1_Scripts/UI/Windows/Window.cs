using System;
using Core.Component;
using Core.Controllers;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public abstract class Window : MonoBehaviour, IInitialize
    {
        public Action EndShowEvent, EndChange, EndHideEvent;
        
        [BoxGroup("Buttons")] [SerializeField] protected Button closeButton, backgroundCloseButton;
        
        protected GameObject background;
        protected CanvasGroup substrate;

        protected bool IsActive => background.activeSelf;

        public void OnInitialize()
        {
            background = transform.GetChild(0).gameObject;
            substrate = background.transform.GetChild(0).GetComponent<CanvasGroup>();
        }

        public void OnStart()
        {
            foreach (IInit initialize in gameObject.GetComponentsInChildren<IInit>(true))
            {
                if (initialize.GetType() != GetType())
                {
                    initialize.OnInit();
                }
            }
            
            AfterStart();
        }

        protected virtual void AfterStart() { }

        public virtual void Show()
        {
            background.SetActive(true);
        }

        public virtual void Hide()
        {
            background.SetActive(false);
        }
        
        public virtual void Change() { }
        public virtual void ChangeLanguage() { }        
    }
}