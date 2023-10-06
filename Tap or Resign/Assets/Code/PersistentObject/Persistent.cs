using UnityEngine;

namespace Code.PersistentObject
{
    public class Persistent : MonoBehaviour
    {
        private static Persistent _persistentObject;

        private void Awake()
        {
            //checks at the start if there is another persistent object
            if (GetPersistentObject() != null)
            {
                Destroy(gameObject);
                return;
            }

            _persistentObject = this;
            DontDestroyOnLoad(gameObject);
        }

        public static Persistent GetPersistentObject()
        {
            return _persistentObject;
        }
    }
}