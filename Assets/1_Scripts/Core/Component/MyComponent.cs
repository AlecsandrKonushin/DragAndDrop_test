using UnityEngine;

namespace Core.Component
{
    public abstract class MyComponent : MonoBehaviour, IInit
    {
        public bool IsInit { get; set; }

        public void OnInit()
        {
            if (IsInit)
            {
                return;
            }

            IsInit = true;
            
            Init();
        }

        protected abstract void Init();
    }
}