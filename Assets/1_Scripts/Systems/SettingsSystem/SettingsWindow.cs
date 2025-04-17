using System;
using System.Linq;
using Core;
using Core.Controllers;
using Core.Main;
using Core.Managers;
using NaughtyAttributes;
using UI.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace SettingsSystem.UI
{
    public class SettingsWindow : Window
    {
        private Action<float> changeRotateSpeedEvent;

        [SerializeField] private Button audioButton, crossButton;
        [SerializeField] private GameObject lockAudio, lockCross;
        [SerializeField] private Slider speedRotateSlider;
        [SerializeField] private Text settingsText, speedRotateText;

        [BoxGroup("Delete saves")] [SerializeField]
        private Button deleteSaveButton, confirmDeleteButton, noConfirmDeleteButton;

        [BoxGroup("Delete saves")] [SerializeField]
        private GameObject confirmDeleteSave;

        [BoxGroup("Delete saves")] [SerializeField]
        private Text confirmDeleteSaveText;

        protected override void AfterStart()
        {
            // settingsText.text = Localizator.GetTextUI("Settings");
            // speedRotateText.text = Localizator.GetTextUI("TurningSpeed");
            // audioButton.GetComponentInChildren<Text>().text = Localizator.GetTextUI("Audio");
            // crossButton.GetComponentInChildren<Text>().text = Localizator.GetTextUI("Cross");
            //
            // audioButton.onClick.AddListener(() =>
            // {
            //     LoadSaveManager.AudioIsEnable = !LoadSaveManager.AudioIsEnable;
            //     lockAudio.SetActive(!LoadSaveManager.AudioIsEnable);
            //     AudioManager.Instance.ChangeAudioVolume(LoadSaveManager.AudioIsEnable);
            // });
            //
            // crossButton.onClick.AddListener(() =>
            // {
            //     // LoadSaveManager.CrossIsEnable = !LoadSaveManager.CrossIsEnable;
            //     // lockCross.SetActive(!LoadSaveManager.CrossIsEnable);
            //     // UIManager.GetWindow<InputWindow>().ChangeStateCrossImage(LoadSaveManager.CrossIsEnable);
            // });
            //
            // // speedRotateSlider.maxValue = MainData.MAX_SPEED_ROTATE;
            // // speedRotateSlider.minValue = MainData.MIN_SPEED_ROTATE;
            // speedRotateSlider.onValueChanged.AddListener(ChangeValueSlider);
            //
            // closeButton.onClick.AddListener(CloseWindow);
            // backgroundCloseButton.onClick.AddListener(CloseWindow);
            //
            // lockAudio.SetActive(!LoadSaveManager.AudioIsEnable);
            // // lockCross.SetActive(!LoadSaveManager.CrossIsEnable);
            //
            // deleteSaveButton.onClick.AddListener(() => confirmDeleteSave.SetActive(true));
            // // confirmDeleteButton.onClick.AddListener(() =>
            // //     BoxControllers.GetController<GameController>().DeleteGameSaves());
            // noConfirmDeleteButton.onClick.AddListener(() => confirmDeleteSave.SetActive(false));
            // deleteSaveButton.GetComponentInChildren<Text>().text = Localizator.GetTextUI("DeleteSaves");
            // confirmDeleteButton.GetComponentInChildren<Text>().text = Localizator.GetTextUI("Yes");
            // noConfirmDeleteButton.GetComponentInChildren<Text>().text = Localizator.GetTextUI("No");
            // confirmDeleteSaveText.text = Localizator.GetTextUI("ConfirmDeleteSaves");
        }

        private void CloseWindow()
        {
            LoadSaveManager.Save();
            UIManager.HideWindow<SettingsWindow>();
        }

        private void ChangeValueSlider(float value)
        {
            changeRotateSpeedEvent?.Invoke(value);
            // LoadSaveManager.SpeedRotate = value;
        }

        public override void Show()
        {
            // speedRotateSlider.value = LoadSaveManager.SpeedRotate;
            // confirmDeleteSave.SetActive(false);
            // background.SetActive(true);
            // changeLanguageComponent.Show();
        }

        public override void Hide()
        {
            background.SetActive(false);
        }

        public void SubscribeOnChangeRotateSpeedEvent(Action<float> sender)
        {
            if (changeRotateSpeedEvent != null && changeRotateSpeedEvent.GetInvocationList().Contains(sender))
            {
                Debug.LogError($"Try 2 subscribes on changeRotateSpeedEvent");
            }
            else
            {
                changeRotateSpeedEvent += sender;
            }
        }

        public void UnsubscribeOnChangeRotateSpeedEvent(Action<float> sender)
        {
            changeRotateSpeedEvent -= sender;
        }
    }
}