using Core.Controllers;
using Core.Managers;
using Systems.ItemsSystem;
using UI.Windows;
using UnityEngine;

namespace GameSystem
{
    [CreateAssetMenu(fileName = "GameController", menuName = "Controllers/GameController")]
    public class GameController : Controller
    {
        public void StartGame()
        {
            BoxControllers.GetController<ItemsController>().CreateItemsInStartGame();
        }

        public void VictoryGame()
        {
            UIManager.ShowWindow<BlackoutWindow>();
        }

        public void RestartGame()
        {
            UIManager.HideWindow<BlackoutWindow>();
            BoxControllers.GetController<ItemsController>().ShufflePositionsItems();
        }
    }
}