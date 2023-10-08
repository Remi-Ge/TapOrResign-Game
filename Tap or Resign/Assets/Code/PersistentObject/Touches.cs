using System.Collections.Generic;
using UnityEngine;

namespace Code.PersistentObject
{
    public class Touches : MonoBehaviour
    {
        public List<Touch> GetBeganTouches()
        {
            List<Touch> beganTouches = new List<Touch>();
            //loops through every touches input
            for (int i = 0; i < Input.touchCount; i++)
            {
                //add to the list if the touch just began
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    beganTouches.Add(Input.GetTouch(i));
                }
            }

            return beganTouches;
        }
    }
}