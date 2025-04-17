using Core.Component;
using OutlineSystem;
using UnityEngine;

namespace SceneObjectsSystem
{
    public abstract class SceneObject : MonoBehaviour, IInit
    {
        public bool IsInit { get; set; }

        public void OnInit()
        {
            if (IsInit)
            {
                return;
            }

            IsInit = true;
            
            foreach (var init in GetComponentsInChildren<IInit>(true))
            {
                init.OnInit();
            }
            
            Init();
        }

        protected abstract void Init();

        public void EnableOutline()
        {
            if (TryGetComponent(out OutlineComponent outlineComponent))
            {
                outlineComponent.EnableOutline();
            }
        }

        public void DisableOutline()
        {
            if (TryGetComponent(out OutlineComponent outlineComponent))
            {
                outlineComponent.DisableOutline();
            }
        }

        public void EnableCollider()
        {
            GetComponent<Collider>().enabled = true;
        }

        public void DisableCollider()
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}