using ItemsSystem.Items;
using UnityEngine;

namespace UI.Windows
{
    public class ClosetWindow : Window
    {
        public ItemPosition[] GetItemsPositions => GetComponentsInChildren<ItemPosition>(true);
    }
}