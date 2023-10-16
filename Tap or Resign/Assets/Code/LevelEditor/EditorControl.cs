using System;
using Code.CameraPrefab;
using UnityEngine;
using UnityEngine.UI;

namespace Code.LevelEditor
{
    public class EditorControl : MonoBehaviour
    {
        //references
        [SerializeField] private GameObject[] controlBars; //objectsBar triggersBar players
        [SerializeField] private AnimatorsList[] itemsAnimators;
        [SerializeField] private ScrollRect levelScrollRect;
        [SerializeField] private GameObject deleteOverlay;
        //selected item
        private SelectedItemStruct _selectedItem = new SelectedItemStruct() 
        {
            SelectedItemIndex = -1,
            SelectedItemBarIndex = -1
        };
        //variables
        private int _selectedBar;
        //constants
        private float _worldDistanceRatio;
        private Transform _mainCamera;

        private void Awake()
        {
            _mainCamera = FindObjectOfType<Camera>().transform;
        }

        private void Start()
        {
            _worldDistanceRatio = _mainCamera.GetComponent<CameraSize>().ScreenToWorldDistance(1);
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
            
            SetAnimatorEnabled(true, _selectedItem.SelectedItemIndex, _selectedItem.SelectedItemBarIndex);
        }

        public void ItemButtonClicked(int itemIndex)
        {
            if ((_selectedItem.SelectedItemBarIndex == _selectedBar && _selectedItem.SelectedItemIndex >= 0)
                || (itemIndex == _selectedItem.SelectedItemIndex && _selectedBar == _selectedItem.SelectedItemBarIndex))
            {
                SetAnimatorEnabled(false, _selectedItem.SelectedItemIndex, _selectedItem.SelectedItemBarIndex);
            }

            if (itemIndex == _selectedItem.SelectedItemIndex && _selectedBar == _selectedItem.SelectedItemBarIndex)
            {
                _selectedItem = new SelectedItemStruct()
                {
                    SelectedItemIndex = -1,
                    SelectedItemBarIndex = -1
                };
            }
            else
            {
                _selectedItem = new SelectedItemStruct()
                {
                    SelectedItemIndex = itemIndex,
                    SelectedItemBarIndex = _selectedBar
                };
            }

            if (_selectedItem.SelectedItemBarIndex == _selectedBar && _selectedItem.SelectedItemIndex >= 0)
            {
                SetAnimatorEnabled(true, itemIndex, _selectedBar);
            }
        }

        private void SetAnimatorEnabled(bool isActive, int itemIndex, int barIndex)
        {
            if (itemIndex < 0 || barIndex < 0)
            {
                return;
            }
            
            itemsAnimators[barIndex].animatorList[itemIndex]
                .SetBool(Animator.StringToHash("isSelected"), isActive);
        }

        private void ChecksInputs()
        {
            
        }

        private struct SelectedItemStruct
        {
            public int SelectedItemIndex;
            public int SelectedItemBarIndex;
        }

        [Serializable]
        private struct AnimatorsList
        {
            public Animator[] animatorList;
        }
    }
}