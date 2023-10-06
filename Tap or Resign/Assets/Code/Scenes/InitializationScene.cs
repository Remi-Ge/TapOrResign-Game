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
            StartCoroutine(WaitAndChangeScene());
        }

        private void Start()
        {
            FindObjectOfType<CameraVisual>().SetCameraBackgroundColor(Color.white);
            FindObjectOfType<CameraSize>().SetCameraSize(5f, 1f);
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