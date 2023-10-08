using System.Collections.Generic;
using UnityEngine;

namespace Code.PersistentObject
{
    public class Touches : MonoBehaviour
    {
        private RuntimePlatform _usedPlatform;

        private void Awake()
        {
            _usedPlatform = Application.platform;
        }

        public List<TouchStruct> GetBeganTouches()
        {
            List<TouchStruct> beganTouches = new List<TouchStruct>();
            if (_usedPlatform == RuntimePlatform.WindowsPlayer) //for windows
            {
                if (Input.GetMouseButtonDown(0))
                {
                    beganTouches.Add(new TouchStruct()
                    {
                        FingerId = 0,
                        ScreenPosition = Input.mousePosition
                    }); 
                }
            }
            else //for the rest (android and ios)
            {
                //loops through every touches input
                for (int i = 0; i < Input.touchCount; i++)
                {
                    //add to the list if the touch just began
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        beganTouches.Add(new TouchStruct()
                        {
                            FingerId = Input.GetTouch(i).fingerId,
                            ScreenPosition = Input.GetTouch(i).position
                        }); 
                    }
                }
            }
            

            return beganTouches;
        }

        public struct TouchStruct
        {
            public int FingerId;
            public Vector2 ScreenPosition;
        }
    }
}