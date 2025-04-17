using UnityEngine;

namespace ItemsSystem.Items
{
    public class ItemPosition : MonoBehaviour
    {
        [SerializeField] private ItemType itemType;

        public ItemType GetItemType => itemType;
    }
}