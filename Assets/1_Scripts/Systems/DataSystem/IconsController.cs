using System;
using System.Linq;
using Core.Controllers;
using ItemsSystem.Items;
using NaughtyAttributes;
using UnityEngine;

namespace DataSystem
{
    [CreateAssetMenu(fileName = "IconsController", menuName = "Controllers/IconsController")]
    public class IconsController : Controller
    {
        [SerializeField] private Sprite defaultSprite;
        // [BoxGroup("Items sprites")]
        // [SerializeField] private ItemSpriteData[] itemSprites;

        // public Sprite GetItemSprite(ItemType itemType)
        // {
        //     ItemSpriteData data = itemSprites.FirstOrDefault(data=>data.ItemType == itemType);
        //
        //     if (data == null)
        //     {
        //         Debug.LogError($"Not have sprite item with type {itemType}");
        //         return defaultSprite;
        //     }
        //     else
        //     {
        //         return data.Sprite;
        //     }
        // }
    }

    // [Serializable]
    // public class ItemSpriteData
    // {
    //     public ItemType ItemType;
    //     public Sprite Sprite;
    // }
}