using Core.Controllers;
using NaughtyAttributes;
using UnityEngine;

namespace DataSystem
{
    [CreateAssetMenu(fileName = "DataController", menuName = "Controllers/DataController")]
    public class DataController : Controller
    {
        [BoxGroup("Colors")] [SerializeField] private Color greenColor;
        
        public Color GetGreenColor => greenColor;
        
        public override void OnInitialize()
        {
            
        }
    }
}