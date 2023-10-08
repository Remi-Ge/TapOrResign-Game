using System.Collections;
using Code.CameraPrefab;
using Code.PersistentObject;
using UnityEngine;

namespace Code.Scenes
{
    public class InitializationScene : MonoBehaviour
    {
        private void Awake()
        {
            CheckPlatform();
            StartCoroutine(WaitAndChangeScene());
        }

        private void Start()
        {
            FindObjectOfType<CameraVisual>().SetCameraBackgroundColor(Color.white);
            FindObjectOfType<CameraSize>().SetCameraSize(5f, 1f);
        }

        private void CheckPlatform()
        {
            RuntimePlatform usedPlatform = Application.platform;

            if (usedPlatform == RuntimePlatform.WindowsPlayer)
            {
                Screen.SetResolution(1080 / 2, 1920 / 2, false);
            }
        }

        public void ScreenClicked()
        {
            StopAllCoroutines();
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("Menu", 0, 0, 0.5f);
        }

        private IEnumerator WaitAndChangeScene()
        {
            yield return new WaitForSeconds(1.5f);
            Persistent.GetPersistentObject().GetComponent<Transitions>().ChangeSceneWithTransition("Menu", 0, 0,  0.5f);
        }
    }
}