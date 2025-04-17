using UnityEngine;

namespace Core.Main
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        protected void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = gameObject.GetComponent<T>();

                AfterAwake();
            }
        }

        protected virtual void AfterAwake()
        {
        }

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // Debug.LogError(typeof(T) + "  не найден!!!");
                }

                return instance;
            }
        }
    }
}