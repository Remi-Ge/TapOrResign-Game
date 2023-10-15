using UnityEngine;

namespace Code.LevelEditor
{
    public class EditorPlaceItem : MonoBehaviour
    {
        [SerializeField] private Transform[] startPositionsTransform;
        private bool _isPlacing;
        private bool _isDeleting;

        public void SetActionToNothing()
        {
            _isPlacing = false;
            _isDeleting = false;
        }
        
        public void SetActionToPlacing()
        {
            _isPlacing = true;
            _isDeleting = false;
        }

        public void SetActionToDeleting()
        {
            _isPlacing = false;
            _isDeleting = true;
        }
    }
}