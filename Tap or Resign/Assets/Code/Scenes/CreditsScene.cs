using Code.PersistentObject;
using UnityEngine;

namespace Code.Scenes
{
    public class CreditsScene : MonoBehaviour
    {
        private void Start()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("Menu", 0, 0, 3f);
        }
    }
}

