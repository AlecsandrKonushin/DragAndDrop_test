using System;
using System.Collections.Generic;
using Core.Component;
using Core.Controllers;
using DG.Tweening;
using Systems.ItemsSystem;
using UnityEngine;

namespace ItemsSystem.Items
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Item : MonoBehaviour, IInit
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private GameObject shadow;
        [SerializeField] private float defaultSize, bigSize;

        private MoveItemController moveItemController;

        [SerializeField] private ItemPosition itemPosition;
        private Tween sizeTween;
        private Collider2D collider2D;
        private List<Item> collisionItems;
        private bool isComplete;

        public ItemType GetItemType => itemType;
        public ItemPosition GetItemPosition => itemPosition;
        public List<Item> GetCollisionItems => collisionItems;
        public bool GetIsComplete => isComplete;

        public void OnInit()
        {
            moveItemController = BoxControllers.GetController<MoveItemController>();
            collisionItems = new List<Item>();
            collider2D = GetComponent<Collider2D>();
        }

        public void SetPosition(ItemPosition itemPosition)
        {
            this.itemPosition = itemPosition;

            MoveItemToHisPosition();
        }

        private void MoveItemToHisPosition()
        {
            transform.DOMove(itemPosition.transform.position, 0.3f);
        }

        public void MoveState()
        {
            ChangeScale(bigSize);
            collider2D.isTrigger = true;
            collisionItems.Clear();
        }

        public void DefaultState()
        {
            isComplete = false;
            collider2D.enabled = true;
            collider2D.isTrigger = false;

            ChangeScale(defaultSize);
            MoveItemToHisPosition();
        }

        public void CompleteState()
        {
            isComplete = true;
            collider2D.enabled = false;

            ChangeScale(defaultSize);
        }

        private void ChangeScale(float value)
        {
            if (sizeTween != null)
            {
                sizeTween.Kill();
            }

            sizeTween = transform.DOScale(value, 0.1f);
        }

        public void ShowWrongAnimation()
        {
            Vector3 rotate = new Vector3(0, 0, 15);
            Vector3 rotateReverse = new Vector3(0, 0, -15);

            DOTween.Sequence()
                .Append(transform.DORotate(rotate, 0.15f))
                .Append(transform.DORotate(rotateReverse, 0.15f))
                .Append(transform.DORotate(Vector3.zero, 0.1f));
        }

        private void OnMouseDown()
        {
            if (!isComplete)
            {
                moveItemController.StartMove(this);
            }
        }

        private void OnMouseUp()
        {
            if (!isComplete)
            {
                moveItemController.StopMove();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item item))
            {
                if (collisionItems.Contains(item) == false)
                {
                    collisionItems.Add(item);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item item))
            {
                if (collisionItems.Contains(item))
                {
                    collisionItems.Remove(item);
                }
            }
        }
    }
}