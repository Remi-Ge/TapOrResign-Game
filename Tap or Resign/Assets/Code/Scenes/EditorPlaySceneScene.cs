using Code.CameraPrefab;
using Code.PersistentObject;
using Code.Play;
using UnityEngine;

namespace Code.Scenes
{
    public class EditorPlaySceneScene : MonoBehaviour
    {
        private void Start()
        {
            //set the camera orthographic size
            FindObjectOfType<CameraSize>().SetCameraSize(25f, 1);
            //launch start position
            Persistent.GetPersistentObject().GetComponent<Transitions>().LaunchStartTransition(0, 0, 0.5f);
        }
        
        public void PauseButton()
        {
            GetComponent<PauseGame>().OpenPauseMenu();
        }

        public void PauseMenuBackground() //which close the pause menu
        {
            GetComponent<PauseGame>().ClosePauseMenu();
        }

        public void ResumeButton()
        {
            GetComponent<PauseGame>().ClosePauseMenu();
        }

        public void EditButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("LevelEditor", 0, 0, 0.5f);
        }
        
        public void QuitButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("CreatedLevels", 0, 0, 0.5f);
        }
    }
}
