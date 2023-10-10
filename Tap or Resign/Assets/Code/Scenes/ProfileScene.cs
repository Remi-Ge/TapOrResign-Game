using Code.CameraPrefab;
using Code.PersistentObject;
using UnityEngine;

namespace Code.Scenes
{
    public class ProfileScene : MonoBehaviour
    {
        [SerializeField] private Transform[] ownedSkinsTransforms;
        private void Start()
        {
            //set the camera orthographic size
            FindObjectOfType<CameraSize>().SetCameraSize(25f, 1);
            //launch start position
            Persistent.GetPersistentObject().GetComponent<Transitions>().LaunchStartTransition(0, 0, 0.5f);
            //set the right skin to every skin
            SetSkins();
        }

        public void BackButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("Menu", 0, 0, 0.5f);
        }

        public void PersonalizationButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("Personalization", 0, 0, 0.5f);
        }

        private void SetSkins()
        {
            //apply skins here
        }
    }
}

