using UnityEngine;

namespace Code.CameraPrefab
{
    public class CameraVisual : MonoBehaviour
    {
        public void SetCameraBackgroundColor(Color backgroundColor)
        {
            GetComponent<Camera>().backgroundColor = backgroundColor;
        }
    }
}