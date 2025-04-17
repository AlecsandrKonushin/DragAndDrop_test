using System;
using System.Collections.Generic;
using System.Linq;
using Core.Main;
using UI.Windows;
using UnityEngine;

namespace Core.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private Canvas windowsCanvas;
        [SerializeField] private Transform itemsParent;

        private Action<bool> windowIsOpenEvent;

        private Dictionary<Type, Window> windows;
        private bool isInit;

        public bool GetIsInit => isInit;
        public Canvas GetCanvasWindows => windowsCanvas;
        public Transform GetItemsParent => itemsParent;

        #region INITIALIZE

        public void OnInitialize()
        {
            Window[] getWindows = GetComponentsInChildren<Window>();
            windows = new Dictionary<Type, Window>();

            foreach (var window in getWindows)
            {
                windows.Add(window.GetType(), window);
            }

            foreach (var window in windows)
            {
                window.Value.OnInitialize();
            }

            isInit = true;
        }

        public void OnStart()
        {
            foreach (var window in windows)
            {
                window.Value.OnStart();
            }
        }

        #endregion INITIALIZE

        #region GET/SHOW/HIDE

        public static T GetWindow<T>() where T : Window
        {
            if (Instance.windows.TryGetValue(typeof(T), out var window))
            {
                return window as T;
            }
            else
            {
                Debug.LogError($"Not have window {typeof(T)} !");

                return null;
            }
        }

        public static void ShowWindow<T>(bool isNeedBlockInput = true) where T : Window
        {
            if (Instance.windows.TryGetValue(typeof(T), out var window))
            {
                if (isNeedBlockInput)
                {
                    Instance.windowIsOpenEvent?.Invoke(true);
                }

                window.Show();
            }
            else
            {
                Debug.LogError($"Not have window {typeof(T)} for show!");
            }
        }

        public static void HideWindow<T>() where T : Window
        {
            if (Instance.windows.TryGetValue(typeof(T), out var window))
            {
                Instance.windowIsOpenEvent?.Invoke(false);

                window.Hide();
            }
            else
            {
                Debug.LogError($"Not have window {typeof(T)} for close");
            }
        }

        public static void ChangeLanguage()
        {
            foreach (var window in Instance.windows)
            {
                window.Value.ChangeLanguage();
            }
        }

        #endregion

        private void ChangeLocalization()
        {
            foreach (var window in Instance.windows)
            {
                window.Value.ChangeLanguage();
            }
        }

        public void SubscribeOnWindowIsOpen(Action<bool> sender)
        {
            if (windowIsOpenEvent != null && windowIsOpenEvent.GetInvocationList().Contains(sender))
            {
                Debug.LogError($"Try 2 subscribes on windowIsOpenEvent");
            }
            else
            {
                windowIsOpenEvent += sender;
            }
        }

        public void UnsubscribeOnWindowIsOpen(Action<bool> sender)
        {
            windowIsOpenEvent -= sender;
        }
    }
}