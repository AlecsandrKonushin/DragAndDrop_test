using Core.Controllers;
using Core.Managers;
using ItemsSystem.Items;
using UnityEngine;

namespace Systems.ItemsSystem
{
    public class MoveItemController : MonoController
    {
        private Item moveItem;
        private RectTransform itemRect;
        private Canvas canvas;
        private Vector2 localPosition;

        private AudioManager audioManager;
        private ItemsController itemsController;

        public override void OnInitialize()
        {
            canvas = UIManager.Instance.GetCanvasWindows;

            audioManager = AudioManager.Instance;
            itemsController = BoxControllers.GetController<ItemsController>();
        }

        public void StartMove(Item item)
        {
            audioManager.PlaySound(TypeSound.TakeItem);
            
            moveItem = item;
            itemRect = moveItem.GetComponent<RectTransform>();
            moveItem.MoveState();
            moveItem.transform.SetAsLastSibling();
        }

        public void StopMove()
        {
            itemsController.ItemStopMove(moveItem);
            moveItem = null;
        }

        private void Update()
        {
            if (moveItem)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.transform as RectTransform,
                    Input.mousePosition,
                    canvas.worldCamera,
                    out localPosition
                );

                itemRect.localPosition = localPosition;
            }
        }
    }
}