using UnityEngine;

namespace Obscurity
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance;

        public static T Instance
        {
            get
            {
                if (!instance)
                    instance = FindObjectOfType<T>();

                return instance; 
            }
        }

        protected virtual void Awake() => instance = Instance;

        protected virtual void OnDisable() => instance = null;
    }
}