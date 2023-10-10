using Code.CameraPrefab;
using UnityEngine;
using UnityEngine.UI;

namespace Code.LevelEditor
{
    public class EditorControl : MonoBehaviour
    {
        [SerializeField] private ScrollRect levelScrollRect;
        private float _worldDistanceRatio;
        private Transform _mainCamera;

        private void Awake()
        {
            _mainCamera = FindObjectOfType<Camera>().transform;
        }

        private void Start()
        {
            _worldDistanceRatio = FindObjectOfType<CameraSize>().ScreenToWorldDistance(1);
        }

        private void Update()
        {
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            //set the camera position (must be under zero)
            _mainCamera.position = new Vector3(0, 
                Mathf.Clamp(-levelScrollRect.content.anchoredPosition.y * _worldDistanceRatio
                    , 0, Mathf.Infinity), -10);
            //stop the scroller if it's at 0
            if (levelScrollRect.content.anchoredPosition.y > 0)
            {
                levelScrollRect.velocity = Vector2.zero;
                levelScrollRect.content.anchoredPosition = new Vector2(0, 0);
            }
        }
    }
}