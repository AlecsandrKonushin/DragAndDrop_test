using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Core.Controllers;
using Core.Main;
using Core.Managers;
using GameSystem;
using ItemsSystem.Items;
using UI.Windows;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Systems.ItemsSystem
{
    [CreateAssetMenu(fileName = "ItemsController", menuName = "Controllers/ItemsController")]
    public class ItemsController : Controller
    {
        private const int COUNT_ITEMS_BY_TYPE = 4;

        private List<Item> items;
        private ItemPosition[] itemsPositions;

        private AudioManager audioManager;

        public override void OnStart()
        {
            itemsPositions = UIManager.GetWindow<ClosetWindow>().GetItemsPositions;
            audioManager = AudioManager.Instance;
        }

        public void CreateItemsInStartGame()
        {
            Coroutines.StartRoutine(CoCreateItemsInStartGame());
        }

        private IEnumerator CoCreateItemsInStartGame()
        {
            items = new List<Item>();

            CreatorController creatorController = BoxControllers.GetController<CreatorController>();
            List<ItemPosition> emptyPositions = new List<ItemPosition>(itemsPositions);

            foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
            {
                for (int i = 0; i < COUNT_ITEMS_BY_TYPE; i++)
                {
                    Item newItem = creatorController.CreateItem(itemType);
                    items.Add(newItem);
                    ItemPosition emptyPosition = emptyPositions.FirstOrDefault(pos => pos.GetItemType == itemType);
                    emptyPositions.Remove(emptyPosition);
                    newItem.SetPosition(emptyPosition);

                    yield return new WaitForSeconds(0.1f);
                }
            }

            yield return new WaitForSeconds(0.5f);

            ShufflePositionsItems();
        }

        public void ShufflePositionsItems()
        {
            List<ItemPosition> positions = new List<ItemPosition>(itemsPositions);

            foreach (var item in items)
            {
                ItemPosition position = positions[Random.Range(0, positions.Count)];
                positions.Remove(position);
                item.SetPosition(position);
                item.DefaultState();
            }

            foreach (var item in items)
            {
                TryCompleteItem(item);
            }

            if (CheckVictoryGame())
            {
                ShufflePositionsItems();
            }
        }

        public void ItemStopMove(Item checkItem)
        {
            List<Item> collisionItems = checkItem.GetCollisionItems;

            if (collisionItems.Count > 0)
            {
                foreach (var collisionItem in collisionItems)
                {
                    if (checkItem.GetItemType == collisionItem.GetItemPosition.GetItemType)
                    {
                        RightMove(checkItem, collisionItem);
                        return;
                    }
                }
            }

            WrongMove(checkItem);
        }

        private void WrongMove(Item item)
        {
            audioManager.PlaySound(TypeSound.WrongItemMove);
            item.DefaultState();
            item.ShowWrongAnimation();
        }

        private void RightMove(Item firstItem, Item secondItem)
        {
            audioManager.PlaySound(TypeSound.RightItemMove);
            
            ItemPosition firstPosition = firstItem.GetItemPosition;
            firstItem.SetPosition(secondItem.GetItemPosition);
            secondItem.SetPosition(firstPosition);

            TryCompleteItem(firstItem);
            TryCompleteItem(secondItem);

            if (CheckVictoryGame())
            {
                audioManager.PlaySound(TypeSound.Victory);
                BoxControllers.GetController<GameController>().VictoryGame();
            }
        }

        private bool CheckVictoryGame()
        {
            foreach (var item in items)
            {
                if (item.GetIsComplete == false)
                {
                    return false;
                }
            }

            return true;
        }

        private void TryCompleteItem(Item item)
        {
            if (item.GetItemType == item.GetItemPosition.GetItemType)
            {
                item.CompleteState();
            }
        }
    }
}