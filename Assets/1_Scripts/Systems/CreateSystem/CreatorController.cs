using System.Linq;
using Core.Controllers;
using Core.Managers;
using ItemsSystem.Items;
using NaughtyAttributes;
using UnityEngine;

namespace Controllers
{
    [CreateAssetMenu(fileName = "CreatorController", menuName = "Controllers/CreatorController")]
    public class CreatorController : Controller
    {
        [BoxGroup("Item")] [SerializeField] private Item[] itemsPrefabs;

        private GameObject createObjects;
        private int counterResourcesModels;

        private Transform itemsParent;

        public override void OnInitialize()
        {
            createObjects = new GameObject("CreateObjects");
        }

        public override void OnStart()
        {
            itemsParent = UIManager.Instance.GetItemsParent;
        }

        public Item CreateItem(ItemType itemType)
        {
            Item itemPrefab = itemsPrefabs.FirstOrDefault(prefab => prefab.GetItemType == itemType);
            Item newItem = Instantiate(itemPrefab, itemsParent);
            newItem.transform.localPosition = new Vector3(0, -1000, 0);
            newItem.OnInit();
            return newItem;
        }
    }
}