using System;
using System.Collections.Generic;
using Code.CameraPrefab;
using Code.PersistentObject;
using UnityEngine;

namespace Code.LevelEditor
{
    public class EditorPlaceItem : MonoBehaviour
    {
        [SerializeField] private Transform[] startPositionsTransform;
        private int _currentState = 0; //0 nothing 1 placing 2 deleting
        private Touches.TouchStruct _usedTouch;
        private Vector2 _lastSnappedPosition = new Vector2(0.2f, 0.2f); //random value that cannot be normally"
        private CameraSize _cameraSize;
        private int _levelWidth = 5;

        private void Awake()
        {
            ClearUsedTouch();
            _cameraSize = FindObjectOfType<CameraSize>();
        }

        public void ClearState()
        {
            _currentState = 0;
        }

        public void SetStateToPlace()
        {
            _currentState = 1;
        }

        public void SetStateToDelete()
        {
            _currentState = 2;
        }

        private void ClearUsedTouch()
        {
            _usedTouch = new Touches.TouchStruct()
            {
                FingerId = -1,
                ScreenPosition = Vector2.zero
            };
        }

        private void Update()
        {
            CheckInputs();
        }

        private void CheckInputs()
        {
            if (_usedTouch.FingerId != -1)
            {
                if (!Persistent.GetPersistentObject().GetComponent<Touches>().DoesTouchExists(_usedTouch.FingerId))
                {
                    _lastSnappedPosition = new Vector2(0.2f, 0.2f); //reset the last snapped position
                    ClearUsedTouch();
                }
            }
            
            
            //if there is already a finger return
            if (_usedTouch.FingerId != -1)
            {
                PlaceItem();
                return;
            }
            
            if (_currentState == 1)
            {
                List<Touches.TouchStruct> beganTouches = Persistent.GetPersistentObject()
                    .GetComponent<Touches>().GetBeganTouches();
                if (beganTouches.Count != 0)
                {
                    //new input started
                    _usedTouch = beganTouches[0];
                    PlaceItem();
                }
            }
        }

        private Vector2 CalculatePosition(Vector2 screenPosition)
        {
            Vector2 worldPosition = _cameraSize.ScreenToWorldPoint(screenPosition);
            Vector2 snappedPosition;
            if (_levelWidth % 2 == 0)
            {
                snappedPosition = new Vector2((float)Math.Round((worldPosition.x-2.5f) / 5f) * 5 + 2.5f
                    , (float)Math.Round((worldPosition.y-2.5f) / 5f) * 5 + 2.5f);
            }
            else
            {
                snappedPosition = new Vector2((float)Math.Round(worldPosition.x / 5f) * 5
                    , (float)Math.Round(worldPosition.y / 5f) * 5);
            }
            return snappedPosition;
        }
        
        private void PlaceItem()
        {
            if (_usedTouch.FingerId == -1)
            {
                return;
            }
            
            Vector2 screenPosition = Persistent.GetPersistentObject().GetComponent<Touches>()
                .GetTouchCoordinates(_usedTouch.FingerId);

            Vector2 snappedPosition = CalculatePosition(screenPosition);
            
            if (_lastSnappedPosition == snappedPosition)
            {
                return;
            }
            else
            {
                _lastSnappedPosition = snappedPosition;
            }
            
            GameObject newObject = Instantiate(Persistent.GetPersistentObject().GetComponent<ObstaclesReferences>().obstaclesPrefabs[0]
                , snappedPosition, Quaternion.identity);
            Rigidbody2D newObjectRb = newObject.GetComponent<Rigidbody2D>();
            if (newObjectRb != null)
            {
                Destroy(newObjectRb);
            }
        }
    }
}