using Code.CameraPrefab;
using UnityEngine;
using UnityEngine.UI;

namespace Code.LevelEditor
{
    public class EditorControl : MonoBehaviour
    {
        [SerializeField] private GameObject[] controlBars; //objectsBar triggersBar players
        [SerializeField] private ScrollRect levelScrollRect;
        [SerializeField] private GameObject deleteOverlay;
        private int _selectedBar;
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
            ChecksInputs();
        }

        public void DeleteButtonClicked()
        {
            deleteOverlay.SetActive(!deleteOverlay.activeSelf);
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
                //stop completely the scroll rect
                levelScrollRect.velocity = Vector2.zero;
                levelScrollRect.content.anchoredPosition = new Vector2(0, 0);
            }
        }

        public void ChangeSelectedBar()
        {
            _selectedBar += 1;

            if (_selectedBar >= controlBars.Length)
            {
                _selectedBar = 0;
            }

            for (int i = 0; i < controlBars.Length; i++)
            {
                controlBars[i].SetActive(_selectedBar == i);
            }
        }

        private void ChecksInputs()
        {
            
        }
    }
}