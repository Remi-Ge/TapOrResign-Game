using Code.CameraPrefab;
using Code.PersistentObject;
using UnityEngine;

namespace Code.Scenes
{
    public class LevelEditorScene : MonoBehaviour
    {
        private void Start()
        {
            //set the camera orthographic size
            FindObjectOfType<CameraSize>().SetCameraSize(25f, 1);
            //launch start position
            Persistent.GetPersistentObject().GetComponent<Transitions>().LaunchStartTransition(0, 0, 0.5f);
        }

        public void BackButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("CreatedLevels", 0, 0, 0.5f);
        }
    }
}
