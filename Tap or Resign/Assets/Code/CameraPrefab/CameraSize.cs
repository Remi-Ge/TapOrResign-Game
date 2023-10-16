using Code.BackgroundPrefab;
using UnityEngine;

namespace Code.CameraPrefab
{
    public class CameraSize : MonoBehaviour
    {
        public float ScreenToWorldDistance(float screenDistance)
        {
            //calculate 2 points for distance
            float firstXWorldPoint = ScreenToWorldPoint(new Vector2(0, 0)).x;
            float secondXWorldPoint = ScreenToWorldPoint(new Vector2(screenDistance, 0)).x;
            //calculate the distance for screenDistance
            return secondXWorldPoint - firstXWorldPoint;
        }
        
        public Vector2 ScreenToWorldPoint(Vector2 screenPoint)
        {
            Vector2 worldPoint = GetComponent<Camera>().ScreenToWorldPoint(screenPoint);
            return worldPoint;
        }

        public Vector2 WorldToScreenPoint(Vector2 worldPoint)
        {
            Vector2 screenPoint = GetComponent<Camera>().WorldToScreenPoint(worldPoint);
            return screenPoint;
        }

        private float GetCameraOrthographicSize()
        {
            float cameraSize = GetComponent<Camera>().orthographicSize;
            return cameraSize;
        }

        public void SetCameraSize(float backgroundWidth, float cameraWidthMultiplier)
        {
            Camera cameraCamera = GetComponent<Camera>();
            cameraCamera.orthographicSize = backgroundWidth * cameraWidthMultiplier / Screen.width * Screen.height / 2f;
            //find the background object in the scene
            Background background = FindObjectOfType<Background>();
            //return if no backgrounds are found
            if (background == null)
            {
                return;
            }
            //update the height of the background
            background.SetTilesSize(GetCameraOrthographicSize());
        }
    }
}