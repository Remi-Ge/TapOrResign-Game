using Code.CameraPrefab;
using Code.LevelEditor;
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

        public void DeleteButton()
        {
            GetComponent<EditorControl>().DeleteButtonClicked();
        }

        public void SettingsButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("LevelSettings", 0, 0, 0.5f);
        }

        public void PlayButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("EditorPlayScene", 0, 0, 0.5f);
        }

        public void ChangeSelectedBar()
        {
            GetComponent<EditorControl>().ChangeSelectedBar();
        }

        public void SelectItem(int itemIndex)
        {
            GetComponent<EditorControl>().ItemButtonClicked(itemIndex);
        }
    }
}
