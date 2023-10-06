using System;
using Code.CameraPrefab;
using Code.PersistentObject;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Code.Scenes
{
    public class CommunityScene : MonoBehaviour
    {
        public void Start()
        {
            //set the camera orthographic size
            FindObjectOfType<CameraSize>().SetCameraSize(25f, 1);
            //launch start position
            Persistent.GetPersistentObject().GetComponent<Transitions>().LaunchStartTransition(0, 0, 0.5f);
        }

        public void BackButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("OfficialLevels", 0, 0, 0.5f);
        }

        public void LevelsButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("CommunityLevels", 0, 0, 0.5f);
        }

        public void ImportButton()
        {
            //download a level ( open the panel )
        }

        public void CreateButton()
        {
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("CreatedLevels", 0, 0, 0.5f);
        }
    }
}
