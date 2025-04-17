using Core.Controllers;
using DG.Tweening;
using GameSystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class BlackoutWindow : Window
    {
        [SerializeField] private Button restartButton;

        protected override void AfterStart()
        {
            restartButton.onClick.AddListener(BoxControllers.GetController<GameController>().RestartGame);
        }

        public override void Show()
        {
            base.Show();

            substrate.DOFade(0, 0);
            substrate.DOFade(1, 1);
        }

        public override void Hide()
        {
            substrate.DOFade(0, 1f).OnComplete(() => base.Hide());
        }
    }
}